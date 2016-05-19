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

        public Position CurrentPosition { get; private set; }

        public void StepStep()
        {
            Floor.SetPositionValue(CurrentPosition.Value, _floor.GetPositionValue(CurrentPosition.Value) + 2);
        }

        public void TripleStep()
        {
            Floor.SetPositionValue(CurrentPosition.Value, _floor.GetPositionValue(CurrentPosition.Value) * 3);
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
