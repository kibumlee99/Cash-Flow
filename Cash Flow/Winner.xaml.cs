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
    /// Interaction logic for Winner.xaml
    /// </summary>
    public partial class Winner : Window
    {
        private Player player;
        public Winner(Player p)
        {
            InitializeComponent();
            player = p;
            messageLabel.Text = player.getPlayerName + " has escaped the rat race!";
            cashFlowLabel.Text = "Cash Flow: $" +player.getJob().getCashFlow;
            savingsLabel.Text = "Savings: $" + player.getJob().getSavings;
            totalExpensesLabel.Text = "Total expenses: $" + player.getJob().getTotalExpenses;
        }

        private void okayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
