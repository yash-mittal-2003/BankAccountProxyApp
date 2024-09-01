/******************************************************************************
* Filename    = IBankAccount.cs
*
* Author      = Yash Mittal
*
* Project     = Bank Account Proxy App
*
* Description = A basic interface representing a bank account with relevant operations associated with it.
*****************************************************************************/

namespace BankAccountProxyApp
{
    /// <summary>
    /// Interface representing a basic bank account with operations to deposit,
    /// withdraw, and retrieve the current balance.
    /// </summary>
    public interface IBankAccount
    {
        /// <summary>
        /// Deposits the specified amount into the bank account.
        /// </summary>
        /// <param name="amount">The amount to deposit into the account.</param>
        void Deposit( decimal amount );

        /// <summary>
        /// Withdraws the specified amount from the bank account.
        /// </summary>
        /// <param name="amount">The amount to withdraw from the account.</param>
        void Withdraw( decimal amount );

        /// <summary>
        /// Retrieves the current balance of the bank account.
        /// </summary>
        /// <returns>The current balance as a decimal value.</returns>
        decimal GetBalance();
    }
}
