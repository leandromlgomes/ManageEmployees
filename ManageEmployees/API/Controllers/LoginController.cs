using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Dtos.Employee;
using Domain.Interfaces;
using Domain.Interfaces.Services.Employee;
using Domain.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IEmployeeService _service;
        public IUtilitiesService _utilities;

        public LoginController(IEmployeeService service, IUtilitiesService utilities)
        {
            _service = service;
            _utilities = utilities;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var autenticar = true;
                if (autenticar || (login.UserName.ToUpper() == "ADMIN" && login.Password.ToUpper() == "ADMIN" ))
                {
                    return Ok(_utilities.GenerateJSONWebToken());
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }



    }
}
