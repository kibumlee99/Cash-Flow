using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Flow
{
    public class Market
    {
        private bool isOffer;
        private bool isPositive;
        private bool isNegative;
        private string info;
        private string name;
        private int cost;

        public Market(string name, string info, int cost, bool isOffer, bool isPositive, bool isNegative) 
        {
            this.name = name;
            this.info = info;
            this.cost = cost;
            this.isOffer = isOffer;
            this.isPositive = isPositive;
            this.isNegative = isNegative;

        }
        public string getName => name;
        public string getInfo => info;
        public int getCost => cost;
        public bool getIsOffer => isOffer;
        public bool getIsPositive => isPositive;
        public bool getIsNegative => isNegative;
    }
}
