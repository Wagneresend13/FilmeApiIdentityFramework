using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity, createDto.Password);
            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail(" Falha ao cadastrar o Usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var IdentityUser = _userManager
                .Users
                .FirstOrDefault(usuario => usuario.Id == request.UsuarioId);
            var IdentityResult = _userManager.ConfirmEmailAsync(IdentityUser, request.CodigoDeAtivacao).Result;
            if (IdentityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta de Usuário");
        }
    }
}
