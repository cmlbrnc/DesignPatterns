﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.creditCalculatorBase= new After2010CreditCalculator();
            customerManager.SaveCredit();

            Console.ReadLine();

        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator:CreditCalculatorBase
    {
        public override void Calculate()
        {
           Console.WriteLine("Credit calculated using before 2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
           Console.WriteLine("Credit calculated using after 2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase creditCalculatorBase { get; set; }          

        public void SaveCredit()
        {
            Console.WriteLine("Customer Manager business");
            creditCalculatorBase.Calculate();
        }
    }
}
