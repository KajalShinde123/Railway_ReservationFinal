using Railway_Reservation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Railway_Reservation.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext(); 
   public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult Index()
        {
           

            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
            //return View();
            // email notfication
            MailMessage mm = new MailMessage("railwayreservationsystemmail@gmail.com", u.Email);

            mm.Subject = "Welcome to Railway Reservation System ";
            mm.Body = "This is your password :" + u.Password.ToString()+"   and this is Username : "+u.Email.ToString()+" you can log in now in application ";
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("railwayreservationsystemmail@gmail.com", "chfxpbtcfjfobhlv");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;

            smtp.Send(mm);

            ViewBag.message = "Thank you for Connecting with us!Your password has been sent to your regsitered mail id  ";

            return RedirectToAction("Index");
        }
        public ActionResult afterlogin()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Login(string email,string password)
        {
            if (ModelState.IsValid)
            {




               // var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["UserId"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("afterlogin");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(User u)
        {
            if (ModelState.IsValid)
            {




                // var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(u.Email) && s.Password.Equals(u.Password)&& s.Role.Equals(u.Role)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["UserId"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("Updatetrain");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("AdminLogin");
                }
            }

            return View();
        }



        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult reserve()
        {
            return View();
        }

        [HttpPost]
        public ActionResult reserve(Reservation r)
        {

            db.Reservations.Add(r);
            db.SaveChanges();
            return View();
            //string paymentId = Request.Params["rzp_paymentid"];


        }
        public ActionResult cancel()
        {
            return View();
        }


        public ActionResult Updatetrain()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Updatetrain(TrainDetails t)
        {

            db.TrainDetails.Add(t);
            db.SaveChanges();
            return View();

        }
        public ActionResult Index1(string searching)
        { 
            return View(db.TrainDetails.Where(x => x.DestinationStation.Contains(searching) || searching == null).ToList());
        }
        public ActionResult viewticket(string searching1) 
        {
            return View(db.Reservations.Where(y => y.Res_Name.Contains(searching1)||searching1==null).ToList());
        }
       

    }
}
