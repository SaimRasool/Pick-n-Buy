using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Pick_n_Buy.Models;
using Pick_n_Buy.BLL;
using System.Net;
using System.Web.Security;

namespace Pick_n_Buy.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(MdlAccount mdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BLL_User obj = new BLL_User();
                    obj.bllRegisterUser(mdl);
                    return RedirectToAction("Login", "Account");
                }
                else
                    return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MdlAccount mdl)
        {
            try
            {
                if (mdl.Email != null && mdl.Password != null)
                {
                    BLL_User obj = new BLL_User();
                    MdlAccount Rtn = obj.bllLoginUser(mdl);
                    if (Rtn.Email != null && Rtn.Password != null)
                    {
                        FormsAuthentication.SetAuthCookie(mdl.Email, true);
                        if (Rtn.IsAdmin == 1)
                            return RedirectToAction("Index", "Admin");
                        else
                        {
                            Session["UserID"] = Rtn.ID;
                            Session["Order"] = null;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "The User Name or Password is Invalid");
                        return View(mdl);
                    }
                }
                else
                    return View();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        //
        // POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(MdlAccount model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }

        //    return View(model);
        //}




    }
}