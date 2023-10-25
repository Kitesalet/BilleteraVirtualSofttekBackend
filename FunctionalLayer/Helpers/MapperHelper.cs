using AutoMapper;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Entities.Accounts;
using System.Data;

namespace BilleteraVirtualSofttekBack.Helpers
{
    /// <summary>
    /// This class provides a mean to configure mappings between classes.
    /// </summary>
    public class MapperHelper : Profile
    {
        /// <summary>
        /// This constructor contains the logic for Entity-DTO mappings using the AutoMapper library and its methods.
        /// </summary>
        public MapperHelper()
        {
            #region Client mapping to their Dto class
            CreateMap<Client, ClientCreateDto>().ReverseMap();
            CreateMap<Client, ClientGetDto>().ReverseMap();
            CreateMap<Client, ClientUpdateDto>().ReverseMap();
            #endregion

            #region Account mapping to their Dto class
            CreateMap<PesoAccount, AccountGetDto>().ReverseMap();
            CreateMap<CryptoAccount, AccountGetDto>().ReverseMap();
            CreateMap<DollarAccount, AccountGetDto>().ReverseMap();

            CreateMap<PesoAccount, AccountUpdateDto>().ReverseMap();
            CreateMap<CryptoAccount, AccountUpdateDto>().ReverseMap();
            CreateMap<DollarAccount, AccountUpdateDto>().ReverseMap();

            CreateMap<PesoAccount, AccountCreateDto>().ReverseMap();
            CreateMap<CryptoAccount, AccountCreateDto>().ReverseMap();
            CreateMap<DollarAccount, AccountCreateDto>().ReverseMap();
            #endregion

            #region Transaction Mapping

            CreateMap<Transaction, TransactionCreateDto>().ReverseMap();
            CreateMap<Transaction, TransactionGetDto>().ReverseMap();
            CreateMap<Transaction, TransactionUpdateDto>().ReverseMap();
            CreateMap<Transaction, TransferDto>().ReverseMap();
            CreateMap<Transaction, TransactionGetMinDto>().ReverseMap();

            #endregion
        }

    }
}
