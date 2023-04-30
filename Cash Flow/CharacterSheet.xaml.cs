using System;
using System.Collections.Generic;
using System.IO;
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
    /*
     * Purpose: Represents a CharacterSheet for player
     * Programmer: Ki Bum Lee
     * @Player: The player for the charactersheet
     * @turn: Used to know which player's character sheet it is
     */
    public partial class CharacterSheet : Window
    {
        private Player player;
        private int turn;
        public CharacterSheet(Player p, int turn)
        {
            InitializeComponent();
            this.player = p;
            this.turn = turn;
            pImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory()+"\\Img\\" + player.getJob().getName+".png"));
            name.Text = player.getPlayerName;
            jobName.Text = player.getJobName();
            totalExpensesBox.Text = "$" + p.getJob().getTotalExpenses+"";
            cashFlowBox.Text = "$"+p.getJob().getCashFlow + "";
            savingsBox.Text = "$" + p.getJob().getSavings+"";
            loanLabel.Content = "$" + p.getJob().getLoan;
            foreach(Stocks s in player.getStocks())
            {
                stocksLabel.Text += "Name: " + s.getName+"\n";
                stocksLabel.Text += "Bought at: $" + s.getPrice +"\n";
                stocksLabel.Text += "# of shares: " + s.getAmount + "\n";
            }
            foreach(SmallDeal sd in player.getSmallDeals())
            {
                if(sd.getName.Equals("2BR/1BA"))
                {
                    propertiesBox.Text += sd.getName + "\n";
                    propertiesBox.Text += "Cash Flow: +$" + sd.getCashFlow + "\n";
                }
            }
        }

    }
}
