using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindyProgramingCompilier;

namespace LindyProgrammingTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateLindyParser()
        {
            LindyParser parser = new LindyParser();
            Assert.IsNotNull(parser);
        }
        [TestMethod]
        public void ParseBasicCommandPair()
        {
            string basicCommandPair1 = "Rock-step | Rock-step";
            string basicCommandPair2 = "Rock-step | Step-step[forward]";
            var parser = new LindyParser();
            Tuple<string, string> commandPair = parser.ParseCommandPair(basicCommandPair1); // what does this return?
            Assert.AreEqual("Rock-step", commandPair.Item1);
            Assert.AreEqual("Rock-step", commandPair.Item2);

            Tuple<string, string> commandPair2 = parser.ParseCommandPair(basicCommandPair2); // what does this return?
            Assert.AreEqual("Rock-step", commandPair2.Item1);
            Assert.AreEqual("Step-step[forward]", commandPair2.Item2);
        }

        [TestMethod]
        public void CreateCommandPair()
        {
            Tuple<string, string> commandPairTuple = new Tuple<string, string>("Rock-step", "Rock-step");
            var parser = new LindyParser();
            LindyCommandPair commandPair = parser.CreateCommandPair(commandPairTuple);
            Assert.IsNotNull(commandPair);
            LindyCommand leadCommand = commandPair.LeadCommand;
            Assert.IsNotNull(leadCommand);

            LindyCommand followCommand = commandPair.FollowCommand;
            Assert.IsNotNull(followCommand);
        }

        [TestMethod]
        public void CreateLindyCommand()
        {
            var parser = new LindyParser();
            LindyCommand command = parser.CreateCommand("Rock-step");
            Assert.IsNotNull(command);

        }
    }
}
