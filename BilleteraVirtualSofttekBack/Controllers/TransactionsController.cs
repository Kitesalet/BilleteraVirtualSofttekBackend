using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using BilleteraVirtualSofttekBack.Models.Enums;
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

            if(page < 1 || units < 1)
            {
                _logger.LogInformation($"There was an error in the pagination, page = {page}, units = {units}!");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "There was an error in the pagination!");
            }

            var transactions = await _service.GetAllTransactionsAsync(page, units);

            _logger.LogInformation("All Transactions were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, transactions);

        }

        /// <summary>
        /// Gets all Transactions by account.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of Transactions by account if successful.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("transactions/account/{accountId:int}")]
        public async Task<IActionResult> GetAllTransactionsByAccount(int accountId)
        {

            if (accountId <= 0)
            {
                _logger.LogInformation($"The account id was invalid, id = {accountId}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "The account id is invalid!");
            }

            var transactions = await _service.GetTransactionByAccountAsync(accountId);

            if(transactions == null)
            {
                _logger.LogInformation($"The account was not found, id = {accountId}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.NotFound, "The account was not found!");
            }

            _logger.LogInformation("All Transactions by client were retrieved!");
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
        [Route("transaction/{id:int}")]
        public async Task<IActionResult> GetTransaction([FromRoute] int id)
        {
            if (id <= 0)
            {
                _logger.LogInformation($"The transaction id was invalid, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "The transaction id is invalid!");
            }

            var transaction = await _service.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                _logger.LogInformation($"The transaction was not found, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.NotFound, "The transaction was not found!");
            }

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
        /// 401 Unauthorized
        /// </returns>

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("transaction/create")]
        public async Task<IActionResult> CreateTransaction(TransactionCreateDto dto)
        {

            if (dto.Amount <= 1)
            {
                _logger.LogInformation($"The amount introduced was invalid, dto = {dto}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

            }

            if (dto.Type != TransactionType.Transfer && dto.Type != TransactionType.Withdrawal && dto.Type != TransactionType.Deposit)
            {
                _logger.LogInformation($"The transaction type entered was invalid, dto = {dto}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "The transaction type entered is invalid!");

            }

            var flag = await _service.CreateTransactionAsync(dto);

            if(flag == false)
            {
                _logger.LogInformation($"There was a problem with the transaction creation, dto = {dto}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "There is a problem with the transaction creation, check if the client and the accounts were valid!");
            }

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

            if (dto.Amount <= 1)
            {
                _logger.LogInformation($"The amount introduced was invalid, dto = {dto}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

            }

            if (dto.Type != TransactionType.Transfer && dto.Type != TransactionType.Withdrawal && dto.Type != TransactionType.Deposit)
            {
                _logger.LogInformation($"The transaction type entered was invalid, dto = {dto}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "The transaction type entered is invalid!");

            }

            var flag = await _service.UpdateTransaction(dto);

            if (flag == false)
            {
                _logger.LogInformation($"There was a problem with the transaction update, dto = {dto}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "There is a problem with the transaction update, check if the client and the accounts were valid!");
            }

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

            if(id <= 0)
            {
                _logger.LogInformation($"The transaction id was invalid, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.BadRequest, "The transaction id is invalid!");
            }


            var transaction = await _service.DeleteTransactionAsync(id);

            if (transaction == null)
            {
                _logger.LogInformation($"The transaction was not found, id = {id}");
                return ResponseFactory.CreateSuccessResponse(HttpStatusCode.NotFound, "The transaction was not found!");
            }

            _logger.LogInformation($"Transaction was deleted, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The Transaction was deleted!");

        }

    }
}
