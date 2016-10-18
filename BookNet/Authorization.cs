using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookNet
{
    public enum Roles
    {
        Admin
    }

    public class AuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userAuth = httpContext.Session["userAuth"];

            return (userAuth != null && Roles.Split(',').Contains(userAuth.ToString()));
        }
    }
}