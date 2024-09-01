/******************************************************************************
* Filename    = BankAccount.cs
*
* Author      = Yash Mittal
*
* Project     = Bank Account Proxy App
*
* Description = Implementing the IBankAccount Interface
*****************************************************************************/

namespace BankAccountProxyApp
{
    /// <summary>
    /// Represents a simple bank account that allows deposits, withdrawals, and balance checking.
    /// Implements the IBankAccount interface.
    /// </summary>
    public class BankAccount : IBankAccount
    {
        // Field to store the current balance of the bank account
        private decimal _balance;

        /// <summary>
        /// Deposits the specified amount into the bank account.
        /// </summary>
        /// <param name="amount">The amount to deposit into the account.</param>
        public void Deposit( decimal amount )
        {
            // Add the deposit amount to the current balance
            _balance += amount;
        }

        /// <summary>
        /// Withdraws the specified amount from the bank account.
        /// </summary>
        /// <param name="amount">The amount to withdraw from the account.</param>
        public void Withdraw( decimal amount )
        {
            // Subtract the withdrawal amount from the current balance
            _balance -= amount;
        }

        /// <summary>
        /// Retrieves the current balance of the bank account.
        /// </summary>
        /// <returns>The current balance of the account as a decimal value.</returns>
        public decimal GetBalance()
        {
            // Return the current balance
            return _balance;
        }
    }
}
