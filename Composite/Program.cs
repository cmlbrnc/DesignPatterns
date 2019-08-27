using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {Employe cemil=new Employe
            {
                Name="Cemil"
            };
            Employe taner = new Employe
            {
                Name = "taner"
            };
            cemil.AddSubordinate(taner);
            Employe talip = new Employe
            {
                Name = "Talib"
            };
            taner.AddSubordinate(talip);

            Employe ahmet = new Employe
            {
                Name = "Ahmet"
            };

            Contractor mert=new Contractor{Name="ali"};

            taner.AddSubordinate(mert);

            cemil.AddSubordinate(ahmet);
            Console.WriteLine("{0}", cemil.Name);
            foreach (Employe manager in cemil)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employe in manager)
                {
                    Console.WriteLine("    {0}", employe.Name);
                }

            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
         string Name { get; set; }
    }

    class Contractor:IPerson
    {
        public string Name { get; set; }
    }

    class Employe:IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates=new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);

        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;

                //yield : Ienumertor should return iterable with the yield;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
