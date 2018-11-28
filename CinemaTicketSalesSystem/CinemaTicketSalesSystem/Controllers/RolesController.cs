using CinemaTicketSalesBusinessLogic.Manager;
using CinemaTicketSalesSystem.Errors_Handler;
using CinemaTicketSalesSystem.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CinemaTicketSalesSystem.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class RolesController : Controller
    {

        private readonly ApplicationRoleManager _roleManager;        

        public RolesController(ApplicationRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates new Role
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _roleManager.CreateAsync(new ApplicationDbMovies.Models.ApplicationRole
            {
                Name = model.Name,
                Description = model.Description
            });
            if (!result.Succeeded)
                ModelState.AddModelError("", "Something went wrong");
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return RedirectToAction("Index");
            var editRole = new EditRoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return View(editRole);
        }

        /// <summary>
        /// This metod allows administrator to edit existing role
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
                ModelState.AddModelError("", "The role is incorrect");
            role.Description = model.Description;
            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
                ModelState.AddModelError("", "Can't update this role");
            return RedirectToAction("Index");
        }


        /// <summary>
        /// This method allows administrator to delete existing role
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }                
            return RedirectToAction("Index");
        }
    }
}