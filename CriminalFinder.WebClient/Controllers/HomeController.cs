using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CriminalFinder.WebClient.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;

namespace CriminalFinder.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.Email));  // replace with valid value 
                message.From = new MailAddress("mainuddin.test@gmail.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.Name, "mainuddin.test@gmail.com", model.Message);
                message.IsBodyHtml = true;
                try
                {
                    if (model.Uploads != null && model.Uploads.Count > 0)
                    {
                        foreach (HttpPostedFileBase uploadedFile in model.Uploads)
                        {
                            message.Attachments.Add(new Attachment(uploadedFile.InputStream, Path.GetFileName(uploadedFile.FileName)));
                        }
                    }
                }
                catch { }
                
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}