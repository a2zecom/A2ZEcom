using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using p.Models;

namespace p.Controllers
{
    public class HomeController : Controller
    {

        
        // GET: Home
        public ActionResult Index()
        {       
            return View();
        }

        public ActionResult SendEmail(emailModel emailModel)
        {
            MailMessage mm = new MailMessage("noreply.atozecommerce@gmail.com", "noreply.atozecommerce@gmail.com"); //info@realbotz.com
            mm.Subject = "Website Inquiry";
            //var body =  "<h1><b>Dear sir,</b></h1>"+ "<br/>" + " " + " " +model.message  + "<br/> <h3>Thanks</h3><br/>" + "<h4>Name :</h4>"+ model.name + " <br/>" + model.email;
            var body = "<p>Dear Sir,</p>" + "<p>We got one inquiry from website.<p>" + "<p>Below is user details.</p>" + "<br/><b>Name:</b> " + emailModel.name + "<br/><b>Email Id:</b> " + emailModel.email + "<br/><b>Mobile No:</b>" + " " + emailModel.mobile + "<br/><b>Subject:</b>" + "  Inquiry <br/><b>Message:-</b></br>" + emailModel.message + "<br/><p>Thanks</p>" + "<p>With Ragards,</p>" + "<p> A To Z E-Commerce Team</p>";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;


            NetworkCredential nc = new NetworkCredential("noreply.atozecommerce@gmail.com", "atoz@123");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = String.Format("Thank You, We Receive Your Message");
            ModelState.Clear();
    
         

            return Json("chamara", JsonRequestBehavior.AllowGet);
        }
    }
}