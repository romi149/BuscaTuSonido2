using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class EnvioEmails
    {
        public static void EnviarMail(string destinatario, string mensaje)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("buscatusonido.org@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Confirmación de registro";
                mail.Body = $"<!DOCTYPE html> <html lang='en'> <head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title> </head> <body> <div width='400px' style='width: 80%; display: flex; justify-content: center; margin: 18% auto; background-color: navy;color: white; '> <table style='width: 50%'> <thead> <tr> <td colspan='3'>Gracias Por Registrarte, para confirmar tu registro ingresa al siguiente link</td> </tr> </thead> <TBody> <tr> <td colspan='3'>{mensaje}</td> </tr> </TBody> </table> </div> </body> </html>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("buscatusonido.org@gmail.com", "Adrian1234");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                
            }
        }

        public static void EnviarMailRecuperoPass(string destinatario, string mensaje)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("buscatusonido.org@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Recupero de contraseña";
                mail.Body = $"<!DOCTYPE html> <html lang='en'> <head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title> </head> <body> <div width='400px' style='width: 80%; display: flex; justify-content: center; margin: 18% auto; background-color: navy;color: white; '> <table style='width: 50%'> <thead> <tr> <td colspan='3'>Para cambiar su contraseña ingrese al siguiente link</td> </tr> </thead> <TBody> <tr> <td colspan='3'>{mensaje}</td> </tr> </TBody> </table> </div> </body> </html>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("buscatusonido.org@gmail.com", "Adrian1234");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }

        public static void EnviarMailConfirmacionCambioPass(string destinatario, string mensaje)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("buscatusonido.org@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Cambio de contraseña";
                mail.Body = "< !DOCTYPE html > < html lang = 'en' > < head > < meta charset = 'UTF-8' > < meta name = 'viewport' content = 'width=device-width, initial-scale=1.0' > < title > Document </ title > </ head > < body > < div width = '400px' style = 'width: 80%; display: flex; justify-content: center; margin: 18% auto; background-color: navy;color: white; ' > < table style = 'width: 50%' > < thead > < tr > < td colspan = '3' > Su contraseña se ha cambiado correctamente</ td > </ tr > </ thead > < TBody > < tr > < td colspan = '3' > Link a login </ td > </ tr > </ TBody > </ table > </ div > </ body > </ html > ";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("buscatusonido.org@gmail.com", "Adrian1234");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }

        public static string md5(string Value)
        {
            MD5CryptoServiceProvider provDeEncriptacion = new MD5CryptoServiceProvider();
            byte[] DatosParaEncriptar = Encoding.ASCII.GetBytes(Value);
            DatosParaEncriptar = provDeEncriptacion.ComputeHash(DatosParaEncriptar);
            string ret = string.Empty;
            foreach (var item in DatosParaEncriptar)
                ret += item.ToString("x2").ToLower();
            return ret;
        }
    }
}
