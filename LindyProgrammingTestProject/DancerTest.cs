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
        [ExpectedException(typeof(InvalidOperationException))]
        public void DancerNotDancing()
        {
            var dancer = new Dancer();

            var value = dancer.CurrentPosition.Value; // should throw
        }

        [TestMethod]
        public void DancerMoving()
        {
            var dancer = new Dancer();
            var floor = new DanceFloor();
            floor.AddDancer(dancer);
            dancer.Dance("RockStep");
            Assert.AreEqual(1, dancer.CurrentPosition.Value);
            dancer.TripleStep();
            Assert.AreEqual(2, dancer.CurrentPosition.Value);
            Assert.AreEqual(0, floor.GetPositionValue(dancer.CurrentPosition.Value));

            dancer.StepStep();
            Assert.AreEqual(3, dancer.CurrentPosition.Value);
            Assert.AreEqual(2, floor.GetPositionValue(dancer.CurrentPosition.Value));

            dancer.Dance(new DanceStep("StepStep") { Direction = "Change" });
            Assert.AreEqual(3, dancer.CurrentPosition.Value);
            Assert.AreEqual(4, floor.GetPositionValue(dancer.CurrentPosition.Value));

            dancer.Dance("StepStep");
            Assert.AreEqual(2, dancer.CurrentPosition.Value);
            Assert.AreEqual(2, floor.GetPositionValue(dancer.CurrentPosition.Value));

            var danceStep = DanceStep.Create("StepStep>Change");
            dancer.Dance(danceStep);
            Assert.AreEqual(2, dancer.CurrentPosition.Value);
            Assert.AreEqual(4, floor.GetPositionValue(dancer.CurrentPosition.Value));
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
