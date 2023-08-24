
using Independentsoft.Graph.Mails;
using Independentsoft.Graph;
using Independentsoft.Graph.Users;



namespace SGDP.PLUS.Comun.General
{
    public class Correo
    {
        public string MailBox { get; set; } = null!;
        public string Addressee { get; set; } = null!;

        public async Task SendResetPasswordEmail(string link)
        {
            try
            {
                GraphClient client = new();

                client.ClientId = "06deab4b-5242-44dc-8230-b4cbf125d6ad";
                client.Tenant = "agoracsccom.onmicrosoft.com";
                client.ClientSecret = "Aco8Q~7kfwVFtouc9wp4bB.HF1bitxLZAT_NCcQ5";

                string body = $"SGDP<br><br>Click <a href=\"{link}\">aqui</a> para restablecer su contraseña<br><br>Este enlace estara activo 30 minutos";

                Message message = new ();
                message.Subject = MailBox;
                message.Body = new ItemBody($"<html><body>{body}</body></html>", ContentType.Html);
                message.ToRecipients.Add(new EmailAddress(Addressee));

                await client.SendMessage(message, new UserId(MailBox));
            }
            catch (GraphException ex)
            {
                throw new Exception($"Error: {ex.Code}\nMessage: {ex.Message}");
            }
        }

    }
}
