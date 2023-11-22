using System;
using System.Threading.Tasks;
using Independentsoft.Graph.Mails;
using Independentsoft.Graph;
using Independentsoft.Graph.Users;

namespace SGDP.PLUS.Comun.General
{
    public class Correo
    {
        public string MailBox { get; set; } = null!;
        public string Addressee { get; set; } = null!;

        public async Task SendResetPasswordEmail(string link, GraphClientCustom client)
        {
            try
            { 
                var graphClient = new GraphClient
                {
                    ClientId = client.ClientId,
                    Tenant = client.Tenant,
                    ClientSecret = client.ClientSecret
                };

                string body = $"SGDP<br><br>Click <a href=\"{link}\">aqui</a> para restablecer su contraseña<br><br>Este enlace estara activo 30 minutos";

                Message message = new();
                message.Subject = MailBox;
                message.Body = new ItemBody($"<html><body>{body}</body></html>", ContentType.Html);
                message.ToRecipients.Add(new EmailAddress(Addressee));

                await graphClient.SendMessage(message, new UserId(MailBox));
            }
            catch (GraphException ex)
            {
                throw new Exception($"Error: {ex.Code}\nMessage: {ex.Message}");
            }
        }

    }
}
