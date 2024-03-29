﻿using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Model;
using FluentResults;

namespace FilmeApi.Services
{
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string? nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            List<ReadCinemaDto> readDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);

            return readDto;
        }

        public ReadCinemaDto RecuperaFilmesPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }

            return null;
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema Não Encontrado");
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema Não Encontrado");
            }
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
