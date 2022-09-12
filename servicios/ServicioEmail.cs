using PortFolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PortFolio.Servicios{

    public interface IservicioEmail{

        Task Enviar(ContactoViewModel contacto);

    }
    


    public class ServicioEmail:IservicioEmail {
        private readonly IConfiguration configuration;

        public ServicioEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        

        public async Task Enviar(ContactoViewModel contacto){

             var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
             var email = configuration.GetValue<string>("SENDGRID_FROM");
             var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

             var cliente = new SendGridClient(apiKey);
             var from = new EmailAddress(email,nombre);


             var subject = $"El cliente contacto Email: {contacto.Email} quiere contactarte ";
             var to = new EmailAddress(email,nombre);
             var mensajeTexto = contacto.Mensaje;
             
             var htmlContent = @$" De: {contacto.Nombre}
             Email: {contacto.Email}
             Mensaje: {contacto.Mensaje}" ;
             var singleEmail = MailHelper.CreateSingleEmail(from , to , subject , mensajeTexto , htmlContent);


             var respuesta = await cliente.SendEmailAsync(singleEmail);
        }





    }

   


}