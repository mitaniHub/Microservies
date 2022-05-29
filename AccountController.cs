using Common.DataLayer;
using CustomersAPIServices.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configruation;
        private readonly IConfig _config;
        public AccountController(IConfiguration configruation,IConfig config) 
        {
            _configruation = configruation;
            _config = config;
        }
        [HttpPost]
        [Authorize]        
        public IActionResult Post([FromBody] AccountModel value)
        {
            try
            {
                //Config _config = new Config(_configruation);
                HttpContext httpContext = Request.HttpContext;
                string authHeader = httpContext.Request.Headers["Authorization"];
                var idAccount = Common.DataLayer.AccountData.CreateAccount(_config, value.CustomerID);
                if (idAccount > 0 && value.InitialLimit > 0)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        if (httpContext.Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues headerValue))
                        {
                            string token = headerValue;
                            if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer"))
                            {
                                token = token.Substring("Bearer".Length);
                            }
                            client.BaseAddress = new Uri("http://localhost:10002/api/transaction");
                            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                            var payload = new {AccountID = idAccount, InitialLimit = value.InitialLimit };
                            HttpContent content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                return Ok();
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                return Unauthorized();
                            else 
                                return BadRequest();
                        }
                    }
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        
    }
}
