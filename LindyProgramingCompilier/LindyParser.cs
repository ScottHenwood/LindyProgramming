using LindyProgramingCompilier.Commands;
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
            LindyCommand leadCommand = null;
            LindyCommand followCommand = null;
            if (commandPair.Item1.ToLower().Equals("rock-step"))
            {
                leadCommand = new MoveRegister();
                if (commandPair.Item2.ToLower().Equals("rock-step"))
                {
                    followCommand = new MoveRegister();
                }
                else
                {
                    followCommand = new MoveRegister() { Direction = RegisterDirection.Down };
                }
                
            }
            else if (commandPair.Item1.ToLower().Equals("triple-step"))
            {
                leadCommand = new TripleStep();
                followCommand = new TripleStep();
            }
            else if (commandPair.Item1.ToLower().Equals("step-step"))
            {
                leadCommand = new StepStep();
                followCommand = new StepStep();
            }
            else
            {
                throw new ArgumentException("Not a valid command");
            }
            return new LindyCommandPair() { LeadCommand = leadCommand, FollowCommand = followCommand } ;
        }

        public LindyCommand CreateCommand(string commandText)
        {
            return new MoveRegister();
        }
    }
}
