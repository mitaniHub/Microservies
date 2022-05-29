using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataLayer
{
    public interface IConfig
    {
        public string SqlConnectionString { get;  }
    }
}
