using Auth_Ex_Identity.Models.Dto;
using Auth_Ex_Identity.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Ex_Identity.Controllers
{
    [Authorize]
    public class AspNetUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AspNetUserController(
                UserManager<AppUser> userManager,
                SignInManager<AppUser> signInManager,
                RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {

            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {

            return View();
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterSave(RegisterDto registerDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AppUser user = new AppUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,


                        UserName = registerDto.UserName,
                        Email = registerDto.Email,
                        Name = registerDto.Name,
                        Surname = registerDto.Surname,
                        PhoneNumber = registerDto.PhoneNumber,
                        BirthDate = registerDto.BirthDate,
                        Gender = registerDto.Gender,

                        IsDeleted = false,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);

                    if (result.Succeeded)
                    {
                        var roleExist = await this._roleManager.RoleExistsAsync("User");

                        if (!roleExist)
                        {

                            await this._roleManager.CreateAsync(new IdentityRole("User"));
                            await this._roleManager.CreateAsync(new IdentityRole("Admin"));

                        }

                        if (registerDto.Email == "alandonati7@gmail.com")
                        {
                            await this._userManager.AddToRoleAsync(user, "Admin");

                            return RedirectToAction("Login");
                        }
                        else
                        {
                            await this._userManager.AddToRoleAsync(user, "User");
                            return RedirectToAction("Login");
                        }

                    }
                    else
                    {
                     
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View("Register");
        }
    }
}
