using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Flow
{
    /*
     * Purpose: Represents a stock
     * @name, price, amount: Stock details
     */
    public class Stocks
    {
        string name;
        int price;
        int amount;
        
        public Stocks(string name, int price, int amount)
        {
            this.name = name;
            this.price = price;
            this.amount = amount;
        }
        /*
         * Getters/setter
         */
        public string getName => name;
        public int getPrice => price;
        public int getAmount => amount;
        public void setAmount(int amount) { this.amount = amount;}
    }
}
