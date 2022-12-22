using CRM_Area_Replace.DTO.Concreate.Account;
using CRM_Area_Replace.Entities.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Area_Replace.WebUI.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        public UserAccount CreateUser
        {
            get
            {
                try
                {
                    return Activator.CreateInstance<UserAccount>();
                }
                catch (Exception ex)
                {

                    throw new InvalidOperationException("Kullanıcı nesnesi oluşturulurken hata oluştu. Kullanıcı nesnesine bağlı nesneleri kontrol edin");
                }
            }
        }
        public AccountController(UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet("{area}/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("{area}/login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new {area = ""});
                }
            }
            return View(login);
        }

        [HttpGet("{area}/register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("{area}/register")]
        public async Task<IActionResult> Register(UserRegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var user = CreateUser;
                user.Email = registerDTO.Email;
                user.UserName = registerDTO.Email;
                var result = await _userManager.CreateAsync(user, registerDTO.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerDTO);
        }
    }
}
