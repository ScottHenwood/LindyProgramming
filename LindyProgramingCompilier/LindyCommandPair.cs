using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier
{
    public class LindyCommandPair
    {
        public string CommandActions { get; protected set; }
        public LindyCommand FollowCommand { get; set; }
        public LindyCommand LeadCommand { get; set; }
    }
}
