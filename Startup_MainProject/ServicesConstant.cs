using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_MainProject
{
    public static class ServicesConstant
    {
        public static string ApiUrl { get; set; }
        public const string UriController = "Api/Sturtup/";


        public enum Crud
        {
            POST,
            PUT,
            DELETE,
            GET
        }
    }
}
