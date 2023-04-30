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
    /// Interaction logic for SellStocks.xaml
    /// </summary>
    public partial class SellStocks : Window
    {
        private Player player;
        private Stocks pstock;
        private Stocks currStock;
        private System.Windows.Threading.DispatcherTimer timer;
        private bool sold;
        private int amount;
        public SellStocks(Player p, Stocks s,int i)
        {
            InitializeComponent();
            player = p;
            currStock = s;
            headingBox.Text = p.getPlayerName + " can sell " + s.getName +".";
            pstock = p.getStocks()[i];
            boughtAtLabel.Content = pstock.getPrice;
            currentPriceLabel.Content = s.getPrice;
            sold = false;
            sharesLabel.Content = pstock.getAmount;
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();


        }
        private void timer_Tick(Object sender, EventArgs e)
        {
            if (Int32.TryParse(amountBox.Text, out int n))
            {
                recieveLabel.Content = "$" + (n * currStock.getPrice);
            }
            else
            {
                recieveLabel.Content = "Enter a whole number";
            }
        }
        //sellbutton
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(amountBox.Text, out int n))
            {
                if(n > pstock.getAmount)
                {
                    messageLabel.Content = "You dont have that much stocks";
                }
                else
                {
                    amount = n;
                    sold = true;
                    this.Close();
                }

            }
            else
            {
                recieveLabel.Content = "Enter a whole number";
            }
        }
        public bool didSell()
        {
            return this.sold;
        }
        public int getAmount()
        {
            return amount;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.sold = false;
            this.Close();
        }
    }
}
