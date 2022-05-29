using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.DataLayer
{
    public class Config :IConfig
    {
        #region Properties
        public IConfiguration _configuration;
        public string SqlConnectionString { get { return this._configuration["ConnectionStrings:SqlConnectionString"]; } }
        #endregion
        public Config(IConfiguration configuration)
        {
            _configuration = configuration;            
        }
    }
}
