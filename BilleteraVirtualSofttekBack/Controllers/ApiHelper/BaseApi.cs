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

    /// <summary>
    /// A utility class for making http requests to a specified API.
    /// </summary>
    public class BaseApi : ControllerBase
    {

        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Initializes a new instance of the BaseApi class.
        /// </summary>
        /// <param name="httpClient">An instance of the IHttpClientFactory for creating HTTP clients.</param>
        public BaseApi(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Posts data to a specified API.
        /// </summary>
        /// <param name="controllerName">The url of the api.</param>
        /// <param name="model">Data to be posted to the API endpoint</param>
        /// <param name="token">An authentication token.</param>
        /// <returns>
        /// IActionResult with the response content received from the API.
        /// </returns>
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
