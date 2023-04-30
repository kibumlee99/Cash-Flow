using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Flow
{
    public class SmallDeal
    {
        /*
         * Purpose: Represents a small deal
         * Programmer: Ki Lee
         * @name, cost, downpayment, cashflow, info, isstock, ishouse, isCondo, isGoldCoin: All smalldeal details
         */
        private string name;
        private int cost;
        private int downPayment;
        private int cashFlow;
        private string info;
        private bool isStock;
        private bool isHouse;
        private bool isCondo;
        private bool isGoldCoin;
        public SmallDeal(string name, int cost, int downPayment, int cashFlow, string info, 
            bool isStock, bool isHouse, bool isCondo, bool isGoldCoin)
        {
            this.name = name;
            this.cost = cost;
            this.downPayment = downPayment;
            this.cashFlow = cashFlow;
            this.info = info;
            this.isStock = isStock;
            this.isHouse = isHouse;
            this.isCondo = isCondo;
            this.isGoldCoin= isGoldCoin;
        }
        /*
         * Getters
         */
        public int getCost => cost;
        public int getDownPayment => downPayment;
        public int getCashFlow => cashFlow;
        public string getInfo => info;
        public string getName => name;
        public bool getIsStock => isStock;
        public bool getIsHouse => isHouse;
        public bool getIsCondo => isCondo;
        public bool getIsGoldCoin => isGoldCoin;
        //ToString: Different if the smalldeal is a stock.
        override public string ToString()
        {
            if (this.isStock)
            {
                return this.name + " Stock" +
                    "\n" + this.info+
                    "\nToday's Price: " + cost;
            }
            else
                return this.name +
                    "\n" + this.info+
                "\nCost: " + cost+
                "\nDown Payment: " + downPayment +
                "\nCash Flow: " + cashFlow;
        }
    }
}
