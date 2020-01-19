using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCalculations.Models
{
    public static class KeepData
    {
        //public static ResultCalcul Result = new ResultCalcul();
        //public static List<ResultCalcul> ResultCalcul = new List<ResultCalcul>();
        public static Dictionary<int, ResultCalcul> Results = new Dictionary<int, ResultCalcul>();
        public static int CountId = 1;
    }

    public class ResultCalcul
    {
        public int id;
        public double ff = 7;
        public List<PressureLossCalculation.ResultModel> InputModels = new List<PressureLossCalculation.ResultModel>();
        public double Tr()
        {
            double sum = 0;
            for(int i = 1; i < InputModels.Count; i++)
            {
                sum = sum + InputModels[i].Pt;
            }
            return sum;
        }

        public double Tm()
        {
            double sum = 0;
            for (int i = 1; i < InputModels.Count; i++)
            {
                sum = sum + InputModels[i].Pm;
            }
            return sum;
        }

        public double Tg()
        {
            double sum = 0;
            for (int i = 1; i < InputModels.Count; i++)
            {
                sum = sum + InputModels[i].Pgem;
            }
            return sum;
        }

        public int Size()
        {
            return InputModels.Count - 1;
        }

        public double All()
        {
            return Tr() + Tm() + Tg();
        }
    }
}
