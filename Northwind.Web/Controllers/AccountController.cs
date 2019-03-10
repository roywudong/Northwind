using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Northwind.Web.Infrastructure.Abstract;
using Northwind.Web.Infrastructure.Concrete;
using Northwind.Web.Models;

namespace Northwind.Web.Controllers
{
  public class AccountController : Controller
  {
    private IAuthProvider authProvider;

    public AccountController(IAuthProvider auth)
    {
      authProvider = auth;
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
      if (ModelState.IsValid)
      {
        if (authProvider.Authenticate(model.UserName, model.Password))
        {
          return Redirect(returnUrl ?? Url.Action("Index", "Customer"));
        }
        else
        {
          ModelState.AddModelError("", "密碼錯誤");
          return View();
        }
      }
      else
      {
        return View();
      }
    }

    [Authorize]
    public ActionResult LogOut()
    {
      FormsAuthentication.SignOut();
      Session.Abandon();
      return RedirectToAction("Login");
    }
  }
}