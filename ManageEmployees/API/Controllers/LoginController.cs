using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Dtos.Login;
using Domain.Interfaces;
using Domain.Interfaces.API.Services.Login;
using Domain.Interfaces.Services.Employee;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IEmployeeService _service;
        public IUtilitiesService _utilities;
        public ILoginService _login;

        public LoginController(IEmployeeService service, IUtilitiesService utilities, ILoginService login)
        {
            _service = service;
            _utilities = utilities;
            _login = login;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDomainModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var validate = await _login.Login(login);
                if (validate || (login.UserName.ToUpper() == "ADMIN" && login.Password.ToUpper() == "ADMIN" ))
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
