using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Startup_MainProject.Services.Model;
using Startup_MainProject.Services.ModelDto;
using Startup_MainProject.Services.Operation.IOperation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Startup_MainProject.Services.Operation
{
    public class BaseServices : IBaseServices
    {
        private IHttpClientFactory _factory;
        private ResponseDto _response;
        public BaseServices(IHttpClientFactory httpClientFactory)
        {
            _factory = httpClientFactory;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<ResponseDto> SendAsync<T>(RequestModel request)
        {
            try
            {
                var client = _factory.CreateClient();
                HttpRequestMessage mes = new();
                mes.Headers.Add("Accept", "json/application");
                mes.RequestUri = new Uri(request.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                switch (request.Operation)
                {
                    case ServicesConstant.Crud.POST:
                        mes.Method = HttpMethod.Post;
                        break;
                    case ServicesConstant.Crud.PUT:
                        mes.Method = HttpMethod.Put;
                        break;
                    case ServicesConstant.Crud.DELETE:
                        mes.Method = HttpMethod.Delete;
                        break;
                    default:
                        mes.Method = HttpMethod.Get;
                        break;
                }
                if (request.Data != null)
                {
                    mes.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }
                if (!string.IsNullOrEmpty(request.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.AccessToken);
                }

                var responseFromApi = await client.SendAsync(mes);
                var res = await responseFromApi.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseDto>(res);
            }
            catch (Exception ex)
            {
                _response = new()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { ex.Message.ToString() },
                    Massage = "Error" 

                };
                return _response;
            }
        }
    }
}
