using API;
using Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Services;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class EmployeeTest
    {
        private readonly HttpClient _cliente;
        private IUtilitiesService _utilities;

        public EmployeeTest()
        {
            _utilities = new UtilitiesService();
            var server = new TestServer(new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>());
            _cliente = server.CreateClient();
            _cliente.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _utilities.GenerateJSONWebToken());
        }
        
        [TestMethod]
        public async Task GetAllEmployees()
        {

            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/employee");

            // Act
            var response = await _cliente.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [TestMethod]
        public async Task GetEmployeeById()
        {

            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/employee/4");

            // Act
            var response = await _cliente.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        
        [TestMethod]
        public async Task PostEmployee()
        {

            // Arrange
            var dto = new Domain.Entities.EmployeeEntity() { Name = "Leandro", Email = "leandro@gmail.com", Phone = "999323333", Password = "Pok3r0m", EmployeeNumber = "123332211", Surname = "Marcelino" };
            var json = JsonConvert.SerializeObject(dto);

            // Act
            HttpContent employee = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _cliente.PostAsync("api/employee", employee);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
