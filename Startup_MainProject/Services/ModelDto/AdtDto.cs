using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_MainProject.Services.ModelDto
{
    public class AdtDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string TypeDeveloper { get; set; }
        public bool IsTypeAd { get; set; }
    }
}
