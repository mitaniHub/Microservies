using Common.DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Common.DataLayer.Models;
using Microsoft.AspNetCore.Http;

namespace CustomersAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configruation;
        private readonly IConfig _config;
        public CustomersController(IConfiguration configruation,IConfig config)
        {
            _configruation = configruation;
            _config = config;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                HttpContext httpContext = Request.HttpContext;
                string authHeader = httpContext.Request.Headers["Authorization"];
                var customers = CustomerData.CustomerGet(_config);
                if (customers.Count > 0 )
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
                            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                            var Transactions = JsonConvert.DeserializeObject<List<Transaction>>(response.Content.ReadAsStringAsync().Result);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                foreach (var item in customers)
                                {
                                    item.Transactions = Transactions.Where(x=>x.IdCustomer == item.ID).ToList();
                                }
                                return new OkObjectResult(customers);
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                                return Unauthorized();
                            else
                                return BadRequest();
                        }
                    }
                }
                return new OkObjectResult(customers);
               
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
           
        }
    }
}
