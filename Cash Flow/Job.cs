using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Flow
{
    /*
     * Purpose: Represents a job card
     * Programmer: Ki Bum Lee
     * 
     */
    public class Job
    {
        /*
         * Job card details
         */
        private string name;
        private int salary;
        private int totalExpenses;
        private int cashFlow;
        private int savings;
        private int loan;

        public Job(string name, int salary, int totalExpenses, int cashFlow, int savings, int loan)
        {
            this.name = name;
            this.salary = salary;
            this.totalExpenses = totalExpenses;
            this.cashFlow = cashFlow;
            this.savings = savings;
            this.loan = loan;
        }
        public Job()
        {

        }
        /*
         * getters/setters
         */
        public string getName => name;
        public int getSalary => salary;
        public int getTotalExpenses => totalExpenses;
        public int getCashFlow => cashFlow;
        public int getSavings => savings;
        public int getLoan => loan;
        public void setLoan(int loan)
        {
            this.loan = loan;
        }
        public void setSavings(int savings)
        {
            this.savings = savings;
        }
        public void setCashFlow(int cashFlow)
        {
            this.cashFlow = cashFlow;
        }
        public void setTotalExpenses(int totalExpenses)
        {
            this.totalExpenses = totalExpenses;
        }
        public void setSalary(int salary)
        {
            this.salary = salary;
        }
        //tostring method
        public string toString()
        {
            return this.name;
        }
    }
}
