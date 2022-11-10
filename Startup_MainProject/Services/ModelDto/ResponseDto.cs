using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_MainProject.Services.ModelDto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Data { get; set; }
        public string Massage { get; set; }
        public List<string> Errors { get; set; }
    }
}
