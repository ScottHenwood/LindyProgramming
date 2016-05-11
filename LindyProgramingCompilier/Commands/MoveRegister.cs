using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier.Commands
{
    public class MoveRegister : LindyCommand
    {
        public RegisterDirection Direction { get; set; }

        internal override void Dance(DanceFloor danceFloor)
        {
            int amount = 0;
            switch (Direction)
            {
                case RegisterDirection.Up:
                    amount = 1;
                    break;
                case RegisterDirection.Down:
                    amount = -1;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (IsLead)
            {
                danceFloor.LeadPosition += amount;
            }
            else
            {
                danceFloor.FollowPosition += amount;
            }

            base.Dance(danceFloor);
        }
    }

    public enum RegisterDirection
    {
        Up,
        Down
    }
}
