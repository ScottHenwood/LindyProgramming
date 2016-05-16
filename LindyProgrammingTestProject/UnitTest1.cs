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

        [TestMethod]
        public void ParseMoreThanOneLine()
        {
            string lindyCommandString = "Rock-step | Rock-step \n Step-step | Step-step";
            
            var parser = new LindyParser();
            string[] commandArray = parser.ParseCommandText(lindyCommandString);
            Assert.AreEqual(2, commandArray.Length);

            lindyCommandString += " \n Step-step | Step-step";
            commandArray = parser.ParseCommandText(lindyCommandString);
            Assert.AreEqual(3, commandArray.Length);
        }

        [TestMethod]
        public void ParseManyLinesOfCommands()
        {
            string[] lindyCommandString = { "Rock-step | Rock-step", "Step-step | Step-step" };

            var parser = new LindyParser();
            List<Tuple<string, string>> commandArray = parser.ParseCommandText(lindyCommandString);
            Assert.AreEqual(2, commandArray.Count);
            Assert.AreEqual("Rock-step", commandArray[0].Item1);
            Assert.AreEqual("Step-step", commandArray[1].Item2);

            //lindyCommandString.SetValue("Step-step | Step-step", 2);
            lindyCommandString = new [] { "Rock-step | Rock-step", "Step-step | Step-step", "Step-step | Step-step" };
            commandArray = parser.ParseCommandText(lindyCommandString);
            Assert.AreEqual(3, commandArray.Count);
        }
        
    }
}
