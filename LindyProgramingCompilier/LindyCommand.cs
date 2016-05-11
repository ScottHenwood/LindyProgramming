using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier
{
    public class LindyCommand
    {
        public bool IsLead { get; internal set; }

        internal virtual void Dance(DanceFloor danceFloor)
        {
            
        }
    }
}
