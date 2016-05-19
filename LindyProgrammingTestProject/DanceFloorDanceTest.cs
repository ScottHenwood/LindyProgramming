using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindyProgramingCompilier;

namespace LindyProgrammingTestProject
{
    [TestClass]
    public class DanceFloorDanceTest
    {
        private LindyParser _parser;
        private DanceFloor _danceFloor;

        [TestInitialize]
        public void Init()
        {
            _parser = new LindyParser();
            _danceFloor = new DanceFloor();
        }


        
        [TestMethod]
        public void RunCommands()
        {
            Tuple<string, string> commandPairTuple = new Tuple<string, string>("Rock-step", "Rock-step");
            
            LindyCommandPair commandPair = _parser.CreateCommandPair(commandPairTuple);

            
            Assert.AreEqual(0, _danceFloor.FollowPosition);
            Assert.AreEqual(1, _danceFloor.LeadPosition);
            _danceFloor.Run(commandPair);

            Assert.AreEqual(1, _danceFloor.FollowPosition);
            Assert.AreEqual(2, _danceFloor.LeadPosition);

            _danceFloor.Run(commandPair);

            Assert.AreEqual(2, _danceFloor.FollowPosition);
            Assert.AreEqual(3, _danceFloor.LeadPosition);

            LindyCommandPair commandPair2 = _parser.CreateCommandPair(new Tuple<string, string>("Rock-step", "Step-step"));
            _danceFloor.Run(commandPair2);

            Assert.AreEqual(1, _danceFloor.FollowPosition);
            Assert.AreEqual(4, _danceFloor.LeadPosition);

        }

        [TestMethod]
        public void CommandPairTripleStep()
        {
            LindyCommandPair commandPair = _parser.CreateCommandPair(new Tuple<string, string>("Triple-step", "Triple-step"));
            Assert.AreEqual(0, _danceFloor.GetPositionValue(0));
            _danceFloor.Run(commandPair);
            Assert.AreEqual(0, _danceFloor.GetPositionValue(0));

            LindyCommandPair commandPair2 = _parser.CreateCommandPair(new Tuple<string, string>("Step-step", "Step-step"));

            _danceFloor.Run(commandPair2);
            Assert.AreEqual(2, _danceFloor.GetPositionValue(0));
            _danceFloor.Run(commandPair2);
            Assert.AreEqual(4, _danceFloor.GetPositionValue(0));
            Assert.AreEqual(4, _danceFloor.GetPositionValue(1));

            _danceFloor.Run(commandPair);
            Assert.AreEqual(12, _danceFloor.GetPositionValue(0));


        }

        [TestMethod]
        public void StepStepOnTheSpot()
        {
            // todo step[forward]-step[back]
        }
    }
}
