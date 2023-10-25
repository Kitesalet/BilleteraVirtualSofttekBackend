namespace BilleteraVirtualSofttekBack.Models.Enums
{
    /// <summary>
    /// Represents the type of transaction
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Transaction type for Deposits
        /// </summary>
        Deposit = 1,

        /// <summary>
        /// Transaction type for Withdrawals
        /// </summary>
        Withdrawal = 2,

        /// <summary>
        /// Transaction type for Transfers
        /// </summary>
        Transfer = 3,
    }
}
