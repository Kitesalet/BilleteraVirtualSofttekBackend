﻿using BilleteraVirtualSofttekBack.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BilleteraVirtualSofttekBack.Models.DTOs.Account
{
    public class AccountGetDto
    {

        public string UUID { get; set; }
        public int AccountNumber { get; set; }
        public int CBU { get; set; }
        public string? Alias { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public int ClientId { get; set; }

    }
}
