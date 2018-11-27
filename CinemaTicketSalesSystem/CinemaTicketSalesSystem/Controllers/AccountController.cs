using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CinemaTicketSalesSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesBusinessLogic.Manager;
using CinemaTicketSalesBusinessLogic.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using CinemaTicketSalesSystem.Errors_Handler;

namespace CinemaTicketSalesSystem.Controllers
{
    public class AccountController : Controller
    {        
        /// <summary>
        /// Everything that needs the old UserManager property references this now
        /// </summary>
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IUserService _userService;
        private IMapper _mapper;
        public AccountController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager,
            IUserService userService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _mapper = mapper;
        }

        
        /// <summary>
        /// With the help of this property we can use SignIn() and SignOut() methods
        /// </summary>
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
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.returnUrl = returnUrl;
                return View(model);
            }            
            var user = await _userManager.FindAsync(model.Email, model.Password);
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
            return RedirectToAction("Index", "Home");
        }     

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };            
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }

            }
            var _user = await _userManager.FindByEmailAsync(model.Email);
            var _role = await _roleManager.FindByNameAsync("User");
            var setRole = await _userManager.AddToRoleAsync(_user.Id, _role.Name);
            return RedirectToAction("Login", "Account");
        }        
    }
}