using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindyProgramingCompilier;

namespace LindyProgrammingTestProject
{
    [TestClass]
    public class MusicStreamTest
    {
        [TestMethod]
        public void CreateMusicStream()
        {
            MusicStream musicStream = new MusicStream();
            int nextValue = musicStream.NextValue;
        }
    }
}
