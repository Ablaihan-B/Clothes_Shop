using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_DOT_NET.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        /// 
        /// Injecting Role Manager
        /// 
        /// 
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }






        public async Task<IActionResult> Update(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role != null)
                return View(role);
            else
                return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> Update(string id, string name)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    role.Name = name;
                    //role.UserName = email;
                }
                else
                    ModelState.AddModelError("", "Name cannot be empty");

       

                if (!string.IsNullOrEmpty(name))
                {
                    IdentityResult result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                        return RedirectToAction("Index");

                }
            }
            else
                ModelState.AddModelError("", "Role Not Found");
            return View(role);
        }





        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            await roleManager.DeleteAsync(role);

            return RedirectToAction("Index");

        }
    }
}