using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LindyProgramingCompilier
{
    public class Dancer
    {
        private DanceFloor _floor;
        public DanceFloor Floor {
            get { return _floor; }
            internal set {
                _floor = value;
                CurrentPosition = new Position();
            }
        }

        private Position _currentPosition;
        public Position CurrentPosition
        {
            get
            {
                if (_currentPosition == null)
                {
                    throw new InvalidOperationException("The dancer is not on a dance floor!");
                }
                else
                {
                    return _currentPosition;
                }
            }
            private set { _currentPosition = value; }
        }

        public Momentum CurrentMomentum { get; private set; } = new Momentum();

        public void StepStep()
        {
            CurrentPosition.UseMomentum(CurrentMomentum);
            Floor.SetPositionValue(CurrentPosition.Value, _floor.GetPositionValue(CurrentPosition.Value) + 2);
        }

        public void TripleStep()
        {
            CurrentPosition.UseMomentum(CurrentMomentum);
            Floor.SetPositionValue(CurrentPosition.Value, _floor.GetPositionValue(CurrentPosition.Value) * 3);
        }

        public void RockStep()
        {
            CurrentMomentum = new Momentum() { IsLinear = true, IsMoving = true };
            CurrentPosition.UseMomentum(CurrentMomentum);
        }

        public MethodInfo GetFunction(string commandName)
        {
            return GetType().GetRuntimeMethods().FirstOrDefault((m) => m.Name == commandName);
        }

        public void Dance(string danceStepName)
        {
             var danceFunction = GetFunction(danceStepName);
            if (danceFunction != null)
            {
                danceFunction.Invoke(this, null);
            }
        }
    }
}
