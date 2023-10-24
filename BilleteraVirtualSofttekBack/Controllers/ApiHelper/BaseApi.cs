using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BilleteraVirtualSofttekBack.Controllers.ApiHelper
{
    public class BaseApi : ControllerBase
    {

        private readonly IHttpClientFactory _httpClient;


        public BaseApi(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> PostToApi(string controllerName, object model, string token = "")
        {

            var client = _httpClient.CreateClient("useApi");

            //Obtains the token


            if (token != "")
            {
                //removes first bearer format
                token = token.Substring("Bearer ".Length).Trim();
                //Adds token to client
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            }

            var response = await client.PostAsJsonAsync(controllerName, model);

            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");


        }

    }
}
