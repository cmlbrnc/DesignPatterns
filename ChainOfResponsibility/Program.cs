using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager=new Manager();
            VisePresident visePresident=new VisePresident();

            President president=new President();

            manager.SetSuccesor(visePresident);
            visePresident.SetSuccesor(president);

            Expense expense=new Expense{Detail = "Training",Amount=1001};

            manager.HandleExpense(expense);

            Console.ReadLine();

        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }

    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;

        public abstract void HandleExpense(Expense expense);

        public void SetSuccesor(ExpenseHandlerBase successor)
        {
            Successor = successor;

        }

    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handle the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            } 
           
        }
    }
    class VisePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <1000 && expense.Amount>100)
            {
                Console.WriteLine("Vice President handle the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }

        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine(" President handle the expense!");
            }
           

        }
    }
}
