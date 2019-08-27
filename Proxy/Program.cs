using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    //Caching System
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase manager=new CreditManagerProxy();

           Console.WriteLine(manager.Calc());
           Console.WriteLine(manager.Calc());

            Console.ReadLine();
        }
    }

    abstract class CreditBase
    {
        public abstract int Calc();
    }

    class CreditManager:CreditBase
    {
        public override int Calc()
        {
            int result = 1;
            for (int i = 0; i < 2; i++)
            {
                result *= i;
                Thread.Sleep(1000);

               
            }

            return result;
        }
    }

    class CreditManagerProxy:CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calc()
        {
            if (_creditManager == null)
            {
                _creditManager =new CreditManager();

                _cachedValue = _creditManager.Calc();

            }

            return _cachedValue;
        }
    }
}
