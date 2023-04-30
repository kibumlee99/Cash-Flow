using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Flow
{
    /*
     * Purpose: Represents a DooDad card
     * @name, price: DooDad details
     */
    public class DooDad
      
    {
        private string name;
        private int price;
        public DooDad(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        /*
         * getters
         */
        public string getname => this.name;
        public int getPrice => this.price;
        //ToString
        public override string ToString()
        {
            return this.name + "\nPAY $" + price; 
        }
    }
}
