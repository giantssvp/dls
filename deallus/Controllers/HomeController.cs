using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using deallus.Models;
using System.Net.Mail;

namespace deallus.Controllers
{
    public class HomeController : Controller
    {
        public static string mailServer = "relay-hosting.secureserver.net";
        public static string mailFrom = "info@deallustechnologies.com";
        public static string mailTo = "info@deallustechnologies.com";
        public static string mailPassword = "De@!!us2017";
        /*
        public static string mailServer = "smtp.gmail.com";
        public static string mailFrom = "abcdtes26@gmail.com";
        public static string mailTo = "abcdtes26@gmail.com";
        public static string mailBCC = "abcdtes26@gmail.com";
        public static string mailPassword = "9921642540";
        */

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GST()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult submit_btn_contact(string name, string email, string phone, string requesttype, string message)
        {
            try
            {
                var obj = new db_connect();
                var msg = "";
                obj.Insert(name, email, phone, requesttype, message);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(mailServer);

                mail.From = new MailAddress(mailFrom);
                mail.To.Add(mailFrom);
                mail.Subject = "Contact : " + name + " : " + requesttype;
                mail.IsBodyHtml = true;

                string htmlBody;

                htmlBody = "<html> <head>  </head> <body>" +
                            "<div><img src=\"cid:icon_01\"> </div>" +
                            "<table border=\"1\" style=\"font - family:Georgia, Garamond, Serif; width: 100 %; color: blue; font - style:italic; \"> <tr bgcolor=\"#00FFFF\" align=\"center\"> <th> Name </th> <th> Email </th> <th> Request Type </th> <th> Phone </th> <th> Message </th>  </tr> <tr align=\"center\"> " +
                            "<td>" + name + "</td>" +
                            "<td>" + email + "</td>" +
                            "<td>" + requesttype + "</td>" +
                            "<td>" + phone + "</td>" +
                            "<td>" + message + "</td>" +
                            "</tr> </table> </body> </html> ";


                mail.Body = htmlBody;
                //SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(mailFrom, mailPassword);
                //SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                TempData["AlertMessage"] = "Your details saved successfully, We will get back to you shortly.";
                return RedirectToAction("Contact", "Home");
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('There is some issue while saving the details, please try again, Thanks.')</script>");
                return RedirectToAction("Contact", "Home");
            }
        }
    }
}