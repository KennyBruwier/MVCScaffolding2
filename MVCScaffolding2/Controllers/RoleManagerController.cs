using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCScaffolding2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCScaffolding2.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (!String.IsNullOrEmpty(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (TryValidateModel(roleViewModel))
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = roleViewModel.Name
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
            }
            return View(roleViewModel);
        }
    }
}
