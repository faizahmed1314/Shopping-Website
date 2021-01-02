using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Security;

namespace UI.Areas.User.Controllers
{
    //[CustomAuthenticationFilter]
    //[CustomAuthorizationFilter(Roles = "user")]

    public class BaseController : Controller
    {
        // GET: User/Base
        public CustomPrinciple CurrentUser
        {
            get
            {
                return HttpContext.User as CustomPrinciple;
            }
        }
    }
}