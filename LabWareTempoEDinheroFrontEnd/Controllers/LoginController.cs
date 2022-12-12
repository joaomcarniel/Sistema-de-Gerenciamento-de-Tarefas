using LabWareTempoEDinheroFrontEnd.Models.Authorization;
using LabWareTempoEDinheroFrontEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(User user)
        {
            return View();
        }

        public IActionResult ValidateLogin(User user)
        {
            if (_loginService.IsValidLogin(user))
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}
