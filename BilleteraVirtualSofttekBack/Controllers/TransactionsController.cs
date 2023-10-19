using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BilleteraVirtualSofttekBack.Controllers
{
    [Route("api")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionService _service;
        private readonly ILogger<TransactionsController> _logger;
        //private readonly ITransactionValidator _validator;

        /// <summary>
        /// Initializes an instance of TransactionController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An ITransactionService.</param>
        /// <param name="logger">An ILogger.</param>
        public TransactionsController(ITransactionService service, ILogger<TransactionsController> logger)
        {
            _service = service;
            _logger = logger;

        }

        /// <summary>
        /// Gets all Transactions adding pagination.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of Transactions if successful.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("transactions")]
        public async Task<IActionResult> GetAllTransactions([FromQuery] int page = 1, [FromQuery] int units = 10)
        {
            /*
            #region Validations           
            var validation = _validator.GetAllTransactionsValidator(page, units);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var transactions = await _service.GetAllTransactionsAsync(page, units);

            _logger.LogInformation("All Transactions were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, transactions);

        }

        /// <summary>
        /// Gets a Transaction by their ID.
        /// </summary>
        /// <param name="id">ID of the Transaction to get.</param>
        /// <returns>
        /// 200 OK response with the Transaction if found.
        /// |
        /// 404 Not Found response if no Transaction is found.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("transaction/{id:int}")]
        public async Task<IActionResult> GetTransaction([FromRoute] int id)
        {
            /*
            #region Validations
            var validation = _validator.GetTransactionValidator(id);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var transaction = await _service.GetTransactionByIdAsync(id);

            /*
            var error = _validator.GetTransactionError(Transaction, id);
            if (error != null)
            {
                return error;
            }
            */

            _logger.LogInformation($"Transaction was retrieved, transaction = {transaction}.");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, transaction);

        }

        /// <summary>
        /// Creates a new Transaction.
        /// </summary>
        /// <param name="dto">Transaction data in a DTO.</param>
        /// <returns>
        /// 201 Created response if Transaction creation is successful.
        /// |
        /// 400 Bad Request response if Transaction creation fails.
        /// |
        /// 409 Conflict if Transaction was found in the database.
        /// </returns>

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("transaction/create")]
        public async Task<IActionResult> CreateTransaction(TransactionCreateDto dto)
        {

            await _service.CreateTransactionAsync(dto);

            _logger.LogInformation($"Transaction was created, dto = {dto}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The Transaction was created!");

        }

        /// <summary>
        /// Updates an existing Transaction by their ID.
        /// </summary>
        /// <param name="id">ID of the Transaction to update.</param>
        /// <param name="dto">Updated Transaction data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if Transaction update is successful.
        /// |
        /// 400 Bad Request response if Transaction update fails.
        /// </returns>

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("transaction/{id:int}")]
        public async Task<IActionResult> UpdateTransaction(int id, TransactionUpdateDto dto)
        {

            /*
            #region Validations
            var validation = await _validator.UpdateTransactionValidator(id, dto);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var result = await _service.UpdateTransaction(dto);

            /*
            #region Errors
            var error = _validator.UpdateError(result, dto);
            if (error != null)
            {
                return error;
            }
            #endregion
            */

            _logger.LogInformation($"Transaction was properly updated, dto = {dto}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "Transaction was properly updated!");

        }

        /// <summary>
        /// Deletes a Transaction by their ID.
        /// </summary>
        /// <param name="id">ID of the Transaction to delete.</param>
        /// <returns>
        /// 204 No Content response if Transaction deletion is successful.
        /// |
        /// 404 Not Found response if Transaction deletion fails.
        /// </returns>

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("transaction/{id:int}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
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

            var result = await _service.DeleteTransactionAsync(id);

            /*
            #region Errors
            var error = _validator.DeleteGetUserValidator(id, result);
            if (error != null)
            {
                return error;
            }
            #endregion
            */

            _logger.LogInformation($"Transaction was deleted, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The Transaction was deleted!");

        }

    }
}
