using Demo.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Helper
{
    public static class MailSender
    {
        public static string SendMail(MailVM model)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); //دا الايميل الى انا هبعتلو
                smtp.EnableSsl = true;//دا عشان يشفر اى رسايل بيني وبين الايميل الى انا هبعتلو
                smtp.Credentials = new NetworkCredential("elgendya160@gmail.com", "@@@AAA321_321");
                //دا الى المفروض الايمل الى بيبعت الى هوا مثلا بيعبت عل الصفحه واميلو متسجل عليها وانا باخد ايميلو من الصفحه
                smtp.Send("elgendya160@gmail.com", "as8338873@gmail.com", model.Title, model.Message);

                var result = "Mail Sent Successfully";
                return result;
            }
            catch (Exception ex)
            {
                var result = "Faild";
                return result;
            }
        }

    }

}