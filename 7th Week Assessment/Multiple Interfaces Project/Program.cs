using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritancewithInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            Console.WriteLine("Select account type:");
            Console.WriteLine("1. Savings account ( InterestRate = 0.4% ) ");
            Console.WriteLine("2. Current account ( InterestRate = 0.2% )");
            Console.WriteLine("3. Gold loan account( InterestRate = 0.8% )");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter person Name and pin and Accountbalance");
                    string name = Console.ReadLine();
                    int pin = int.Parse(Console.ReadLine());
                    double sbalance = Convert.ToDouble(Console.ReadLine());
                    double savingsInterest = account.CalculateSavingsInterest(sbalance);
                    Console.WriteLine($"Savings account interest of person:\n Person name: {name} \n Person pin :{pin} \n Person SavingsInterest: {savingsInterest}\n \n");
                    break;
                case 2:
                    Console.WriteLine("Enter person Name and pin and balance");
                    string cname = Console.ReadLine();
                    int cpin = int.Parse(Console.ReadLine());
                    double cbalance = Convert.ToDouble(Console.ReadLine());
                    double currentInterest = account.CalculateCurrentInterest(cbalance);
                    Console.WriteLine($"Current account interest: Person name: {cname} \n Person pin :{cpin} \n Person CurrentInterest: {currentInterest}\n \n");
                    break;
                case 3:
                    Console.WriteLine("Enter person Name and pin and balance");
                    string gname = Console.ReadLine();
                    int gpin = int.Parse(Console.ReadLine());
                    double gbalance = Convert.ToDouble(Console.ReadLine());
                    double goldLoanInterest = account.CalculateGoldInterest(gbalance);
                    Console.WriteLine($"Gold loan account interest:\n Person name: {gname} \n Person pin :{gpin} \n Person SavingsInterest: {goldLoanInterest}\n \n");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.ReadLine();
        }
    }
}
