using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cash_Flow
{
    /// <summary>
    /// Interaction logic for Loan.xaml
    /// </summary>
    public partial class Loan : Window
    {
        private Player player;
        private int cashflow;
        private int amount;
        private bool tookloan;
        private bool downsized;
        public Loan(Player p, bool downsized)
        {
            InitializeComponent();
            this.player = p;
            cashflow = p.getJob().getCashFlow;
            amount = 0;
            this.tookloan = false;
            this.downsized = downsized;
            if(downsized)
            {
                specialLabel.Visibility = Visibility.Visible;
                cancelButton.IsEnabled= false;
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            if(Int32.TryParse(amountBox.Text, out int n))
            {
                if (downsized)
                {
                    if(player.getJob().getSavings + n >= player.getJob().getTotalExpenses)
                    {
                        amount = n;
                        tookloan = true;
                        this.Close();
                    }
                    else
                    {
                        messageLabel.Content = "That is not enough.";
                    }
                }
                else
                {
                    if (cashflow - n * 0.1 < 0)
                    {
                        messageLabel.Content = "You cannot afford this loan.";
                    }
                    else
                    {
                        amount = n;
                        tookloan = true;
                        this.Close();
                    }
                }
            }
            else
            {
                messageLabel.Content = "Please enter a whole number";
            }
            messageLabel.Visibility = Visibility.Visible;
        }
        public int getAmount()
        {
            return amount;
        }
        public bool tookLoan()
        {
            return tookloan;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
