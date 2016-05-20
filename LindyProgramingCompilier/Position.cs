using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier
{
    public class Position
    {
        public int Value { get; set; }

        internal void UseMomentum(Momentum currentMomentum)
        {
            if (currentMomentum.IsMoving && currentMomentum.IsLinear)
            {
                Value += 1;
            }
        }
    }
}
