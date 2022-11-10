using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_MainProject.Services.Model
{
    public class RequestModel
    {
        public string ApiUrl { get; set; } = ServicesConstant.ApiUrl;
        public ServicesConstant.Crud Operation { get; set; } = ServicesConstant.Crud.GET;
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
