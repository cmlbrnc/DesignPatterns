using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        // 
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Brand="BMW",Model="3.2",HirePrice =2500};

            SpecailOffer specailOffer=new SpecailOffer(personalCar);
            specailOffer.DiscountPercentage = 10;
            Console.WriteLine("Special offer:{0}",specailOffer.HirePrice);
            Console.WriteLine("Concrete :{0}", personalCar.HirePrice);

            Console.ReadLine();

        }
    }

    abstract class CarBase
    {
        public abstract string Brand { get; set; }

        public abstract string Model { get; set; }

        public  abstract  decimal HirePrice { get; set; }
    }

    class PersonalCar:CarBase
    {

        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecailOffer:CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;

        public SpecailOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Brand { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get { return _carBase.HirePrice-_carBase.HirePrice*DiscountPercentage/100; }
            set
            {

            }
        }
    }
}
