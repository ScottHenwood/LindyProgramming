using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindyProgramingCompilier;
using LindyProgramingCompilier.Commands;
using System.Collections.Generic;

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
        
    }
}
