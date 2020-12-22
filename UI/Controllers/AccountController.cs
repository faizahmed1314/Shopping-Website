using DomainModels.ViewModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        IUnitOfWork uow;
        public AccountController()
        {
            uow = new UnitOfWork();
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
                var user=uow.AuthenticationRepository.ValidateUser(model);
                if (user != null)
                {
                    if (user.Roles.Contains("Admin"))
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
    }
}