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

        private List<int> _floorValues;

        public DanceFloor()
        {
            _floorValues = new List<int>(100);
            for (int i = 0; i < 100; i++)
            {
                _floorValues.Add(0);
            }
        }

        internal void SetPositionValue(int index, int newValue)
        {
            _floorValues[index] = newValue;
        }

        public void Run(LindyCommandPair commandPair)
        {
            //FollowPosition += 1;
            commandPair.FollowCommand.Dance(this);
            commandPair.LeadCommand.Dance(this);
            //LeadPosition += 1;
        }

        internal string PositionValuesString()
        {
            return "f (" + FollowPosition + "): " + _floorValues[FollowPosition] + " & "
                + "l (" + LeadPosition + "): " + _floorValues[LeadPosition];
        }

        public int GetPositionValue(int index)
        {
            return _floorValues[index];
        }
    }
}
