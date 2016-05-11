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
    }

    public enum RegisterDirection
    {
        Up,
        Down
    }
}
