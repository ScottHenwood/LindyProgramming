using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindyProgramingCompilier;
using LindyProgramingCompilier.Commands;

namespace LindyProgrammingTestProject
{
    [TestClass]
    public class CommandPairTest
    {
        private LindyParser _parser;

        [TestInitialize]
        public void Init()
        {
            _parser = new LindyParser();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void CreateCommandPair()
        {
            Tuple<string, string> commandPairTuple = new Tuple<string, string>("Rock-step", "Rock-step");
            LindyCommandPair commandPair = _parser.CreateCommandPair(commandPairTuple);
            Assert.IsNotNull(commandPair);
            LindyCommand leadCommand = commandPair.LeadCommand;
            Assert.IsNotNull(leadCommand);

            LindyCommand followCommand = commandPair.FollowCommand;
            Assert.IsNotNull(followCommand);
        }

        [TestMethod]
        public void CreateCommandPairMoveReg()
        {
            Tuple<string, string> commandPairTuple = new Tuple<string, string>("Rock-step", "Rock-step");
            LindyCommandPair commandPair = _parser.CreateCommandPair(commandPairTuple);
            
            Assert.IsInstanceOfType(commandPair.LeadCommand, typeof(MoveRegister));
            Assert.IsInstanceOfType(commandPair.FollowCommand, typeof(MoveRegister));

            Assert.AreEqual(RegisterDirection.Up, ((MoveRegister)commandPair.LeadCommand).Direction);
            Assert.AreEqual(RegisterDirection.Up, ((MoveRegister)commandPair.FollowCommand).Direction);


            commandPairTuple = new Tuple<string, string>("Rock-step", "Step-step");
            commandPair = _parser.CreateCommandPair(commandPairTuple);

            Assert.IsInstanceOfType(commandPair.LeadCommand, typeof(MoveRegister));
            Assert.IsInstanceOfType(commandPair.FollowCommand, typeof(MoveRegister));

            Assert.AreEqual(RegisterDirection.Up, ((MoveRegister)commandPair.LeadCommand).Direction);
            Assert.AreEqual(RegisterDirection.Down, ((MoveRegister)commandPair.FollowCommand).Direction);
        }

        [TestMethod]
        public void CreateCommandPairTriple()
        {
            LindyCommandPair commandPair = _parser.CreateCommandPair(new Tuple<string, string>("Triple-step", "Triple-step"));

            Assert.IsInstanceOfType(commandPair.LeadCommand, typeof(TripleStep));
            Assert.IsInstanceOfType(commandPair.FollowCommand, typeof(TripleStep));


        }

        [TestMethod]
        public void CreateCommandPairStepStep()
        {
            LindyCommandPair commandPair = _parser.CreateCommandPair(new Tuple<string, string>("Step-step", "Step-step"));

            Assert.IsInstanceOfType(commandPair.LeadCommand, typeof(StepStep));
            Assert.IsInstanceOfType(commandPair.FollowCommand, typeof(StepStep));


        }

    }
}
