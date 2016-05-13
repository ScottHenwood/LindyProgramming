﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier.Commands
{
    public class StepStep : LindyCommand
    {
        internal override void Dance(DanceFloor danceFloor)
        {
            base.Dance(danceFloor);
            
            CurrentValue += 2;
        }
    }
}
