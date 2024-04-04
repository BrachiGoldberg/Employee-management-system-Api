using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController : ControllerBase
    {

        [HttpPost]
        public ActionResult<string> PostEmil()
        {
            MailMessage message = new MailMessage();

            // הגדר את נושא ההודעה, גוף HTML, שולח ופרטי נמען
            message.Subject = "New message created by Aspose.Email for .NET";
            message.Body = "<b>This line is in bold.</b> <br/> <br/>" + "<font color=blue>This line is in blue color</font>";
            message.IsBodyHtml = true;
            message.From = new MailAddress("bracha.developer@gmail.com", "Sender Name");
            message.To.Add(new MailAddress("brachig404@gmail.com", "Recipient 1"));

            // ציין קידוד 
            message.BodyEncoding = Encoding.ASCII;

            // צור מופע של מחלקה SmtpClient
            SmtpClient client = new SmtpClient();

            // ציין את מארח הדיוור שלך, שם משתמש, סיסמה, יציאה # ואפשרות אבטחה
            client.Host = "smtp.gmail.com";
            //client.Credentials =
            //    new NetworkCredential(
            //        "bracha.developer@gmail.com", "br326404dev");
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                // שלח את המייל הזה
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "send";
        }
    }
}
