using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryProject.Configuration
{

    public interface IApiConfig
    {
        string BaseUrl { get; set; }
    }

    public class ApiConfig : IApiConfig
    {
        public string BaseUrl { get; set; }
    }
}
