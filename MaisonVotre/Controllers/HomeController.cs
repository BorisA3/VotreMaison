using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using MaisonVotre.Models;
using System;

namespace MaisonVotre.Controllers
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
        public ActionResult Afiliado()
        {
            return View();
        }

        public ActionResult Requisitos()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactModel model)
        {


            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                model.SenderEmail = "voitremaison@outlook.es";
                mail.To.Add(new MailAddress(model.SenderEmail));
                mail.Subject = "Your Email Subject";
                mail.Body = string.Format("<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>", model.SenderName, mail.Sender, model.Message);
                mail.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(mail);
                    return RedirectToAction("Contact");
                }
            }
            return View(model);
        }

        public ActionResult SuccessMessage()
        {
            return View();
        }

        public ActionResult GeoLocation()
        {
            return View();
        }

        public ActionResult ContactoComercio()
        {
            return View();
        }
    }
}