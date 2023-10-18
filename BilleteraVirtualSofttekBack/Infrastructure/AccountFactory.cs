﻿using AutoMapper;
using BilleteraVirtualSofttekBack.Models.Accounts;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;

namespace BilleteraVirtualSofttekBack.Infrastructure
{
    public class AccountFactory
    {
        private readonly IMapper _mapper;

        public AccountFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public BaseAccount CreateAccount(AccountCreateDto accountDto)
        {
            BaseAccount account;

            switch (accountDto.Type)
            {
                case AccountType.Peso:
                    account = _mapper.Map<PesoAccount>(accountDto);
                    return account;
                    break;
                case AccountType.Dollar:
                    account = _mapper.Map<DollarAccount>(accountDto);
                    return account;
                    break;
                case AccountType.Crypto:
                    account = _mapper.Map<CryptoAccount>(accountDto);
                    return account;
                    break;
                default:
                    throw new ArgumentException("Invalid account type.");
            }

        }
    }
}
