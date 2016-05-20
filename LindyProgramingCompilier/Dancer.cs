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
            CurrentMomentum = new Momentum() { IsLinear = true, IsMoving = true, IsForward = true };
            CurrentPosition.UseMomentum(CurrentMomentum);
        }

        public MethodInfo GetFunction(string commandName)
        {
            return GetType().GetRuntimeMethods().FirstOrDefault((m) => m.Name == commandName);
        }

        public void Dance(string danceStepName)
        {
            var danceFunction = GetFunction(danceStepName);
            
            danceFunction?.Invoke(this, null);
            
        }

        public void Dance(DanceStep danceStep)
        {
            if (danceStep.HasDirection)
            {
                var directionFunction = CurrentMomentum.GetType().GetRuntimeMethods().FirstOrDefault((m) => m.Name == danceStep.Direction);
                directionFunction?.Invoke(CurrentMomentum, null);
            }

            Dance(danceStep.Name);
        }
    }

    public class DanceStep
    {
        public string Name { get; set; }
        public string Direction { get; set; }
        public bool HasDirection { get { return !string.IsNullOrEmpty(Direction); } }


        public DanceStep(string name)
        {
            this.Name = name;
        }

        public static DanceStep Create(string command)
        {
            var commands = command.Split('>');

            if (commands.Length > 1)
            {
                return new DanceStep(commands[0]) { Direction = commands[1] };
            }
            else
            {
                return new DanceStep(commands[0]);
            }
        }
    }
}
