using Newtonsoft.Json;
using Startup_MainProject.Services.ModelDto;
using Startup_MainProject.Services.Operation.IOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Startup_MainProject.Services.Operation
{
    public class CrudOperation : ICrudOperation
    {
        private IBaseServices _base;
        public CrudOperation(IBaseServices services)
        {
            _base = services;
        }
        public Task<ResponseDto> DeleteModel(int Id, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdtDto>> GetAllModel()
        {
            var res = await _base.SendAsync<ResponseDto>(new()
            {
                ApiUrl = ServicesConstant.ApiUrl + ServicesConstant.UriController,
                Operation = ServicesConstant.Crud.GET,
                AccessToken = "",
            });
            return JsonConvert.DeserializeObject<List<AdtDto>>(res.Data.ToString());
        }

        public Task<ResponseDto> GetModelById(int Id, string token)Add new ability
        {
            return _base.SendAsync<ResponseDto>(new()
            {
                ApiUrl = ServicesConstant.ApiUrl + ServicesConstant.UriController,
                Operation = ServicesConstant.Crud.GET,
                AccessToken = ""
            });
        }

        public Task<ResponseDto> UpdateModel(AdtDto adt, string token)
        {
            throw new NotImplementedException();
        }
    }
}
