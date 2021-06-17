using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ManageEmployees.Models;
using Domain.ViewModels.Login;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace ManageEmployees.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUtilitiesService _utilities;
        public LoginController(IUtilitiesService utilities)
        {
            _utilities = utilities;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.UserName.ToUpper() == "ADMIN" && model.Password.ToUpper() == "ADMIN")
            {
                var token = _utilities.GenerateJSONWebToken();

                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddHours(1);
                HttpContext.Response.Cookies.Append("JwT", token);

                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return Redirect("");
            }
        }
    }
}
