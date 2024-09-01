/******************************************************************************
* Filename    = BankAccountProxyTests.cs
*
* Author      = Yash Mittal
*
* Project     = Bank Account Proxy App
*
* Description = Tests for the BankAccountProxy class and the various error cases.
*****************************************************************************/

using BankAccountProxyApp;

namespace BankAccountProxyTests
{
    /// <summary>
    /// Tests for the <see cref="BankAccountProxy"/> class.
    /// </summary>
    [TestClass]
    public class BankAccountProxyTests
    {
        private IBankAccount _bankAccountProxy;

        /// <summary>
        /// Initializes the test setup before each test method.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _bankAccountProxy = new BankAccountProxy( 0 );
        }

        /// <summary>
        /// Tests that the <see cref="BankAccountProxy.Deposit"/> method increases the balance.
        /// </summary>
        [TestMethod]
        public void IsDeposit_Working()
        {
            _bankAccountProxy.Deposit( 500 );
            Assert.AreEqual( 500 , _bankAccountProxy.GetBalance() );
        }

        /// <summary>
        /// Tests that the <see cref="BankAccountProxy.Withdraw"/> method decreases the balance
        /// when the amount is within the limit.
        /// </summary>
        [TestMethod]
        public void IsWithdrawal_Working_WhenInLimit()
        {
            _bankAccountProxy.Deposit( 1000 );
            _bankAccountProxy.Withdraw( 500 );
            Assert.AreEqual( 500 , _bankAccountProxy.GetBalance() );
        }

        /// <summary>
        /// Tests that the <see cref="BankAccountProxy.Withdraw"/> method does not allow
        /// withdrawal when the amount exceeds the limit.
        /// </summary>
        [TestMethod]
        public void IsWithdrawal_ThrowingError_WhenOverLimit()
        {
            _bankAccountProxy.Deposit( 2000 );
            InvalidOperationException exception = Assert.ThrowsException<InvalidOperationException>( () =>
                _bankAccountProxy.Withdraw( 1500 ) );

            Assert.AreEqual( "Withdrawal limit exceeded." , exception.Message );
        }

        /// <summary>
        /// Tests that the <see cref="BankAccountProxy.Withdraw"/> method throws an <see cref="ArgumentException"/>
        /// when the withdrawal amount is negative or zero.
        /// </summary>
        [TestMethod]
        public void IsWithdrawal_ThrowingException_WhenNegativeOrZero()
        {
            _bankAccountProxy.Deposit( 1000m ); // Deposit an initial balance

            // Act for negative amount
            ArgumentException negativeAmountException = Assert.ThrowsException<ArgumentException>( () =>
                _bankAccountProxy.Withdraw( -100m ) );

            Assert.AreEqual( "Withdrawal amount must be positive." , negativeAmountException.Message );

            // Act for a withdrawal of null.
            ArgumentException zeroAmountException = Assert.ThrowsException<ArgumentException>( () =>
                _bankAccountProxy.Withdraw( 0m ) );

            Assert.AreEqual( "Withdrawal amount must be positive." , zeroAmountException.Message );
        }

        /// <summary>
        /// Tests that the <see cref="BankAccountProxy.Withdraw"/> method throws an <see cref="InvalidOperationException"/>
        /// when attempting to withdraw more than the available funds.
        /// </summary>
        [TestMethod]
        public void IsWithdrawal_ThrowingError_WhenOverCurrentAmount()
        {
            _bankAccountProxy.Deposit( 500m ); 

            InvalidOperationException exception = Assert.ThrowsException<InvalidOperationException>( () =>
                _bankAccountProxy.Withdraw( 1000m ) ); 

            Assert.AreEqual( "Insufficient funds." , exception.Message );
        }
    }
}
