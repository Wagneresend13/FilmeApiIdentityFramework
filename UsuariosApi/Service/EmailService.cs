
using MailKit.Net.Smtp;
using MimeKit;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);

            var mensagemDeEmail = CriaCorpoDoEMail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using( var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();   
                }
            }
        }

        private MimeMessage CriaCorpoDoEMail(Mensagem mensagem)
        {
            var mensagemDoEmail = new MimeMessage();
            mensagemDoEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            mensagemDoEmail.To.AddRange(mensagem.Destinatario);
            mensagemDoEmail.Subject = mensagem.Assunto;
            mensagemDoEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) {Text = mensagem.Conteudo};

            return mensagemDoEmail;

        }
    }
}
