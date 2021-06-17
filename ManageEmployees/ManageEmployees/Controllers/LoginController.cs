using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManageEmployees.Models;
using Domain.Interfaces;
using Domain.ViewModels.Login;
using Microsoft.AspNetCore.Http;
using Domain.Interfaces.Front.Services;

namespace ManageEmployees.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUtilitiesService _utilities;
        private readonly ILoginRestService _service;
        public LoginController(IUtilitiesService utilities, ILoginRestService service)
        {
            _utilities = utilities;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var token = _service.Login(model);
            if (token.Result.Succeeded)
            {                
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddHours(1);
                HttpContext.Response.Cookies.Append("JwT", token.Result.Result);

                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
