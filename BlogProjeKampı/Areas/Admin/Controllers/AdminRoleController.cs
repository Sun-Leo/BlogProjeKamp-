using BlogProjeKampı.Areas.Admin.Models;
using EntityLayer.Concrete;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var value = _roleManager.Roles.ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = model.name
                };

                var result=await _roleManager.CreateAsync(appRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var role in result.Errors)
                {
                    ModelState.AddModelError("", role.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value= _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel()
            {
                Id = value.Id,
                name = value.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var value= _roleManager.Roles.Where(x=>x.Id==model.Id).FirstOrDefault();
            value.Name = model.name;
            var result= await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value= _roleManager.Roles.FirstOrDefault(x=>x.Id==id);
            var result=await _roleManager.DeleteAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult UserRoleList()
        {
            var value = _userManager.Users.ToList();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user= _userManager.Users.FirstOrDefault(x=>x.Id==id);
            var roles= _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userroles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();
            foreach (var item in roles) 
            { 
                RoleAssignViewModel mdl = new RoleAssignViewModel();
                mdl.Name = item.Name;
                mdl.RoleID = item.Id;
                mdl.Exists = userroles.Contains(item.Name);
                models.Add(mdl);
            }
           
            return View(models);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }

    }
}
