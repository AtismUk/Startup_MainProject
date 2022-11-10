using Startup_MainProject.Services.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_MainProject.Services.Operation.IOperation
{
    public interface ICrudOperation
    {
        Task<List<AdtDto>> GetAllModel();
        Task<ResponseDto> UpdateModel(AdtDto adt);
        Task<ResponseDto> DeleteModel(int Id);
        Task<ResponseDto> GetModelById(int Id);

    }
}
