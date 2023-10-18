using AutoMapper;
using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Infrastructure;
using BilleteraVirtualSofttekBack.Models.Accounts;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using System.Security.Principal;

namespace BilleteraVirtualSofttekBack.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AccountFactory _accountFactory;

        /// <summary>
        /// Initializes an instance of AccountService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public AccountService(AccountFactory accountFactory, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountFactory = accountFactory;

        }

        /// <inheritdoc/>
        public async Task<bool> CreateAccountAsync(AccountCreateDto accountDto)
        {
            try
            {
                var baseAccount = _accountFactory.CreateAccount(accountDto);

                if (baseAccount != null)
                {

                    await _unitOfWork.AccountRepository.AddAsync(baseAccount);
                    await _unitOfWork.Complete();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
            }

            return false;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAccountAsync(int id)
        {

            var flag = await _unitOfWork.AccountRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AccountGetDto>> GetAllAccountsByClientAsync(int id)
        {

            var accounts = await _unitOfWork.AccountRepository.GetAllAccountsByClient(id);

            var accountsDto = _mapper.Map<List<AccountGetDto>>(accounts);

            return accountsDto;

        }

        /// <inheritdoc/>
        public async Task<AccountGetDto> GetAccountByIdAsync(int id)
        {

            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);

            if (account == null || account.DeletedDate != null)
            {
                return null;
            }

            return _mapper.Map<AccountGetDto>(account);

        }

        /// <inheritdoc/>
        public async Task<bool> UpdateAccount(AccountUpdateDto accountDto)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountDto.AccountId);

            
            try
            {


                account.ModifiedDate = DateTime.Now;

                _unitOfWork.AccountRepository.Update(account);

                await _unitOfWork.Complete();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
            

        }

        public async Task<bool> DepositAsync(AccountDepositDto transactionDTO)
        {

            var account = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDTO.Id);


            if (account != null || account.DeletedDate != null)
            {
                return false;
            }
               
            try
            {

                account.Deposit(transactionDTO.Amount);

                await _unitOfWork.Complete();

                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public async Task<bool> TransferAsync(TransferDto transactionDTO)
        {

            var originAccount = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDTO.OriginAccountId);
            var receptionAccount = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDTO.DestinationAccountId);

            if (originAccount == null || receptionAccount == null || originAccount.DeletedDate != null || receptionAccount.DeletedDate != null)
            {
                return false;
            }

            try
            {

                originAccount.Transfer(receptionAccount, transactionDTO.Amount);


                await _unitOfWork.Complete();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ExtractAsync(AccountExtractDto transactionDTO)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDTO.Id);


            if (account == null || account.DeletedDate != null)
            {
                return false;
            }

            try
            {

                account.Extract(transactionDTO.Amount);

                await _unitOfWork.Complete();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
