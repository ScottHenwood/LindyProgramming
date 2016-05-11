using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindyProgramingCompilier;
using LindyProgramingCompilier.Commands;

namespace LindyProgrammingTestProject
{
    [TestClass]
    public class CommandPairTest
    {
        private LindyParser Parser;

        [TestInitialize]
        public void Init()
        {
            Parser = new LindyParser();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void CreateCommandPair()
        {
            Tuple<string, string> commandPairTuple = new Tuple<string, string>("Rock-step", "Rock-step");
            LindyCommandPair commandPair = Parser.CreateCommandPair(commandPairTuple);
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
            LindyCommandPair commandPair = Parser.CreateCommandPair(commandPairTuple);
            
            Assert.IsInstanceOfType(commandPair.LeadCommand, typeof(MoveRegister));
            Assert.IsInstanceOfType(commandPair.FollowCommand, typeof(MoveRegister));

            Assert.AreEqual(RegisterDirection.Up, ((MoveRegister)commandPair.LeadCommand).Direction);
            Assert.AreEqual(RegisterDirection.Up, ((MoveRegister)commandPair.FollowCommand).Direction);


            commandPairTuple = new Tuple<string, string>("Rock-step", "Step-step");
            commandPair = Parser.CreateCommandPair(commandPairTuple);

            Assert.IsInstanceOfType(commandPair.LeadCommand, typeof(MoveRegister));
            Assert.IsInstanceOfType(commandPair.FollowCommand, typeof(MoveRegister));

            Assert.AreEqual(RegisterDirection.Up, ((MoveRegister)commandPair.LeadCommand).Direction);
            Assert.AreEqual(RegisterDirection.Down, ((MoveRegister)commandPair.FollowCommand).Direction);


        }

    }
}
