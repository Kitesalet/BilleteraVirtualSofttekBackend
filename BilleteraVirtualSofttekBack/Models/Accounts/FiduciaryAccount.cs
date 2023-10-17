﻿using BilleteraVirtualSofttekBack.Models.Entities;

namespace BilleteraVirtualSofttekBack.Models.Accounts
{
    public abstract class FiduciaryAccount : BaseAccount
    {
        public int CBU { get; set; }
        public int AccountNumber { get; set; }
        public string Alias { get; set; }

    }
}
