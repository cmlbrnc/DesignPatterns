using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    //
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgortihm algortihm;
            
            Console.WriteLine("Men");

            algortihm=new MenScoringAlgorithm();

            Console.WriteLine(algortihm.GenerateScore(10,new TimeSpan(0,0,34)));

            Console.WriteLine("Women");
            algortihm = new WomenScoringAlgorithm();

            Console.WriteLine(algortihm.GenerateScore(10, new TimeSpan(0, 0, 34)));

            Console.WriteLine("Child");
            algortihm = new ChildScoringAlgorithm();

            Console.WriteLine(algortihm.GenerateScore(10, new TimeSpan(0, 0, 34)));

            Console.ReadLine();

        }
    }

    abstract class ScoringAlgortihm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);

            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateReduction(TimeSpan time);

        public abstract int CalculateOverallScore(int score, int reduction);


        public abstract int CalculateBaseScore(int hits);

    }

    class MenScoringAlgorithm:ScoringAlgortihm
    {
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 90;
        }
    }

    class ChildScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }
    }

}
