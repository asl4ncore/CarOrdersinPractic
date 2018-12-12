using Practic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practic.Models;

namespace Practic.Infrastructure.Business
{
    public static class MeasureMath //: IMeasure
    {
        public static int FirstWeighFull { get; set; }
        public static double? FirstWeighPacking { get; set; }
        public static int FirstId { get; set; }
        public static int SecondWeighFull { get; set; }
        public static double? SecondWeighPacking { get; set; }
        public static int SecondId { get; set; }

        public static void FirstMeasure(Weigh weigh)
        {
            if (weigh.WeighPacking == null)
            {
                weigh.WeighPacking = 0;
            }
            MeasureMath.FirstWeighPacking = weigh.WeighPacking;
            MeasureMath.FirstWeighFull = weigh.WeighFull;
            MeasureMath.FirstId = weigh.OrderId;
        }

        public static void SecondMeasure(Weigh weigh)
        {
            if (weigh.WeighPacking == null)
            {
                weigh.WeighPacking = 0;
            }
            MeasureMath.SecondWeighPacking = weigh.WeighPacking;
            MeasureMath.SecondWeighFull = weigh.WeighFull;
            MeasureMath.SecondId = weigh.OrderId;
        }
        public static void SelectMeasure(Weigh weigh)
        {
            if (weigh.WeighDetermine == false)
            {
                MeasureMath.SecondMeasure(weigh);
            }
             if (weigh.WeighDetermine == true)
            {
                MeasureMath.FirstMeasure(weigh);
            }
            Total(weigh);
        }
        public static void  Total(Weigh weigh)
        {
            if (MeasureMath.FirstId== MeasureMath.SecondId)
            {
                weigh.WeighMaterial = MeasureMath.SecondWeighFull - MeasureMath.SecondWeighPacking - MeasureMath.FirstWeighFull - MeasureMath.FirstWeighPacking;
            } 
        }


    }
}
