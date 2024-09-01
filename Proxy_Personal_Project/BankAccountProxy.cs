/******************************************************************************
* Filename    = BankAccountProxy.cs
*
* Author      = Yash Mittal
*
* Project     = Bank Account Proxy App
*
* Description = Implements the proxy design pattern by acting as a proxy to the BankAccount class.
*****************************************************************************/

namespace BankAccountProxyApp
{
    /// <summary>
    /// The BankAccountProxy class acts as a proxy to the BankAccount class, adding additional
    /// functionality such as withdrawal limits and error handling.
    /// </summary>
    public class BankAccountProxy : IBankAccount
    {
        // A reference to the actual BankAccount object that this proxy controls
        private readonly BankAccount _bankAccount;

        // Field to store the current balance of the bank account (tracked by the proxy)
        private decimal _balance;

        // A predefined withdrawal limit, set to 1000 for example purposes
        private readonly decimal _withdrawalLimit = 1000m;

        /// <summary>
        /// Initializes a new instance of the BankAccountProxy class with an initial balance.
        /// </summary>
        /// <param name="initialBalance">The starting balance for the bank account.</param>
        public BankAccountProxy( decimal initialBalance )
        {
            // Initialize the actual BankAccount object and set the initial balance
            _bankAccount = new BankAccount();
            _balance = initialBalance;
        }

        /// <summary>
        /// Deposits the specified amount into the bank account.
        /// </summary>
        /// <param name="amount">The amount to deposit into the account.</param>
        public void Deposit( decimal amount )
        {
            _bankAccount.Deposit( amount );
            // Update the proxy's balance to reflect the new balance in the bank account
            _balance = _bankAccount.GetBalance();
        }

        /// <summary>
        /// Withdraws the specified amount from the bank account, with checks for withdrawal limits and sufficient funds.
        /// </summary>
        /// <param name="amount">The amount to withdraw from the account.</param>
        /// <exception cref="ArgumentException">Thrown when the withdrawal amount is not positive.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the withdrawal exceeds the limit or there are insufficient funds.</exception>
        public void Withdraw( decimal amount )
        {
            // Check that the withdrawal amount is positive
            if (amount <= 0)
            {
                throw new ArgumentException( "Withdrawal amount must be positive." );
            }

            // Check if the withdrawal exceeds the predefined limit
            if (amount > _withdrawalLimit)
            {
                throw new InvalidOperationException( "Withdrawal limit exceeded." );
            }

            // Check if there are sufficient funds in the account
            if (_balance < amount)
            {
                throw new InvalidOperationException( "Insufficient funds." );
            }

            // Order/Delegate the withdrawal to the actual BankAccount object
            _bankAccount.Withdraw( amount );
            // Update the proxy's balance to reflect the new balance in the bank account
            _balance = _bankAccount.GetBalance();
        }

        /// <summary>
        /// Retrieves the current balance of the bank account.
        /// </summary>
        /// <returns>The current balance that was tracked by the proxy.</returns>
        public decimal GetBalance()
        {
            return _balance;
        }
    }
}
