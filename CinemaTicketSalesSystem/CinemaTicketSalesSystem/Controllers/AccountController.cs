using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CinemaTicketSalesSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;



namespace CinemaTicketSalesSystem.Controllers
{
    public class AccountController : Controller
    {
        //everything that needs the old UserManager property references this now
        private ApplicationUserManager _userManager; 
        public AccountController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
        //With the help of this property we can use SignIn() and SignOut() methods
        private IAuthenticationManager AuthenticationManager        
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.returnUrl = returnUrl;
                return View(model);
            }            
            ApplicationUser user = await _userManager.FindAsync(model.Email, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect.");
                return View(model);
            }

            ClaimsIdentity claim = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            //Removes authentication cookie
            AuthenticationManager.SignOut();

            //Creates authentication cookie
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, claim);

            if (String.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Home");
            return Redirect(returnUrl);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Register");
        }

     

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                
            }
            return RedirectToAction("Login", "Account");
        }
    }
}