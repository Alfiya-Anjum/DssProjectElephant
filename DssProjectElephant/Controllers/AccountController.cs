using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DssProjectElephant.Data;
using DssProjectElephant.ViewModels;
using DssProjectElephant.Models;

namespace DssProjectElephant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContent _context;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ApplicationDbContent context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = _userManager.FindByEmailAsync(loginViewModel.EmailAddress).Result;

            if (user != null)
            {
                // User is found, check password
                var passwordCheck = _userManager.CheckPasswordAsync(user, loginViewModel.Password).Result;
                if (passwordCheck)
                {
                    // Password correct, sign in
                    var result = _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }
                // Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }
            // User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }
    }
}


        //[HttpGet]
        //public IActionResult Register()
        //{
        //    var response = new RegisterViewModel();
        //    return View(response);
        //}

        //[HttpPost]
        //public IActionResult Register(RegisterViewModel registerViewModel)
        //{
        //    if (!ModelState.IsValid) return View(registerViewModel);

        //    var user = _userManager.FindByEmailAsync(registerViewModel.EmailAddress).Result;
        //    if (user != null)
        //    {
        //        TempData["Error"] = "This email address is already in use";
        //        return View(registerViewModel);
        //    }

        //    var newUser = new AppUser()
        //    {
        //        Email = registerViewModel.EmailAddress,
        //        UserName = registerViewModel.EmailAddress
        //    };
        //    var newUserResponse = _userManager.CreateAsync(newUser, registerViewModel.Password).Result;

        //    if (newUserResponse.Succeeded)
        //        _userManager.AddToRoleAsync(newUser, UserRoles.User).Wait();

        //    return RedirectToAction("Index", "Race");
        //}

        //[HttpGet]
        //public IActionResult Logout()
        //{
        //    _signInManager.SignOutAsync().Wait();
        //    return RedirectToAction("Index", "Race");
        //}

        //[HttpGet]
        //[Route("Account/Welcome")]
        //public IActionResult Welcome(int page = 0)
        //{
        //    if (page == 0)
        //    {
        //        return View();
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult GetLocation(string location)
        //{
        //    if (location == null)
        //    {
        //        return Json("Not found");
        //    }
        //    var locationResult = _locationService.GetLocationSearch(location).Result;
        //    return Json(locationResult);
        //}
    


    
