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
        private LindyCommand _followCommand;
        public LindyCommand FollowCommand
        {
            get { return _followCommand; }
            set { _followCommand = value; _followCommand.IsLead = false; }
        }

        private LindyCommand _leadCommand;
        public LindyCommand LeadCommand
        {
            get { return _leadCommand; }
            set { _leadCommand = value; _leadCommand.IsLead = true ; }
        }
        
    }
}
