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

        protected int CurrentValue
        {

            get { return danceFloor.GetPositionValue(Position); }
            set { danceFloor.SetPositionValue(Position, value); }
        }

        protected int Position { get { return IsLead ? danceFloor.LeadPosition : danceFloor.FollowPosition; } }

        protected DanceFloor danceFloor;

        internal virtual void Dance(DanceFloor danceFloor)
        {
            this.danceFloor = danceFloor;
        }

    }
}
