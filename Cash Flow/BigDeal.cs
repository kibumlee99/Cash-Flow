using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Flow
{
    public class BigDeal
    {
        /*
         * Purpose: Represents a big deal
         * Programmer: Ki Bum Lee
         * @name: name of the deal
         * @cost: cost of the deal
         * @downpayment: downpayment of deal
         * @cashflow: How much cashflow the deal is worth
         */
        private string name;
        private int cost;
        private int downpayment;
        private int cashflow;
        public BigDeal(string name, int cost, int downpayment, int cashflow)
        {
            this.name = name;
            this.cost = cost;
            this.downpayment = downpayment;
            this.cashflow = cashflow;
        }
        /*
         * getters
         */
        public string getName => this.name;
        public int getCost => this.cost;
        public int getDownPayment => this.downpayment;
        public int cashFlow => this.cashFlow;
        //ToString
        public override string ToString()
        {
            return this.name +
                "\nCost: " + this.cost +
                "\nDown Payment: " + this.downpayment +
                "\nCash Flow: " + this.cashflow;
        }
    }
}
