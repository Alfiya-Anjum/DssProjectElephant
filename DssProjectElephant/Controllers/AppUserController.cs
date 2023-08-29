using DssProjectElephant.Data;
using DssProjectElephant.Models;
using DssProjectElephant.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

public class AppUserController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ApplicationDbContent _context;

    public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContent context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async Task<IActionResult> Users()
    {
        var users = await _context.Users.ToListAsync();
        return View(users);
    }

    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginVM)
    {
        if (!ModelState.IsValid)
        {
            return View(loginVM);
        }

        var user = await _userManager.FindByEmailAsync(loginVM.UserName);

        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }
        TempData["Error"] = "Wrong credentials. Please, try again!";
        return View(loginVM);
    }


    public IActionResult Register()
    {
        
        return View(new RegistrationViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegistrationViewModel registerVM)
    {
        if (ModelState.IsValid)
        {
            var newUser = new AppUser
            {
                UserName = registerVM.Email,
                Email = registerVM.Email,
                
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                
                var signInResult = await _signInManager.PasswordSignInAsync(newUser, registerVM.Password, false, false);

                if (!signInResult.Succeeded)
                {
                    TempData["Error"] = "Unable to sign in user";
                    return View(registerVM);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in newUserResponse.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerVM);
            }
        }

        return View(registerVM);
    }


    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied(string ReturnUrl)
    {
        return View();
    }
}
