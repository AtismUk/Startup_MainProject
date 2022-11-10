using Startup_MainProject.Services.Model;
using Startup_MainProject.Services.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_MainProject.Services.Operation.IOperation
{
    public interface IBaseServices : IDisposable
    {
        Task<ResponseDto> SendAsync<T>(RequestModel request);

    }
}
