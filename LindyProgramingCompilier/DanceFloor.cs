using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier
{
    public class DanceFloor
    {
        public int FollowPosition { get; set; } = 0;
        public int LeadPosition { get; set; } = 1;

        public void Run(LindyCommandPair commandPair)
        {
            //FollowPosition += 1;
            commandPair.FollowCommand.Dance(this);
            commandPair.LeadCommand.Dance(this);
            //LeadPosition += 1;
        }
    }
}
