using DomainModels.ViewModels;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Controllers
{
    public class AccountController : BaseController
    {
        //IUnitOfWork _uow;
        public AccountController(IUnitOfWork uow):base(uow)
        {
            //uow = new UnitOfWork();
            //_uow = uow;
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user=_uow.AuthenticationRepository.ValidateUser(model);
                if (user != null)
                {
                    //Login form authentication
                    //For serialize an object to a string we use newtonsoft json

                    string data = JsonConvert.SerializeObject(user);

                    //Create form authentication ticket

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName,
                        DateTime.Now, DateTime.Now.AddMinutes(20), false, data);

                    //encrypt the ticket
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    //Create cookie
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(cookie);



                    if (user.Roles.Contains("admin"))
                     {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new {area="User" });
                    }
                }
                
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult UnAuthorize()
        {
            return View();
        }
    }
}