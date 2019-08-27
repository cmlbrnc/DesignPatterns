using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DependecyInjection
{
    //IoC container Tools :ninject
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel =new StandardKernel();

            kernel.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();

            ProductManager productManager =new ProductManager(kernel.Get<IProductDal>());

            productManager.Save();

            Console.ReadLine();
        }
    }

    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save with Ef");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save with Nh");
        }
    }

    interface IProductDal
     {
         void Save();
     }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            _productDal.Save();
        }
    } 
}
