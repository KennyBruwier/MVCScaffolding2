using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCScaffolding2.Data
{
    public enum CustomRoles
    {
        SuperAdmin,
        Admin,
        Moderator,
        Basic
    }
    public static class ContextSeed
    { 
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(CustomRoles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(CustomRoles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(CustomRoles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(CustomRoles.Basic.ToString()));
        }
    }
}
