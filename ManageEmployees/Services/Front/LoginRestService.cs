using Domain.Helpers;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using RestSharp;
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
            RestRequest request = new RestRequest("api/login", Method.POST);            
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
                Message = "Não foi possivel conectar o servidor ou usuário ou senhas inválidos!"
            };
        }
  
    }
}
