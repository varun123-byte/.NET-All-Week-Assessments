using MultipleInheritancewithInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritancewithInterface
{
    class BankAccount : ISavingsAccount, ICurrentAccount, IGoldLoanAccount
    {
        public BankAccount() { }
        public double SavingsInterest { get; set; }
        public double CurrentInterest { get; set; }
        public double GoldInterest { get; set; }
        public double CalculateSavingsInterest(double sbalance)
        {
            return SavingsInterest = sbalance * 0.04;
        }
        public double CalculateCurrentInterest(double cbalance)
        {
            return CurrentInterest = cbalance * 0.02;
        }
        public double CalculateGoldInterest(double gbalance)
        {
            return GoldInterest = gbalance * 0.08;
        }      
    }
}


