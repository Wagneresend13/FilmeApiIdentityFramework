
using MailKit.Net.Smtp;
using MimeKit;
using UsuariosApi.Models;

namespace UsuariosApi.Service
{
    public class EmailService
    {
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
            mensagemDoEmail.From.Add(new MailboxAddress("Adicionar Remetente"));
            mensagemDoEmail.To.AddRange(mensagem.Destinatario);
            mensagemDoEmail.Subject = mensagem.Assunto;
            mensagemDoEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) {Text = mensagem.Conteudo};

            return mensagemDoEmail;

        }
    }
}
