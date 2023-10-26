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

    /// <summary>
    /// Generates a Controller responsible for Transactions operations and transaction actions.
    /// </summary>
    /// 
    [Route("api")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionService _service;
        private readonly ILogger<TransactionsController> _logger;

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
        /// Gets all Transactions with optional pagination.
        /// </summary>
        /// <param name="page">Page number for pagination</param>
        /// <param name="units">Number of Transactions per page.</param>
        /// <returns>
        /// 200 OK response with the list of Transactions if succesful.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 400 Bad Request response if the pagination parameters are invalid.
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
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was an error in the pagination!");
            }

            var transactions = await _service.GetAllTransactionsAsync(page, units);

            _logger.LogInformation("All Transactions were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, transactions);

        }

        /// <summary>
        /// Gets all Transactions associated account.
        /// </summary>
        /// <param name="accountId">ID of the account for which to retrieve transactions.</param>
        /// <param name="page">Page number for pagination</param>
        /// <param name="units">Number of Transactions per page.</param>
        /// <returns>
        /// 200 OK response with the list of Transactions with the account if successful.
        /// 400 Bad Request if the account id is invalid.
        /// 404 Not Found if the account doesnt exist.
        /// 401 Unauthorized response if the user is not authenticated.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("transactions/account/{accountId:int}")]
        public async Task<IActionResult> GetAllTransactionsByAccount(int accountId, [FromQuery] int page = 1, [FromQuery] int units = 99)
        {
            if (page < 1 || units < 1)
            {
                _logger.LogInformation($"There was an error in the pagination, page = {page}, units = {units}!");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was an error in the pagination!");
            }

            if (accountId <= 0)
            {
                _logger.LogInformation($"The account id was invalid, id = {accountId}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The account id is invalid!");
            }

            var transactions = await _service.GetTransactionsByAccount(accountId, page, units);

            if(transactions == null)
            {
                _logger.LogInformation($"The account was not found, id = {accountId}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The account was not found!");
            }

            _logger.LogInformation("All Transactions by account were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, transactions);

        }

        /// <summary>
        /// Gets all Transactions associated client.
        /// </summary>
        /// <param name="clientId">ID of the client for which to retrieve transactions.</param>
        /// <param name="page">Page number for pagination</param>
        /// <param name="units">Number of Transactions per page.</param>
        /// <returns>
        /// 200 OK response with the list of Transactions with the client if successful.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 404 Not Found response if the specified account does not exist.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("transactions/client/{clientId:int}")]
        public async Task<IActionResult> GetAllTransactionsByClient(int clientId, [FromQuery] int page = 1, [FromQuery] int units = 99)
        {
            if (page < 1 || units < 1)
            {
                _logger.LogInformation($"There was an error in the pagination, page = {page}, units = {units}!");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was an error in the pagination!");
            }

            if (clientId <= 0)
            {
                _logger.LogInformation($"The client id was invalid, id = {clientId}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The client id is invalid!");
            }

            var transactions = await _service.GetTransactionsByClient(clientId, page, units);

            if (transactions == null)
            {
                _logger.LogInformation($"The client was not found, id = {clientId}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The client was not found!");
            }

            _logger.LogInformation("All Transactions by client were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, transactions);

        }

        /// <summary>
        /// Gets a specific Transaction by its ID.
        /// </summary>
        /// <param name="id">ID of the Transaction to retrieve.</param>
        /// <returns>
        /// 200 OK response with the Transaction if found.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 404 Not Found response if no Transaction is found for the specified ID.
        /// 400 Bad Request response if the transaction id is invalid.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("transaction/{id:int}")]
        public async Task<IActionResult> GetTransaction([FromRoute] int id)
        {
            if (id <= 0)
            {
                _logger.LogInformation($"The transaction id was invalid, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The transaction id is invalid!");
            }

            var transaction = await _service.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                _logger.LogInformation($"The transaction was not found, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The transaction was not found!");
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
        /// 401 Unauthorized response if the user is not authenticated.
        /// 400 Bad Request response if some of the data is invalid.
        /// </returns>

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("transaction/create")]
        public async Task<IActionResult> CreateTransaction(TransactionCreateDto dto)
        {

            if (dto.Amount <= 1)
            {
                _logger.LogInformation($"The amount introduced was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

            }

            if (dto.Concept < (TransactionConcept)1 || dto.Concept > (TransactionConcept)8)
            {
                _logger.LogInformation($"The concept introduced was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The concept introduced was invalid!");
            }

            if (dto.Type != TransactionType.Transfer && dto.Type != TransactionType.Withdrawal && dto.Type != TransactionType.Deposit)
            {
                _logger.LogInformation($"The transaction type entered was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The transaction type entered is invalid!");

            }

            if(dto.Type == TransactionType.Transfer && (dto.SourceAccountId == dto.DestinationAccountId))
            {
                _logger.LogInformation($"The transfer source and origin accounts were the same, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The transfer accounts cant be the same!");
            }

            if (dto.Type == TransactionType.Deposit || dto.Type == TransactionType.Withdrawal)
            {

                if (dto.SourceAccountId != dto.DestinationAccountId)
                {
                    _logger.LogInformation($"The extraction and deposit accounts must be the same, dto = {dto}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The extraction and deposit accounts must be the same!");
                }

            }

            var flag = await _service.CreateTransactionAsync(dto);

            if(flag == false)
            {
                _logger.LogInformation($"There was a problem with the transaction creation, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There is a problem with the transaction creation, check if the client and the accounts were valid!");
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
        /// 400 Bad Request response if Transaction update fails.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 403 Forbidden response if the Transaction update is forbidden.
        /// 404 Not Found response if no Transaction is found.
        /// </returns>

        [HttpPut]
        [Authorize(Policy = "Admin")]
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
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

            }

            if(id != dto.Id)
            {
                _logger.LogInformation($"The IDs were not the same, dto = {dto}, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The transaction ids were not the same");
            }

            if(dto.Concept < (TransactionConcept)1 || dto.Concept > (TransactionConcept)8)
            {
                _logger.LogInformation($"The concept introduced was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The concept introduced was invalid!");
            }

            if (dto.Type != TransactionType.Transfer && dto.Type != TransactionType.Withdrawal && dto.Type != TransactionType.Deposit)
            {
                _logger.LogInformation($"The transaction type entered was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The transaction type entered is invalid!");
            }

            if (dto.Type == TransactionType.Transfer && (dto.SourceAccountId == dto.DestinationAccountId))
            {
                _logger.LogInformation($"The transfer source and origin accounts were the same, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The transfer accounts cant be the same!");
            }
            
            if(dto.Type == TransactionType.Deposit || dto.Type == TransactionType.Withdrawal)
            {

                if(dto.SourceAccountId != dto.DestinationAccountId)
                {
                    _logger.LogInformation($"The extraction and deposit accounts must be the same, dto = {dto}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The extraction and deposit accounts must be the same!");
                }

            }

            

            var flag = await _service.UpdateTransaction(dto);

            if (flag == false)
            {
                _logger.LogInformation($"There was a problem with the transaction update, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There is a problem with the transaction update, check if the client and the accounts were valid!");
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
        /// 404 Not Found response if Transaction deletion fails.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 403 Forbidden response if the Transaction deletion is forbidden.
        /// 400 Bad Request response if the request is invalid.
        /// </returns>

        [HttpDelete]
        [Authorize(Policy = "Admin")]
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
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The transaction id is invalid!");
            }


            var transaction = await _service.DeleteTransactionAsync(id);

            if (transaction == false)
            {
                _logger.LogInformation($"The transaction was not found, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The transaction was not found!");
            }

            _logger.LogInformation($"Transaction was deleted, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The Transaction was deleted!");

        }

    }
}
