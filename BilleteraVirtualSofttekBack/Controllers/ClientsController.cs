using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Controllers
{

    /// <summary>
    /// Generates a Controller responsible for client operations and client actions.
    /// </summary>

    [Route("api")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly IClientService _service;
        private readonly ILogger<ClientsController> _logger;

        /// <summary>
        /// Initializes an instance of ClientController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IClientService.</param>
        /// <param name="logger">An ILogger.</param>
        public ClientsController(IClientService service, ILogger<ClientsController> logger)
        {
            _service = service;
            _logger = logger;
           
        }

        /// <summary>
        /// Retrieves a list of clients with pagination support.
        /// </summary>
        /// <param name="page">The page number for pagination</param>
        /// <param name="units">The number of units to display per page.</param>
        /// <returns>
        /// 200 OK response with the list of clients if successful.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 400 Bad Request response if the pagination parameters are invalid.
        /// </returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("clients")]
        public async Task<IActionResult> GetAllClients([FromQuery] int page = 1, [FromQuery] int units = 10)
        {
            if (page < 1 || units < 1)
            {
                _logger.LogInformation($"There was an error in the pagination, page = {page}, units = {units}!");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was an error in the pagination!");
            }

            var clients = await _service.GetAllClientsAsync(page, units);

            _logger.LogInformation("All clients were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, clients);

        }

        /// <summary>
        /// Retrieves a client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to retrieve.</param>
        /// <returns>
        /// 200 OK response with the client if found.
        /// 404 Not Found response if no client is found.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 400 Bad Request response if the client ID is invalid.
        ///</returns>
        
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("client/{id:int}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            if (id <= 0)
            {
                _logger.LogInformation($"The client id was invalid, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The client id is invalid!");
            }

            var client = await _service.GetClientByIdAsync(id);

            if (client == null)
            {
                _logger.LogInformation($"The client was not found, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The client was not found!");
            }

            _logger.LogInformation($"Client was retrieved, id = {id}.");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, client);

        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="dto">Client data in a DTO.</param>
        /// <returns>
        /// 201 Created response if client creation is successful.
        /// 400 Bad Request response if client creation fails.
        /// 401 Unauthorized response if the user is not authenticated.
        /// </returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("client/register")]
        public async Task<IActionResult> CreateClient(ClientCreateDto dto)
        {
            if(dto.Role != ClientRole.Admin && dto.Role != ClientRole.Base)
            {
                _logger.LogInformation($"The client role was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The client role entered is invalid!");
            }

            if (String.IsNullOrEmpty(dto.Email))
            {
                _logger.LogInformation($"The email was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The email entered is invalid!");
            }

            if (String.IsNullOrEmpty(dto.Name))
            {
                _logger.LogInformation($"The name was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The name entered is invalid!");
            }

            if (String.IsNullOrEmpty(dto.Password))
            {
                _logger.LogInformation($"The password was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The entered password is invalid!");
            }

            var flag = await _service.CreateClientAsync(dto);

            if(flag == false)
            {
                _logger.LogInformation($"There was a problem in the creation of the client, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was a problem, the client wasnt created! Email is in use.");
            }

            _logger.LogInformation($"Client was created, Email = {dto.Email}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The client was created!");

        }

        /// <summary>
        /// Updates an existing client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to update.</param>
        /// <param name="dto">Updated client data in a DTO </param>
        /// <returns>
        /// 204 No Content response if client update is successful.
        /// 400 Bad Request response if client update fails due to invalid data.
        /// 404 Not Found response if the client to update is not found.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 403 Forbidden response if the client update is forbidden.
        /// </returns>

        [HttpPut]
        [Authorize(Policy = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("client/{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, ClientUpdateDto dto)
        {

            if(dto.Role != ClientRole.Base && dto.Role != ClientRole.Admin)
            {
                _logger.LogInformation($"The client role was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The client role entered is invalid!");
            }

            if(id != dto.Id)
            {
                _logger.LogInformation($"The entered ids dont match!, dto = {dto}, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The entered ids dont match!");
            }

            if (String.IsNullOrEmpty(dto.Name))
            {
                _logger.LogInformation($"The entered name was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The entered name is invalid!");
            }

            if (String.IsNullOrEmpty(dto.Password))
            {
                _logger.LogInformation($"The entered password was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The entered password is invalid!");
            }

            var flag = await _service.UpdateClient(dto);

            if (flag == false)
            {
                _logger.LogInformation($"There was a problem in the update of the client, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was a problem, the client wasnt updated!");
            }

            _logger.LogInformation($"Client was properly updated, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "Client was properly updated!");

        }
        /// <summary>
        /// Deletes a client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to delete.</param>
        /// <returns>
        /// 204 No Content response if client deletion is successful.
        /// 404 Not Found response if client deletion fails.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 403 Forbidden response if the client deletion is forbidden.
        /// 400 Bad Request response if the client deletion fails due to invalid data.
        /// </returns>

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("client/{id:int}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {

            if (id <= 0)
            {
                _logger.LogInformation($"The client id was invalid, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The client id is invalid!");
            }

            var client = await _service.DeleteClientAsync(id);

            if (client == false)
            {
                _logger.LogInformation($"The client was not found, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The client was not found!");
            }

            _logger.LogInformation($"Client was deleted, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The client was deleted!");

        }

    }
}
