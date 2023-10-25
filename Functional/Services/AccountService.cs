using AutoMapper;
using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Infrastructure;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities.Accounts;
using BilleteraVirtualSofttekBack.Models.Enums;
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
        private readonly ILogger<IAccountService> _logger;

        /// <summary>
        /// Initializes an instance of AccountService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public AccountService(AccountFactory accountFactory, IUnitOfWork unitOfWork, IMapper mapper, ILogger<IAccountService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountFactory = accountFactory;
            _logger = logger;

        }

        /// <inheritdoc/>
        public async Task<List<AccountGetDto>> GetAllAccounts(int page, int units)
        {

            var accounts = await _unitOfWork.AccountRepository.GetAllAsync(page, units);

            return _mapper.Map<List<AccountGetDto>>(accounts);

        }

        /// <inheritdoc/>
        public async Task<bool> CreateAccountAsync(AccountCreateDto accountDto)
        {
            Random random = new Random();

            try
            {

                var client = await _unitOfWork.ClientRepository.GetByIdAsync(accountDto.ClientId);

                if(client == null)
                {
                    return false;
                }


                var baseAccount = _accountFactory.CreateAccount(accountDto);

                if (baseAccount != null)
                {

                    if (baseAccount.Type == AccountType.Crypto)
                    {

                        CryptoAccount crypto = (CryptoAccount)baseAccount;
                        crypto.CreatedDate = DateTime.Now;
                        crypto.UUID = Guid.NewGuid();
                    }
                    else
                    {

                        int randomAccountNumber = 0;
                        int randomCBUNumber = 0;

                        FiduciaryAccount fiduciary = (FiduciaryAccount)baseAccount;
                        fiduciary.CreatedDate = DateTime.Now;

                        #region database validatons and creationHelpers
                        var newAlias = AliasCreatorHelper.CreateAlias();
                        while(await _unitOfWork.AccountRepository.VerifyExistingAlias(newAlias))
                        {

                            newAlias = AliasCreatorHelper.CreateAlias();

                        }

                        randomAccountNumber = random.Next(999999999);
                        while (await _unitOfWork.AccountRepository.VerifyExistingAccountNumber(randomAccountNumber))
                        {

                            randomAccountNumber = random.Next(999999999);

                        }

                        randomCBUNumber = random.Next(999999999);
                        while (await _unitOfWork.AccountRepository.VerifyExistingAccountNumber(randomCBUNumber))
                        {

                            randomCBUNumber = random.Next(999999999);

                        }
                        #endregion

                        fiduciary.Alias = newAlias;
                        fiduciary.AccountNumber = randomAccountNumber;
                        fiduciary.CBU = randomCBUNumber;
                    }

                    await _unitOfWork.AccountRepository.AddAsync(baseAccount);
                    await _unitOfWork.Complete();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message + " - Error");
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
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(accountDto.ClientId);


            if (account == null || client == null)
            {
                return false;

            }

            if(accountDto.Type == AccountType.Crypto)
            {
                var uuidExists = await _unitOfWork.AccountRepository.VerifyExistingUUID(accountDto.UUID);

                if(uuidExists == true)
                {
                    return false;
                }
            }


            if(accountDto.Type == AccountType.Dollar || accountDto.Type == AccountType.Peso)
            {
               var numberExists = await _unitOfWork.AccountRepository.VerifyExistingAccountNumber(accountDto.AccountNumber);
               
               if (numberExists == true)
               { 
                 
                    return false;
               
               }

                var cbuExists = await _unitOfWork.AccountRepository.VerifyExistingCBU(accountDto.CBU);

                if(cbuExists == true)
                {
                    return false;
                }

                var aliasExists = await _unitOfWork.AccountRepository.VerifyExistingAlias(accountDto.Alias);

                if(aliasExists == true)
                {
                    return false;
                }
            }

            try
            {
             
                if(account.Type == AccountType.Peso)
                {
                    var newAccount = (PesoAccount)account;

                    newAccount.ModifiedDate = DateTime.Now;
                    newAccount.Alias = accountDto.Alias;
                    newAccount.AccountNumber = accountDto.AccountNumber;
                    newAccount.CBU = accountDto.CBU;
                    newAccount.Balance = accountDto.Balance;
                    newAccount.ClientId = accountDto.ClientId;

                }
                else if(account.Type == AccountType.Dollar)
                {
                    var newAccount = (DollarAccount)account;

                    newAccount.ModifiedDate = DateTime.Now;
                    newAccount.Alias = accountDto.Alias;
                    newAccount.AccountNumber = accountDto.AccountNumber;
                    newAccount.CBU = accountDto.CBU;
                    newAccount.Balance = accountDto.Balance;
                    newAccount.ClientId = accountDto.ClientId;
                }
                else
                {
                    var newAccount = (CryptoAccount)account;

                    newAccount.ModifiedDate = DateTime.Now;
                    newAccount.Balance = accountDto.Balance;
                    newAccount.ClientId = accountDto.ClientId;
                }



                _unitOfWork.AccountRepository.Update(account);

                await _unitOfWork.Complete();

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
            

        }

        /// <inheritdoc/>
        public async Task<bool> DepositAsync(AccountDepositDto transactionDTO)
        {

            var account = await _unitOfWork.AccountRepository.GetByIdAsync(transactionDTO.Id);


            if (account == null || account.DeletedDate != null)
            {
                return false;
            }
               
            try
            {

                account.Deposit(transactionDTO.Amount);

                await _unitOfWork.Complete();

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
           
        }


        /// <inheritdoc/>

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
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }


        /// <inheritdoc/>

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
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }

    }
}
