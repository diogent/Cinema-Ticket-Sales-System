using AutoMapper;
using CinemaTicketSalesBusinessLogic.Interfaces;
using CinemaTicketSalesBusinessLogic.Manager;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesSystem.Errors_Handler;
using CinemaTicketSalesSystem.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CinemaTicketSalesSystem.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IUserService _userService;
        private IMapper _mapper;
        public AdminController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager,
            IUserService userService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult SetRoles()
        {
            return View(_userManager.Users);
        }

        [HttpGet]
        public ActionResult SetRoleToUser(string id)
        {
            var user = getUsersList(id);
            user.Roles = getRolesList();
            return View(user);
        }

        [HttpPost]
        public ActionResult AddRoleToUser(UsersViewModel usersViewModel)
        {
            var _user = _userManager.FindById(usersViewModel.Id);
            var _role = _roleManager.FindByName(usersViewModel.SelectedRole);

            var result = _userManager.AddToRole(_user.Id, usersViewModel.SelectedRole);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("SetRoles");
        }


        /// <summary>
        /// This method allows to map RoleModel into RoleViewModel
        /// </summary>
        /// <returns></returns>
        private IEnumerable<RoleViewModel> getRolesList()
        {
            var roles = _userService.GetRoles();
            var rolesList = _mapper.Map<IEnumerable<RoleModel>, IEnumerable<RoleViewModel>>(roles);
            return rolesList;
        }

        /// <summary>
        /// Gets Users info for update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private UsersViewModel getUsersList(string id)
        {
            var usersForMap = _userService.GetUserInfo(id);
            var usersInfo = _mapper.Map<UserModel, UsersViewModel>(usersForMap);
            return usersInfo;
        }
    }
}