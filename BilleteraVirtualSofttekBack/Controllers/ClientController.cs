using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BilleteraVirtualSofttekBack.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _service;
        private readonly ILogger<ClientController> _logger;
        //private readonly IClientValidator _validator;

        /// <summary>
        /// Initializes an instance of ClientController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IClientService.</param>
        /// <param name="logger">An ILogger.</param>
        public ClientController(IClientService service, ILogger<ClientController> logger)
        {
            _service = service;
            _logger = logger;
           
        }

        /// <summary>
        /// Gets all clients adding pagination.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of clients if successful.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("clients")]
        public async Task<IActionResult> GetAllClients([FromQuery] int page = 1, [FromQuery] int units = 10)
        {
            /*
            #region Validations           
            var validation = _validator.GetAllClientsValidator(page, units);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var clients = await _service.GetAllClientsAsync(page, units);

            _logger.LogInformation("All clients were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, clients);

        }

        /// <summary>
        /// Gets a client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to get.</param>
        /// <returns>
        /// 200 OK response with the client if found.
        /// |
        /// 404 Not Found response if no client is found.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("client/{id:int}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            /*
            #region Validations
            var validation = _validator.GetClientValidator(id);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var client = await _service.GetClientByIdAsync(id);

            /*
            var error = _validator.GetClientError(client, id);
            if (error != null)
            {
                return error;
            }
            */

            _logger.LogInformation($"Client was retrieved, id = {id}.");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, client);

        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="dto">Client data in a DTO.</param>
        /// <returns>
        /// 201 Created response if client creation is successful.
        /// |
        /// 400 Bad Request response if client creation fails.
        /// |
        /// 409 Conflict if client was found in the database.
        /// </returns>

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("client/register")]
        public async Task<IActionResult> CreateClient(ClientCreateDto dto)
        {

            //It creates the client
            var flag = await _service.CreateClientAsync(dto);

            /*
            var validationError = _validator.CreateUserValidator(dto, flag);
            if (validationError != null)
            {
                return validationError;
            }
            */

            _logger.LogInformation($"Client was created, Email = {dto.Email}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The client was created!");

        }

        /// <summary>
        /// Updates an existing client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to update.</param>
        /// <param name="dto">Updated client data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if client update is successful.
        /// |
        /// 400 Bad Request response if client update fails.
        /// </returns>

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("client/{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, ClientUpdateDto dto)
        {

            /*
            #region Validations
            var validation = await _validator.UpdateClientValidator(id, dto);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var result = await _service.UpdateClient(dto);

            /*
            #region Errors
            var error = _validator.UpdateError(result, dto);
            if (error != null)
            {
                return error;
            }
            #endregion
            */

            _logger.LogInformation($"Client was properly updated, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "Client was properly updated!");

        }

        /// <summary>
        /// Deletes a client by their ID.
        /// </summary>
        /// <param name="id">ID of the client to delete.</param>
        /// <returns>
        /// 204 No Content response if client deletion is successful.
        /// |
        /// 404 Not Found response if client deletion fails.
        /// </returns>

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("client/{id:int}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            /*
            #region Validations
            var validation = _validator.DeleteGetUserValidator(id);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var result = await _service.DeleteClientAsync(id);

            /*
            #region Errors
            var error = _validator.DeleteGetUserValidator(id, result);
            if (error != null)
            {
                return error;
            }
            #endregion
            */

            _logger.LogInformation($"Client was deleted, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The client was deleted!");

        }

    }
}
