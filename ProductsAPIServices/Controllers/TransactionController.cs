using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TransactionAPIServices.Model;

namespace ProductsAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly IConfiguration _configruation;
        private readonly IConfig _config;
        public TransactionController(IConfiguration configruation,IConfig config)
        {
            _configruation = configruation;
            _config = config;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransactionModel value)
        {

            try
            {
                var idTransaction = Common.DataLayer.TransactionData.TransactionAdd(_config, value.AccountID, value.InitialLimit);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                Config _config = new Config(_configruation);
                var Transactions = Common.DataLayer.TransactionData.TransactionGet(_config);

                return new OkObjectResult(Transactions);
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}

