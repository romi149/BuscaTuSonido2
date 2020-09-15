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
        public static void EnviarMail(string destinatario, string asunto, string mensaje)
        {
            var fromAddress = new MailAddress("buscatusonido.org@gmail.com", "From Name");
            var toAddress = new MailAddress(destinatario, "To Name");
            const string fromPassword = "Adrian1234";
            string subject = asunto;
            string body = mensaje;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
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
