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
        private List<Dancer> _dancers = new List<Dancer>();

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

        public void AddDancer(Dancer dancer)
        {
            _dancers.Add(dancer);
            dancer.Floor = this;
        }

        internal string PositionValuesString()
        {
            string outString = "";
            foreach (var dancer in _dancers)
            {
                outString += $"({dancer.CurrentPosition.Value}) = {_floorValues[dancer.CurrentPosition.Value]} | ";
            }
            return outString;
        }

        internal string ValueGrid()
        {
            string valueGrid = "";
            for (int i = 0; i < _floorValues.Count; i++)
            {
                var occupyingDancers = _dancers.Select((d) => d.CurrentPosition.Value == i);
                if (occupyingDancers.Any())
                {
                    valueGrid += $"  [{_floorValues[i]}]";
                }
                else
                {
                    valueGrid += $"  {_floorValues[i]}";
                }

                if ((i + 1) % 10 == 0)
                {
                    valueGrid += "\n";
                }
            }
            return valueGrid;
        }

        public int GetPositionValue(int index)
        {
            return _floorValues[index];
        }
    }
}
