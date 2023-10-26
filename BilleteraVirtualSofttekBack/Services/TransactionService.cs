using AutoMapper;
using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace BilleteraVirtualSofttekBack.Services
{
    /// <summary>
    /// The implementation of the service for defining and using TransactionDtos and its logic.
    /// </summary>
    public class TransactionService : ITransactionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ITransactionService> _logger;

        /// <summary>
        /// Initializes an instance of TransactionService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, ILogger<ITransactionService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;

        }

        /// <inheritdoc/>
        public async Task<bool> CreateTransactionAsync(TransactionCreateDto transactionDto)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(transactionDto.ClientId);
            var origin = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);
            var destination = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);

            

            if(origin == null || destination == null || client == null)
            {
                return false;
            }

            //The accounts must be from the same client
            if (client.Id != origin.ClientId)
            {
                return false;
            }

            try
            {

                var transaction = _mapper.Map<Transaction>(transactionDto);

                await _unitOfWork.TransactionRepository.AddAsync(transaction);

                transaction.CreatedDate = DateTime.Now;

                await _unitOfWork.Complete();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return false;

        }

        /// <inheritdoc/>
        public async Task<bool> DeleteTransactionAsync(int id)
        {

            var flag = await _unitOfWork.TransactionRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransactionGetMinDto>> GetAllTransactionsAsync(int page, int units)
        {

            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync(page, units);

            var transactionsDto = _mapper.Map<List<TransactionGetMinDto>>(transactions);

            return transactionsDto;

        }

        /// <inheritdoc/>
        public async Task<List<TransactionGetDto>> GetTransactionsByClient(int accountId, int page, int units)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(accountId);

            if(client == null)
            {
                return null;
            }

            var transactions = await _unitOfWork.TransactionRepository.GetTransactionsByClient(accountId, page, units);

            var transactionsDto = _mapper.Map<List<TransactionGetDto>>(transactions);

            return transactionsDto;

        }

        /// <inheritdoc/>
        public async Task<List<TransactionGetDto>> GetTransactionsByAccount(int accountId, int page, int units)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

            if (account == null)
            {
                return null;
            }

            var transactions = await _unitOfWork.TransactionRepository.GetTransactionsByAccount(accountId, page, units);

            var transactionsDto = _mapper.Map<List<TransactionGetDto>>(transactions);

            return transactionsDto;

        }

        /// <inheritdoc/>
        public async Task<TransactionGetDto> GetTransactionByIdAsync(int id)
        {

            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id);

            if (transaction == null)
            {
                return null;
            }

            var transactionDto = _mapper.Map<TransactionGetDto>(transaction);

            var sourceAccount = await _unitOfWork.AccountRepository.GetByIdAsync(transaction.SourceAccountId);
            var destinationAccount = await _unitOfWork.AccountRepository.GetByIdAsync(transaction.DestinationAccountId);
            var sAccountDto = _mapper.Map<AccountGetDto>(sourceAccount);
            var dAccountDto = _mapper.Map<AccountGetDto>(destinationAccount);

            transactionDto.DestinationAccount = sAccountDto;
            transactionDto.SourceAccount = dAccountDto;

            return transactionDto;

        }

        /// <inheritdoc/>
        public async Task<bool> UpdateTransaction(TransactionUpdateDto transactionDto)
        {
            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(transactionDto.Id);
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(transactionDto.ClientId);
            var origin = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);
            var destination = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);

            

            if (
                  origin == null 
               || destination == null 
               || client == null 
               || transaction == null              
               )
            {
                return false;
            }

            if (client.Id != origin.ClientId || client.Id == destination.ClientId)
            {
                return false;
            }

            try
            {

                transaction.Concept = transactionDto.Concept;
                transaction.Amount = transactionDto.Amount;
                transaction.Type = transactionDto.Type;

                _unitOfWork.TransactionRepository.Update(transaction);

                await _unitOfWork.Complete();

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }

        }
    }
}
