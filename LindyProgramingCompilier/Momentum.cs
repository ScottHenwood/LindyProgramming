using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier
{
    public class Momentum
    {
        public bool IsLinear { get; set; }
        private bool _isMoving;
        public bool IsMoving { get { return _isMoving && !IsHanging; } set { _isMoving = value; } }
        public bool IsRotational { get; set; }

        public bool IsForward { get; set; }
        public bool IsHanging { get; set; }

        public void TippingPoint()
        {
            IsHanging = false;
        }

        public void Change()
        {
            IsHanging = true;
            IsForward = !IsForward;
        }


    }
}
