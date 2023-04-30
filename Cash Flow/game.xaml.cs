using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MySql.Data.MySqlClient;
namespace Cash_Flow
{
    /*
     * Purpose: All the logic of the game
     * Programmer: Ki Bum Lee
     * 
     */
    public partial class game : Window
    {
        private List<Player> playerList;
        private int playerCount;
        private Random rand;
        private int rolled;
        private System.Windows.Threading.DispatcherTimer timer;
        private int time;
        private int turn;
        private List<SmallDeal> smallDeals;
        private List<DooDad> doodads;
        private List<BigDeal> bigDeals;
        private List<Market> markets;
        private SmallDeal smallDrawn;
        private DooDad dooDrawn;
        private BigDeal bigDrawn;
        private Market marketDrawn;
        private bool isSmallDrawn;
        private bool isBigDrawn;
        private bool isMarketDrawn;
        private bool isDooDrawn;

        public game()
        {
            InitializeComponent();
            this.Title = "Cash Flow";
            turn = 1;
            time = 0;
            rand = new Random();
            playerList = new List<Player>();
            smallDeals = new List<SmallDeal>();
            doodads = new List<DooDad>();
            markets = new List<Market>();
            bigDeals= new List<BigDeal>();
            populateCards();
            isBigDrawn= false;
            isMarketDrawn= false;
            isSmallDrawn= false;
            isDooDrawn= false;
            disableARButton();
            disableDooDad();
            disableMarket();
            disableSmallBigs();
        }
        /*
         * Set: sets the player box images and information for all players.
         */
        public void set(List<Player> players)
        {

            this.playerList = players;
            turnLabel.Text = playerList[0].getPlayerName + "'s turn.";
            playerCount = playerList.Count;
            string jobName = "";
            for(int i = 0; i < playerCount; i++)
            {
                jobName = playerList[i].getJobName();
                if(i == 0)
                {
                    p1Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + jobName + ".png"));
                    p1Canvas.Visibility = Visibility.Visible;
                    p1piece.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + "p1piece" + ".png"));
                    p1nameLabel.Content = playerList[i].getPlayerName;
                    p1cashFlowLabel.Content = "$" + playerList[i].getJob().getCashFlow;
                    p1totexpenseLabel.Content = "$" + playerList[i].getJob().getTotalExpenses;
                    p1SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p1ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;

                }
                else if(i == 1)
                {
                    p2Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + jobName + ".png"));
                    p2Canvas.Visibility = Visibility.Visible;
                    p2piece.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + "p2piece" + ".png"));
                    p2nameLabel.Content = playerList[i].getPlayerName;
                    p2cashFlowLabel.Content = "$" + playerList[i].getJob().getCashFlow;
                    p2totexpenseLabel.Content = "$" + playerList[i].getJob().getTotalExpenses;
                    p2SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p2ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;


                }
                else if(i == 2)
                {
                    p3Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + jobName + ".png"));
                    p3Canvas.Visibility = Visibility.Visible;
                    p3piece.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + "p3piece" + ".png"));
                    p3nameLabel.Content = playerList[i].getPlayerName;
                    p3cashFlowLabel.Content = "$" + playerList[i].getJob().getCashFlow;
                    p3totexpenseLabel.Content = "$"+ playerList[i].getJob().getTotalExpenses;
                    p3SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p3ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;

                }
                else if(i == 3)
                {
                    p4Image.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + jobName + ".png"));
                    p4Canvas.Visibility = Visibility.Visible;
                    p4piece.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\" + "p4piece" + ".png"));
                    p4nameLabel.Content = playerList[i].getPlayerName;
                    p4cashFlowLabel.Content = "$"+playerList[i].getJob().getCashFlow;
                    p4totexpenseLabel.Content = "$"+playerList[i].getJob().getTotalExpenses;
                    p4SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p4ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;

                }
            }
        }
        /*
         * populateCards: Retrieves the game cards from database
         */
        public void populateCards()
        {
            MySqlConnection conn = new MySqlConnection("host=localhost;user=root;password=killon99;database=cashflow");
            string cmd = "SELECT * FROM smalldeal";
            MySqlCommand sqlcmd = new MySqlCommand(cmd, conn);
            conn.Open();
           MySqlDataReader reader = sqlcmd.ExecuteReader();
            while(reader.Read())
            {
               SmallDeal deal = new SmallDeal(reader.GetString("Name"),reader.GetInt32("Cost"),reader.GetInt32("DownPayment"),reader.GetInt32("CashFlow"),
                    reader.GetString("Info"),reader.GetBoolean("IsStock"),reader.GetBoolean("IsHouse"),reader.GetBoolean("IsCondo"),reader.GetBoolean("IsGoldCoin"));
                smallDeals.Add(deal);
            }
            conn.Close();
            cmd = "SELECT * FROM doodad";
            sqlcmd= new MySqlCommand(cmd, conn);
            conn.Open();
            reader = sqlcmd.ExecuteReader();
            while(reader.Read() )
            {
               DooDad doo = new DooDad(reader.GetString("Name"), reader.GetInt32("Price"));
                doodads.Add(doo);
            }
            conn.Close();

        }
        /*
         * rollButton_Click: Generates a random number between 1-3 and starts the timer
         */
        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            rolled = rand.Next(1, 4);
            rolledLabel.Content = rolled;
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick+= timer_Tick;
            rollButton.IsEnabled = false;
            timer.Start();
        }
        /*
         * timer_Tick: Movement of the pieces of the board. If the player is downsized, itll go to the next turn. 
         *             Increments time every second.
         *             Stops the animation once the time is the same value as the rolled number (1-3)
         */
        private void timer_Tick(Object sender, EventArgs e)
        {
            if (playerList[turn - 1].isDownsized())
            {
                playerList[turn - 1].incSkippedTurns();
                timer.Stop();
                nextTurn();
            }
            else
            {
                if (turn == 1)
                {
                    if (time < rolled)
                    {
                        if (playerList[0].getPosition() < 2)
                        {
                            Canvas.SetTop(p1piece, Canvas.GetTop(p1piece) - 96);
                            playerList[0].setPosition(playerList[0].getPosition() + 1);
                        }
                        else if (playerList[0].getPosition() < 7)
                        {
                            Canvas.SetLeft(p1piece, Canvas.GetLeft(p1piece) + 208);
                            playerList[0].setPosition(playerList[0].getPosition() + 1);
                        }
                        else if (playerList[0].getPosition() < 9)
                        {
                            Canvas.SetTop(p1piece, Canvas.GetTop(p1piece) + 96);
                            playerList[0].setPosition(playerList[0].getPosition() + 1);
                        }
                        else if (playerList[0].getPosition() < 14)
                        {
                            Canvas.SetLeft(p1piece, Canvas.GetLeft(p1piece) - 208);
                            playerList[0].setPosition(playerList[0].getPosition() + 1);
                        }
                    }
                }
                if (turn == 2)
                {
                    if (time < rolled)
                    {
                        if (playerList[1].getPosition() < 2)
                        {
                            Canvas.SetTop(p2piece, Canvas.GetTop(p2piece) - 96);
                            playerList[1].setPosition(playerList[1].getPosition() + 1);
                        }
                        else if (playerList[1].getPosition() < 7)
                        {
                            Canvas.SetLeft(p2piece, Canvas.GetLeft(p2piece) + 208);
                            playerList[1].setPosition(playerList[1].getPosition() + 1);
                        }
                        else if (playerList[1].getPosition() < 9)
                        {
                            Canvas.SetTop(p2piece, Canvas.GetTop(p2piece) + 96);
                            playerList[1].setPosition(playerList[1].getPosition() + 1);
                        }
                        else if (playerList[1].getPosition() < 14)
                        {
                            Canvas.SetLeft(p2piece, Canvas.GetLeft(p2piece) - 208);
                            playerList[1].setPosition(playerList[1].getPosition() + 1);
                        }
                    }

                }
                if (turn == 3)
                {
                    if (time < rolled)
                    {
                        if (playerList[2].getPosition() < 2)
                        {
                            Canvas.SetTop(p3piece, Canvas.GetTop(p3piece) - 96);
                            playerList[2].setPosition(playerList[2].getPosition() + 1);
                        }
                        else if (playerList[2].getPosition() < 7)
                        {
                            Canvas.SetLeft(p3piece, Canvas.GetLeft(p3piece) + 208);
                            playerList[2].setPosition(playerList[2].getPosition() + 1);
                        }
                        else if (playerList[2].getPosition() < 9)
                        {
                            Canvas.SetTop(p3piece, Canvas.GetTop(p3piece) + 96);
                            playerList[2].setPosition(playerList[2].getPosition() + 1);
                        }
                        else if (playerList[2].getPosition() < 14)
                        {
                            Canvas.SetLeft(p3piece, Canvas.GetLeft(p3piece) - 208);
                            playerList[2].setPosition(playerList[2].getPosition() + 1);
                        }
                    }

                }
                if (turn == 4)
                {
                    if (time < rolled)
                    {
                        if (playerList[3].getPosition() < 2)
                        {
                            Canvas.SetTop(p4piece, Canvas.GetTop(p4piece) - 96);
                            playerList[3].setPosition(playerList[3].getPosition() + 1);
                        }
                        else if (playerList[3].getPosition() < 7)
                        {
                            Canvas.SetLeft(p4piece, Canvas.GetLeft(p4piece) + 208);
                            playerList[3].setPosition(playerList[3].getPosition() + 1);
                        }
                        else if (playerList[3].getPosition() < 9)
                        {
                            Canvas.SetTop(p4piece, Canvas.GetTop(p4piece) + 96);
                            playerList[3].setPosition(playerList[3].getPosition() + 1);
                        }
                        else if (playerList[3].getPosition() < 14)
                        {
                            Canvas.SetLeft(p4piece, Canvas.GetLeft(p4piece) - 208);
                            playerList[3].setPosition(playerList[3].getPosition() + 1);
                        }
                        rollButton.IsEnabled = false;
                    }

                }
                checkPayDay();

                time++;

                if (time >= rolled)
                {

                    time = 0;
                    timer.Stop();
                    chooseCard();
                }
            }
           
        }
        /*
         * checkPayDay: Checks if the current player landed or passed payday and pays the player if they did
         */
        private void checkPayDay()
        {
            if (playerList[turn - 1].getPosition() == 3 || playerList[turn - 1].getPosition() == 13 && time != 0)
            {
                playerList[turn - 1].getJob().setSavings(playerList[turn - 1].getJob().getSavings + playerList[turn - 1].getJob()
                     .getCashFlow);
                update();

            }
        }
        /*
         * checkIfWon: Checks if a player is won by checking whether their cashflow is bigger than their Total Expenses
         */
        private void checkIfWon()
        {
            Player curr = playerList[turn - 1];
            if(curr.getJob().getCashFlow > curr.getJob().getTotalExpenses)
            {
                Winner winner = new Winner(curr);
                winner.ShowDialog();
                this.Close();
            }
        }
        /*
         * chooseCard: Checks which square the player is on and enables the card that he/she is on
         */
        private void chooseCard()
        {
            if (playerList[turn-1].getPosition() == 0)
            {
                nextTurn();
            }
            else if (playerList[turn-1].getPosition() == 1 || playerList[turn - 1].getPosition() == 4
                || playerList[turn - 1].getPosition() == 6 || playerList[turn - 1].getPosition() == 9
                || playerList[turn - 1].getPosition() == 11)
            {
                enableSmallBigs();

            }
            else if (playerList[turn - 1].getPosition() == 2|| playerList[turn - 1].getPosition() == 7
                || playerList[turn - 1].getPosition() == 12 )
            {
               rejectButton.IsEnabled = false;
                enableDooDad();
            }
            else if (playerList[turn - 1].getPosition() == 5 || playerList[turn - 1].getPosition() == 10)
            {
                enableMarket();
            }
            else if (playerList[turn-1].getPosition() == 8)
            {
                playerList[turn - 1].setDownsized(true);
                if (playerList[turn - 1].getJob().getSavings - playerList[turn - 1].getJob().getTotalExpenses >= 0)
                {
                    playerList[turn - 1].setSavings(playerList[turn - 1].getJob().getSavings - playerList[turn - 1].getJob().getTotalExpenses);
                    update();
                    nextTurn();
                }
                else
                {
                    Loan loan = new Loan(playerList[turn - 1],true);
                    loan.ShowDialog();
                    if (loan.tookLoan())
                    {
                        int amount = loan.getAmount();
                        playerList[turn - 1].setSavings((playerList[turn - 1].getJob().getSavings + amount) - playerList[turn-1].getJob().getTotalExpenses);
                        playerList[turn - 1].getJob().setCashFlow(playerList[turn-1].getJob().getCashFlow - Convert.ToInt32((amount * 0.1)));
                        playerList[turn - 1].getJob().setLoan(playerList[turn - 1].getJob().getLoan + amount);
                        update();
                        nextTurn();
                    }
     


                }
            }
            else if (playerList[turn - 1].getPosition() == 3 || playerList[turn - 1].getPosition() == 13)
            {
                nextTurn();

            }
        }
        /*
         * enableSmallBigs: Enables the small and big deal buttons
         */
        private void enableSmallBigs()
        {
            smallDeal.IsEnabled = true;
            bigDeal.IsEnabled = true;
        }
        /*
         * disableSmallBigs: Disables the small/bigs button
         */
        private void disableSmallBigs()
        {
            smallDeal.IsEnabled = false; bigDeal.IsEnabled = false;
        }
        /*
         * enableMarket: Enables the market button.
         */
        private void enableMarket()
        {
            Market.IsEnabled = true;
        }
        /*
         * diableMarket: disables the market buttons.
         */
        private void disableMarket()
        {
            Market.IsEnabled = false;
        }
        /*
         * enableDooDad: enables the doodad button.
         */
        private void enableDooDad()
        {
            dooDad.IsEnabled = true;
        }
        /*
         * disablesDooDad: disables the doodad button.
         */
        private void disableDooDad()
        {
            dooDad.IsEnabled = false;
        }
        /*
         * smallDeal_Click: Displays small card when the smallDeal button is clicked.
         *                  Accept/Reject button becomes available
         */
        private void smallDeal_Click(object sender, RoutedEventArgs e)
        {
            int i = rand.Next(0, smallDeals.Count);
            smallDrawn = smallDeals[i];
            cardName.Text = smallDrawn.getName;
            cardInfo.Text = smallDrawn.getInfo;
            cardCost.Text = "Cost: $"+smallDrawn.getCost;
            cardDownpayment.Text = "Down Payment: $" + smallDrawn.getDownPayment;
            cashFlow.Text = "Cash Flow: $" + smallDrawn.getCashFlow;
            isSmallDrawn = true;
            disableSmallBigs();
            enableARButton();
        }
        /*
         * acceptButton_Click: For when the accept button is clicked. 
         *                     Does the correct action for whichever card the player chose.
         */
        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            Player curr = playerList[turn - 1];
            bool doneAction = true;
            if(isSmallDrawn)
            {
                if(curr.getJob().getSavings < smallDrawn.getDownPayment)
                {
                    Message m = new Message("Not enough money.\nEither take out a loan or Reject");
                    m.ShowDialog();
                    doneAction = false;
                }
                else if(smallDrawn.getIsHouse || smallDrawn.getIsCondo) 
                {
                    curr.setSavings(curr.getJob().getSavings - smallDrawn.getDownPayment);
                    curr.getJob().setCashFlow(curr.getJob().getCashFlow + smallDrawn.getCashFlow);
                    curr.addSmallDeal(smallDrawn);
                }
                else if(smallDrawn.getIsGoldCoin)
                {
                    curr.setGoldCoins(curr.getGoldCoins() + smallDrawn.getCashFlow);
                }
                else if(smallDrawn.getIsStock)
                {
                    Stocks stock = new Stocks(smallDrawn.getName, smallDrawn.getCost, 0);
                    if (!curr.hasStock(smallDrawn.getName, out int n))
                    {
                        int savings = curr.getJob().getSavings;
                        BuyStocks bs = new BuyStocks(smallDrawn, savings);
                        bs.ShowDialog();
                        int amount = bs.getAmount();
                        stock = new Stocks(smallDrawn.getName, smallDrawn.getCost, amount);
                        amount *= smallDrawn.getCost;
                        curr.setSavings(curr.getJob().getSavings - amount);
                        update();
                        curr.addStocks(stock);
                    }
                   
                        startSellStocks(stock);
                    
                    
                }
            }
            else if(isDooDrawn)
            {
                if(dooDrawn.getPrice > curr.getJob().getSavings)
                {
                    Debug.WriteLine(curr.getJob().getSavings + "::" + dooDrawn.getPrice);
                    Message message = new Message("Not enough money, take out a loan.");
                    message.ShowDialog();
                    doneAction = false;
                }
                else
                {
                    curr.getJob().setSavings(curr.getJob().getSavings - dooDrawn.getPrice);
                }
            }
            if (doneAction)
            {
                
                update();
                nextTurn();
            }
        }
        /*
         * rejectButton_Click: For when the reject button is clicked. If its a stock then it starts the selling process then moves to next turn.
         *                     
         */
        private void rejectButton_Click(object sender, RoutedEventArgs e)
        {
            if(isSmallDrawn)
            {
                if(smallDrawn.getIsStock)
                {
                    Stocks s = new Stocks(smallDrawn.getName, smallDrawn.getCost, 0);
                    startSellStocks(s);
                }
            }
            nextTurn();
        }
        /*
         * nextTurn: Changes the turn to the next player.
         */
        private void nextTurn()
        {
            update();
            resetDrawn();
            turn++;
            rollButton.IsEnabled = true;
            disableARButton();
            disableDooDad();
            disableMarket();
            if (turn > playerCount)
            {
                turn = 1;
            }
            turnLabel.Text = playerList[turn - 1].getPlayerName + "'s turn.";
        }
        /*
         * resetDrawn: resets the drawn card.
         */
        private void resetDrawn()
        {
            this.isSmallDrawn= false;
            this.isBigDrawn= false;
            this.isDooDrawn= false;
            this.isMarketDrawn= false;
        }
        /*
         * enableARButton: Enables accept/reject button
         */
        private void enableARButton()
        {
            acceptButton.IsEnabled = true;
            rejectButton.IsEnabled = true;
        }
        /*
         * disableARButton: disables accept/reject button
         */
        private void disableARButton()
        {
            acceptButton.IsEnabled = false;
            rejectButton.IsEnabled = false;
        }
        /*
         * startSellStocks: Starts the process of selling stocks. Goes through each player who has stock and asks if they want to sell.
         */
        private void startSellStocks(Stocks s)
        {
            int j = 0;
           foreach(Player p in playerList)
            {
                if(p.hasStock(s.getName,out int i))
                {
                    SellStocks sell = new SellStocks(p,s, i);
                    sell.ShowDialog();
                    if(sell.didSell())
                    {
                        int n = sell.getAmount();
                        p.setSavings(p.getJob().getSavings + (p.getStocks()[i].getAmount * s.getPrice));
                        p.getStocks().RemoveAt(i);
                        update();
                    }
                }
                j++;
            }
        }
        /*
         * update: Updates all the display labels and progress bar for each player.
         */
        private void update()
        {
            for(int i = 0; i < playerList.Count; i++)
            {
                if (i == 0)
                {

                    p1cashFlowLabel.Content = "$" + (playerList[i].getJob().getCashFlow);
                    p1totexpenseLabel.Content = "$" + playerList[i].getJob().getTotalExpenses;
                    p1SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p1ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;
                    Debug.WriteLine("PROGRESS: " + (playerList[i].getJob().getCashFlow / playerList[i].getJob().getTotalExpenses) * 100);
                }
                else if (i == 1)
                {
                    p2cashFlowLabel.Content = "$" + (playerList[i].getJob().getCashFlow);
                    p2totexpenseLabel.Content = "$" + playerList[i].getJob().getTotalExpenses;
                    p2SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p2ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;


                }
                else if (i == 2)
                {
                    p3cashFlowLabel.Content = "$" + (playerList[i].getJob().getCashFlow);
                    p3totexpenseLabel.Content = "$" + playerList[i].getJob().getTotalExpenses;
                    p3SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p3ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;
                }
                else if (i == 3)
                {
                    p4cashFlowLabel.Content = "$" + (playerList[i].getJob().getCashFlow);
                    p4totexpenseLabel.Content = "$" + playerList[i].getJob().getTotalExpenses;
                    p4SavingsLabel.Content = "$" + playerList[i].getJob().getSavings;
                    p4ProgressBar.Value = (Convert.ToDouble(playerList[i].getJob().getCashFlow) / playerList[i].getJob().getTotalExpenses) * 100;

                }
            }
        }
        /*
         * dooDad_Click: For when the DooDad Button is clicked. Displays the doodad card. Player can only accept
         */
        private void dooDad_Click(object sender, RoutedEventArgs e)
        {
            isDooDrawn = true;
            dooDad.IsEnabled = false;
            int n = rand.Next(0, doodads.Count);
            dooDrawn = doodads[n];
            cardName.Text = dooDrawn.getname;
            cardCost.Text = "Cost: $"+dooDrawn.getPrice+"";
            cardInfo.Text = "You must pay";
            cardDownpayment.Text = "$0";
            cashFlow.Text = "$0";
            acceptButton.IsEnabled = true;
        }
        /*
         * Market_Click: For when the market card is clicked. 
         */
        private void Market_Click(object sender, RoutedEventArgs e)
        {
            isMarketDrawn= true;
            Market.IsEnabled= false;
            enableARButton();
        }
        /*
         * loanButton_Click: for when the loan button is clicked.
         */
        private void loanButton_Click(object sender, RoutedEventArgs e)
        {
            Loan loan = new Loan(playerList[turn-1],false);
            loan.ShowDialog();
            if(loan.tookLoan())
            {
                playerList[turn - 1].getJob().setSavings(playerList[turn - 1].getJob().getSavings + loan.getAmount());
                playerList[turn - 1].getJob().setCashFlow(playerList[turn - 1].getJob().getCashFlow - Convert.ToInt32(loan.getAmount() * 0.1));
                playerList[turn - 1].getJob().setLoan(playerList[turn - 1].getJob().getLoan + loan.getAmount());
                update();
            }
        }
        /*
         * Methods for when the character box images is clicked. Displays character sheet.
         */
        private void p1_MouseDown(object sender, MouseEventArgs e)
        {
            CharacterSheet cs = new CharacterSheet(playerList[0], turn);
            cs.ShowDialog();
        }
        private void p2_MouseDown(object sender, MouseEventArgs e)
        {
            CharacterSheet cs = new CharacterSheet(playerList[1], turn);
            cs.ShowDialog();
        }
        private void p3_MouseDown(object sender, MouseEventArgs e)
        {
            CharacterSheet cs = new CharacterSheet(playerList[2], turn);
            cs.ShowDialog();
        }
        private void p4_MouseDown(object sender, MouseEventArgs e)
        {
            CharacterSheet cs = new CharacterSheet(playerList[3], turn);
            cs.ShowDialog();
        }
        /*
         * exitButton_Click: closes the game when Quit button is clicked.
         */
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
