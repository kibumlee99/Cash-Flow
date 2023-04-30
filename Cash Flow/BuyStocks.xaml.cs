using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for BuyStocks.xaml
    /// </summary>
    public partial class BuyStocks : Window
    {
        private SmallDeal stock;
        private bool cancelled;
        private int amount;
        private int savings;
        public BuyStocks(SmallDeal stock,int savings)
        {
            InitializeComponent();
            stockNameLabel.Text = stock.getName;
            this.stock = stock;
            cancelled = false;
            this.savings = savings;
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            if(Int32.TryParse(amountBox.Text,out int n))
            {
                if (stock.getDownPayment * n > savings)
                {
                    errLabel.Content = "You dont have enough!";
                }
                else
                {
                    this.amount = n;
                    this.Close();
                }
            }
            else
            {
                errLabel.Content = "*Must Enter a Whole Number";
            }
        }
        public int getAmount()
        {
            return this.amount;
        }
        public bool isCancelled()
        {
            return this.cancelled;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.cancelled = true;
            this.Close();
        }
    }
}
