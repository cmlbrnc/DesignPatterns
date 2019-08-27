using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    // When integration of different system to our system  without broken our system . to get our system behaving different system integration
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager=new ProductManager(new Log4NetAdapter());

            productManager.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {

            _logger = logger;
        }


        public void Save()
        {
            _logger.Log("User saved");

            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class CbLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged,{0}",message);
        }
    }

    //Download from nuget . Imagine You cant manipulate the class below
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net,{0}",message);
        }
    }

    class Log4NetAdapter:ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net=new Log4Net();

            log4Net.LogMessage(message);
        }
    }
    //Api web service Adaptor 

    class BankApiAdaptor
    {
       //Some code
    }

}
