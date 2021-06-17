using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManageEmployees.Models;
using Domain.Interfaces.Front.Services;
using Domain.ViewModels.Employee;
using Domain.ViewModels;
using Domain.Constants;

namespace ManageEmployees.Controllers
{

    public class EmployeeController : Controller
    {        
        private readonly IEmployeeRestService _employeeRestService;

        public EmployeeController(IEmployeeRestService employeeRestService)
        {            
            _employeeRestService = employeeRestService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string token = Request.Cookies["JwT"];
            return View(await _employeeRestService.GetAll(token));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string token = Request.Cookies["JwT"];
                    var result = await _employeeRestService.Post(token, model);
                    if (result.Succeeded)
                    {
                        return Redirect(nameof(Index));
                    }
                    else
                    {
                        ViewBag.alerts = new AlertViewModel { Type = GeneralConstants.ERROR, Text = result.Message };
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {                
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string token = Request.Cookies["JwT"];
            var model = await _employeeRestService.Get(token, id);
            return View(new EmployeeEditViewModel { Name = model.Name, Password = model.Password, EmployeeNumber = model.EmployeeNumber, LeaderName = model.LeaderName, Surname = model.Surname, Phone = model.Phone, Email = model.Email, Id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string token = Request.Cookies["JwT"];
                    var result = await _employeeRestService.Put(token, model);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.alerts = new AlertViewModel { Type = GeneralConstants.ERROR, Text = result.Message };
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {               
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                string token = Request.Cookies["JwT"];
                var result = await _employeeRestService.Delete(token, Id);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.alerts = new AlertViewModel { Type = GeneralConstants.ERROR, Text = result.Message };

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {                
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
