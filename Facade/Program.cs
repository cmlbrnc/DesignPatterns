using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        //Facade : Appearance
        static void Main(string[] args)
        {
            CustomerManger customerManger=new CustomerManger();

            customerManger.Save();

            Console.ReadLine();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface IValidation
    {
        void Validate();
    }

    class Validation : IValidation
    {
        public void Validate()
        {
            Console.WriteLine("Valited!");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManger
    {
        private CrossCuttingConcernsFacade _concerns;



        public CustomerManger()
        {
           _concerns=new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Validation.Validate();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;

        public ICaching Caching;

        public IAuthorize Authorize;

        public IValidation Validation;



        public CrossCuttingConcernsFacade()
        {

            Logging=new Logging();
            Caching=new Caching();
            Authorize=new Authorize();
            Validation = new Validation();

        }
    }
}
