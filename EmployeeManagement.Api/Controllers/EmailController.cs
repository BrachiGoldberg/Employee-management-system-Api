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
    //[Authorize]
    public class EmailController : ControllerBase
    {

        [HttpPost]
        public ActionResult<string> PostEmil()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("bracha.developer@gmail.com", "br326404dev"),
                EnableSsl = true,
            };

            smtpClient.Send("bracha.developer@gmail.com", "brachig404@gmail.com", "subject", "body");
            return Ok();
        }
    }
}
