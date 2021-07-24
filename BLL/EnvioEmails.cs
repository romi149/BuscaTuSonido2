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

                var texto = "Gracias Por Registrarte, para confirmar tu registro ingresa al siguiente link";

                mail.From = new MailAddress("buscatusonido.org@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Confirmación de registro";
                mail.Body = $"<!DOCTYPE html><html lang='en'><body style='width: 80 %; '><div width='500px' style='width: 85%; display: flex; justify-content: center; margin: 10% auto; background-color:#F0195D;'><table align='center' ><thead><tr><td><font face='Mistral' size='30'>Busca Tu Sonido</font></td></tr><tr><td><h2>{texto}</h2></td></tr></thead><TBody><tr><td colspan='3'>{mensaje}</td></tr></TBody><tr></tr><tr><tr></tr></tr><tr><td><h3>Ante cualquier duda Contactanos:</h3><p>Teléfono: <strong>116045-2099</strong><br />Email: info@buscatusonido.com <strong></p></td></tr></table></div></body></html>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("buscatusonido.org@gmail.com", "Romina2021");

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

                var texto = "Para cambiar tu contraseña ingresa al siguiente link";

                mail.From = new MailAddress("buscatusonido.org@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Recupero de contraseña";
                mail.Body = $"<!DOCTYPE html><html lang='en'><body style='width: 80 %; '><div width='500px' style='width: 85%; display: flex; justify-content: center; margin: 10% auto; background-color:#F0195D;'><table align='center' ><thead><tr><td><font face='Mistral' size='30'>Busca Tu Sonido</font></td></tr><tr><td><h2>{texto}</h2></td></tr></thead><TBody><tr><td colspan='3'>{mensaje}</td></tr></TBody><tr></tr><tr><tr></tr></tr><tr><td><h3>Ante cualquier duda Contactanos:</h3><p>Teléfono: <strong>116045-2099</strong><br />Email: info@buscatusonido.com <strong></p></td></tr></table></div></body></html>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("buscatusonido.org@gmail.com", "Romina2021");

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

                var texto = "Tu contraseña se ha cambiado correctamente";
                
                mail.From = new MailAddress("buscatusonido.org@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Cambio de contraseña";
                mail.Body = $"<!DOCTYPE html><html lang='en'><body style='width: 80 %; '><div width='500px' style='width: 85%; display: flex; justify-content: center; margin: 10% auto; background-color:#F0195D;'><table align='center' ><thead><tr><td><font face='Mistral' size='30'>Busca Tu Sonido</font></td></tr><tr><td><h2>{texto}</h2></td></tr></thead><TBody><tr><td colspan='3'>{mensaje}</td></tr></TBody><tr></tr><tr><tr></tr></tr><tr><td><h3>Ante cualquier duda Contactanos:</h3><p>Teléfono: <strong>116045-2099</strong><br />Email: info@buscatusonido.com <strong></p></td></tr></table></div></body></html>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("buscatusonido.org@gmail.com", "Romina2021");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }

        public static void EnviarMailConfirmacionCompra(string destinatario, string mensaje)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                var texto = "Tu compra fue realizada con éxito, en breve estaremos enviando tu pedido";

                mail.From = new MailAddress("buscatusonido.org@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Confirmación de Compra";
                mail.Body = $"<!DOCTYPE html><html lang='en'><body style='width: 80 %; '><div width='500px' style='width: 85%; display: flex; justify-content: center; margin: 10% auto; background-color:#F0195D;'><table align='center' ><thead><tr><td><font face='Mistral' size='30'>Busca Tu Sonido</font></td></tr><tr><td><h2>{texto}</h2></td></tr></thead><TBody><tr><td colspan='3'>{mensaje}</td></tr></TBody><tr></tr><tr><tr></tr></tr><tr><td><h3>Ante cualquier duda Contactanos:</h3><p>Teléfono: <strong>116045-2099</strong><br />Email: info@buscatusonido.com <strong></p></td></tr></table></div></body></html>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("buscatusonido.org@gmail.com", "Romina2021");

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
