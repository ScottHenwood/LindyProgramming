using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindyProgramingCompilier;

namespace LindyProgrammingTestProject
{
    [TestClass]
    public class DancerTest
    {
        [TestMethod]
        public void CreateDancer()
        {
            var dancer = new Dancer();
            Assert.IsNotNull(dancer);

            //dancer.StepStep();

            var methodInfo = dancer.GetFunction("StepStep");
            Assert.IsNotNull(methodInfo);
            var tripleStepMethod = dancer.GetFunction("TripleStep");
            Assert.IsNotNull(tripleStepMethod);

            Assert.IsNull(dancer.GetFunction("AnInvalidMethod"));
            

        }

        [TestMethod]
        public void RunDancerActions()
        {
            var dancer = new Dancer();
            var floor = new DanceFloor();
            floor.AddDancer(dancer);
            dancer.StepStep();
            Assert.AreEqual(2, floor.GetPositionValue(dancer.CurrentPosition.Value));

            dancer.Dance("StepStep");
            Assert.AreEqual(4, floor.GetPositionValue(dancer.CurrentPosition.Value));

            dancer.Dance("TripleStep");
            Assert.AreEqual(12, floor.GetPositionValue(dancer.CurrentPosition.Value));
        }

        [TestMethod]
        public void CreatePosition()
        {
            var position = new Position();
            Assert.AreEqual(0, position.Value);
        }

        [TestMethod]
        public void CreateMomentum()
        {
            var momentum = new Momentum();
            Assert.IsFalse(momentum.IsMoving);
            Assert.IsFalse(momentum.IsLinear);
            Assert.IsFalse(momentum.IsRotational);
        }
    }
}
