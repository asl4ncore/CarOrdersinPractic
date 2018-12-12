using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Interfaces
{
    public interface IMeasure 
    {
        void FirstMeasure(Weigh weigh);
        void SecondMeasure(Weigh weigh);
        double? Total(Weigh weigh);
    }
}
