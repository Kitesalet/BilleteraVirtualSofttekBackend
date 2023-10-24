using AutoMapper;
using BilleteraVirtualSofttekBack.Helpers;
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

        /// <summary>
        /// Initializes an instance of TransactionService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;

        }

        /// <inheritdoc/>
        public async Task<bool> CreateTransactionAsync(TransactionCreateDto transactionDto)
        {

            var origin = _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);
            var destination = _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);

            if(origin == null || destination == null)
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
                Console.WriteLine(ex.Message + " - Error");
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
        public async Task<IEnumerable<TransactionGetDto>> GetAllTransactionsAsync(int page, int units)
        {

            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync(page, units);

            var transactionsDto = _mapper.Map<List<TransactionGetDto>>(transactions);

            return transactionsDto;

        }

        /// <inheritdoc/>
        public async Task<List<TransactionGetDto>> GetTransactionByAccountAsync(int clientId)
        {
            var client = _unitOfWork.ClientRepository.GetByIdAsync(clientId);

            if(client == null)
            {
                return null;   
            }

            var transactions = await _unitOfWork.TransactionRepository.GetTransactionByAccount(clientId);

            var transactionsDto = _mapper.Map<List<TransactionGetDto>>(transactions);

            return transactionsDto;

        }

        /// <inheritdoc/>
        public async Task<TransactionGetDto> GetTransactionByIdAsync(int id)
        {

            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id);

            if (transaction == null || transaction.DeletedDate != null)
            {
                return null;
            }

            return _mapper.Map<TransactionGetDto>(transaction);

        }

        /// <inheritdoc/>
        public async Task<bool> UpdateTransaction(TransactionUpdateDto transactionDto)
        {
            var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(transactionDto.Id);

            if(transaction == null)
            {
                return false;
            }

            var origin = _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);
            var destination = _unitOfWork.AccountRepository.GetByIdAsync(transactionDto.SourceAccountId);

            if (origin == null || destination == null)
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
            catch (Exception)
            {
                return false;
            }

        }
    }
}
