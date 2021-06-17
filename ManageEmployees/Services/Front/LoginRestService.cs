using Domain.Helpers;
using Domain.ViewModels.Employee;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Domain.Dtos.Employee;
using Domain.Interfaces.Front.Services;
using Domain.ViewModels.Login;

namespace Services.Front
{
    public class LoginRestService : ILoginRestService
    {
        private readonly WebAPIConfig _webAPIConfig;

        public LoginRestService(IOptions<WebAPIConfig> config)
        {
            _webAPIConfig = config.Value;
        }      
       

        public async Task<QueryResult<string>> Login(LoginViewModel login)
        {
            RestClient client = new RestClient(_webAPIConfig.URL);
            RestRequest request = new RestRequest("api/login/login", Method.POST);            
            request.AddJsonBody(login);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse<string> response = await client.ExecuteAsync<string>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new QueryResult<string>
                {
                    Succeeded = true,
                    Result = response.Data,
                    Message = "Login com sucesso!"
                };
            }

            return new QueryResult<string>
            {
                Succeeded = false,
                Result = response.Data,
                Message = "Usuário ou senhas inválidos!"
            };
        }
  
    }
}
