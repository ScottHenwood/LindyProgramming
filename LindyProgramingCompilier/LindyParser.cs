using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier
{
    public class LindyParser
    {
        public Tuple<string, string> ParseCommandPair(string basicCommandPair)
        {
            var commandPairArray = basicCommandPair.Split('|');
            return new Tuple<string, string>(commandPairArray[0].Trim(),commandPairArray[1].Trim());
        }

        public LindyCommandPair CreateCommandPair(Tuple<string, string> commandPair)
        {
            return new LindyCommandPair() { LeadCommand = new LindyCommand(), FollowCommand = new LindyCommand() } ;
        }

        public LindyCommand CreateCommand(string commandText)
        {
            return new LindyCommand();
        }
    }
}
