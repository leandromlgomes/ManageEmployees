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

namespace Services.Front
{
    public class EmployeeRestService : IEmployeeRestService
    {
        private readonly WebAPIConfig _webAPIConfig;

        public EmployeeRestService(IOptions<WebAPIConfig> config)
        {
            _webAPIConfig = config.Value;
        }

        public async Task<EmployeeEditViewModel> Get(string token, int id)
        {
            var employee = new EmployeeEditViewModel();

            RestClient client = new RestClient(_webAPIConfig.URL);
            RestRequest request = new RestRequest("api/employee/{id}", Method.GET);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            request.AddParameter("id", id, ParameterType.UrlSegment);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse<EmployeeResponseDomainModel> response = await client.ExecuteAsync<EmployeeResponseDomainModel>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                employee = new EmployeeEditViewModel { Email = response.Data.Email, Id = response.Data.Id, Phone = response.Data.Phone, Name = response.Data.Name };
            }

            return employee;
        }

        public async Task<EmployeeViewModel> GetAll(string token)
        {
            var employeeList = new List<EmployeeResponseDomainModel>();

            RestClient client = new RestClient(_webAPIConfig.URL);
            RestRequest request = new RestRequest("api/employee", Method.GET);
            //client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse<List<EmployeeResponseDomainModel>> response = await client.ExecuteAsync<List<EmployeeResponseDomainModel>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = response.Data;
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeViewModel.Employees = result;

                return employeeViewModel;
            }
            else
            {
                var teste = new EmployeeViewModel { Employees = new List<EmployeeResponseDomainModel>() };
                for (int i = 0; i < 10; i++)
                {
                    teste.Employees.Add(new EmployeeResponseDomainModel { Id = i, Email = "Email" + i, Name = "Nome" + i });
                }
                return teste;
            }

            return new EmployeeViewModel { Employees = new List<EmployeeResponseDomainModel>() };
        }

        public async Task<QueryResult<EmployeeResponseDomainModel>> Post(string token, EmployeeCreateViewModel model)
        {
            RestClient client = new RestClient(_webAPIConfig.URL);
            RestRequest request = new RestRequest("api/employee", Method.POST);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddJsonBody(model);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse<EmployeeResponseDomainModel> response = await client.ExecuteAsync<EmployeeResponseDomainModel>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new QueryResult<EmployeeResponseDomainModel>
                {
                    Succeeded = true,
                    Result = response.Data,
                    Message = "Funcionário cadastrado com sucesso!"
                };
            }

            return new QueryResult<EmployeeResponseDomainModel>
            {
                Succeeded = false,
                Result = response.Data,
                Message = "Erro ao cadastrar Funcionário!"
            };
        }

        public async Task<QueryResult<EmployeeResponseDomainModel>> Put(string token, EmployeeEditViewModel model)
        {
            RestClient client = new RestClient(_webAPIConfig.URL);
            RestRequest request = new RestRequest("api/employee", Method.PUT);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));

            request.AddJsonBody(model);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse<EmployeeResponseDomainModel> response = await client.ExecuteAsync<EmployeeResponseDomainModel>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new QueryResult<EmployeeResponseDomainModel>
                {
                    Succeeded = true,
                    Result = response.Data,
                    Message = "Funcionário editado com sucesso."
                };
            }

            return new QueryResult<EmployeeResponseDomainModel>
            {
                Succeeded = false,
                Result = response.Data,
                Message = response.ErrorMessage
            };
        }

        public async Task<QueryResult<bool>> Delete(string token, int Id)
        {
            RestClient client = new RestClient(_webAPIConfig.URL);
            RestRequest request = new RestRequest("api/employee/{id}", Method.DELETE);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token));
            request.AddParameter("id", Id, ParameterType.UrlSegment);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse<bool> response = await client.ExecuteAsync<bool>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return new QueryResult<bool>
                {
                    Succeeded = true,
                    Message = "Funcionário deletado com sucesso."
                };
            }

            return new QueryResult<bool>
            {
                Succeeded = false,
                Message = response.ErrorMessage
            };
        }
    }
}
