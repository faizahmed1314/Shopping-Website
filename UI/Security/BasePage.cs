using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Security
{
    public abstract class BasePage: WebViewPage
    {

        public CustomPrinciple CurrentUser {
            get
            {
                return HttpContext.Current.User as CustomPrinciple;
            }
        }

    }
    public abstract class BasePage<TModel> : WebViewPage<TModel>
    {

        public CustomPrinciple CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrinciple;
            }
        }

    }
}