/******************************************************************************
* Filename    = MainWindow.xaml.cs
*
* Author      = Yash Mittal
*
* Project     = Bank Account Proxy App
*
* Description = Represents the functionality of the GUI of the WPF Application.
*****************************************************************************/

using System.Windows;
using System.Windows.Media;

namespace BankAccountProxyApp
{
    /// <summary>
    /// The MainWindow class represents the main window of the WPF application,
    /// handling user interactions for bank account operations like deposit and withdrawal.
    /// </summary>
    public partial class MainWindow : Window
    {
        // A reference to the bank account proxy, used for interacting with the bank account
        private readonly IBankAccount _bankAccountProxy;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// Sets up the bank account proxy with an initial balance and updates the UI to show the current balance.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _bankAccountProxy = new BankAccountProxy( 0 );  // Initialize with a balance of 0
            UpdateBalance();  // Update the balance display in the UI
        }

        /// <summary>
        /// Handles the click event for the Deposit button.
        /// Attempts to deposit the entered amount into the bank account and updates the UI.
        /// </summary>
        private void DepositButton_Click( object sender , RoutedEventArgs e )
        {
            if (decimal.TryParse( amountTextBox.Text , out decimal amount ))
            {
                try
                {
                    _bankAccountProxy.Deposit( amount );  // Attempt to deposit the amount
                    messageTextBlock.Text = "Successfully deposited.";
                    messageTextBlock.Foreground = new SolidColorBrush( Colors.Blue );  
                    UpdateBalance();  // Update the balance display in the UI
                }
                catch (Exception ex)
                {
                    messageTextBlock.Text = $"Error: {ex.Message}";  
                    messageTextBlock.Foreground = new SolidColorBrush( Colors.Red );  
                }
            }
            else
            {
                messageTextBlock.Text = "Invalid amount. Please enter a valid number.";
                messageTextBlock.Foreground = new SolidColorBrush( Colors.Red );  
            }
        }

        /// <summary>
        /// Handles the click event for the Withdraw button.
        /// Attempts to withdraw the entered amount from the bank account and updates the UI.
        /// </summary>
        private void WithdrawButton_Click( object sender , RoutedEventArgs e )
        {
            if (decimal.TryParse( amountTextBox.Text , out decimal amount ))
            {
                try
                {
                    _bankAccountProxy.Withdraw( amount );  // Attempt to withdraw the amount
                    messageTextBlock.Text = "Successfully withdrawn.";
                    messageTextBlock.Foreground = new SolidColorBrush( Colors.Blue );  
                    UpdateBalance();  // Update the balance display in the UI
                }
                catch (InvalidOperationException ex) when (ex.Message == "Withdrawal limit exceeded.")
                {
                    messageTextBlock.Text = "Withdrawal limit exceeded.";
                    messageTextBlock.Foreground = new SolidColorBrush( Colors.Red );
                }
                catch (InvalidOperationException ex) when (ex.Message == "Insufficient funds.")
                {
                    messageTextBlock.Text = "Insufficient funds.";
                    messageTextBlock.Foreground = new SolidColorBrush( Colors.Red );  
                }
                catch (Exception ex)
                {
                    messageTextBlock.Text = $"Error: {ex.Message}";  
                    messageTextBlock.Foreground = new SolidColorBrush( Colors.Red ); 
                }
            }
            else
            {
                messageTextBlock.Text = "Invalid amount. Please enter a valid number.";
                messageTextBlock.Foreground = new SolidColorBrush( Colors.Red ); 
            }
        }

        /// <summary>
        /// Updates the balance display in the UI to reflect the current updated balance in the bank account.
        /// </summary>
        private void UpdateBalance()
        {
            balanceTextBlock.Text = _bankAccountProxy.GetBalance().ToString( "C" ); 
        }
    }
}
