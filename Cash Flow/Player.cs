using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Flow
{
    /*
     * Purpose: Represent a player
     * Programmer: Ki Bum Lee
     */
    public class Player
    {
        /*
         * Player information
         * @position: the current position of the player in the board
         * @skippedTurns: How many turns the player was skipped (for downsize)
         */
        private string playerName;
        private Job job;
        private List<SmallDeal> smallDeals;
        private List<BigDeal> bigdeals;
        private List<Market> markets;
        private int position;
        private int goldCoins;
        private List<Stocks> stocks;
        private bool downsized;
        private int skippedTurns;
        public Player(String name) {
            playerName = name;
            smallDeals = new List<SmallDeal>();
            bigdeals = new List<BigDeal>();
            markets = new List<Market>();
            stocks = new List<Stocks>();
            job = new Job();
            position = 0;
            goldCoins = 0;
            downsized = false;
            skippedTurns = 0;
        }
        public string getPlayerName => playerName;
        //setJob: sets the job for player
        public void setJob(Job job)
        {
            this.job = job;
        }
        public void addSmallDeal(SmallDeal smalldeal)
        {
            smallDeals.Add(smalldeal);
        }
        public void addBigDeal(BigDeal bigdeal)
        {
            bigdeals.Add(bigdeal);
        }
        public void addMarket(Market market)
        {
            markets.Add(market);
        }
        public void removeSmallDeal(int i)
        {
            smallDeals.RemoveAt(i);
        }
        public void removeBigDeal(int i)
        {
            bigdeals.RemoveAt(i);
        }
        public void removeMarket(int i)
        {
            markets.RemoveAt(i);
        }
        public int getGoldCoins()
        {
            return goldCoins;
        }
        /*
         * addStocks: adds the stock to player, if player already has the stock then append to it.
         */
        public void addStocks(Stocks name)
        {
            if(hasStock(name.getName,out int i))
            {
                this.stocks[i].setAmount(this.stocks[i].getAmount + name.getAmount);
            }   
            else
            {
                this.stocks.Add(name);
            }
        }
        public void removeStocks(Stocks name)
        {
            hasStock(name.getName, out int i);
            if (stocks[i].getAmount - name.getAmount <= 0)
            {
                this.stocks.RemoveAt(i);
            }
            else
            {
                this.stocks[i].setAmount(stocks[i].getAmount - name.getAmount);
            }
        }
        public bool hasStock(string name, out int n)
        {
            int i = 0;
            foreach (Stocks s in this.stocks)
            {
                if (s.getName.Equals(name))
                {
                    n = i;
                    return true;
                }
                i++;
            }
            n = 0;
            return false;
        }
        public void setGoldCoins(int g)
        {
            goldCoins = g;
        }
        public string toString()
        {
            return this.playerName + " JOB: " + this.job.toString();
        }
        public string getJobName()
        {
            return this.job.toString();
        }
        public int getPosition()
        {
            return position;
        }
        public void setPosition(int position)
        {
            if (position >= 14)
            {
                this.position = 0;
            }
            else
            {
                this.position = position;
            }
        }
        public List<Stocks> getStocks() { return this.stocks; }
        public void setSavings(int s)
        {
            this.job.setSavings(s);
        }
        public Job getJob()
        {
            return this.job;
        }
        public void setDownsized(bool d)
        {
            this.downsized = d;
        }
        public bool isDownsized()
        {
            return this.downsized;
        }
        public void incSkippedTurns()
        {
            this.skippedTurns++;
            if(skippedTurns >= 2)
            {
                this.skippedTurns = 0;
                this.downsized = false;
            }
        }
        public List<SmallDeal> getSmallDeals()
        {
            return this.smallDeals;
        }
    }
}
