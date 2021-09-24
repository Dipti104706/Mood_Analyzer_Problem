using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mood_Analyzer_Problem;

namespace MsTestforMoodAnalyzer
{
    [TestClass]
    
    public class MsTestForMoodAnalyzer
    {
        [TestMethod]
        [TestCategory("negativescenario")]
        public void GivenNullShouldReturnHappy()
        {
            //AAA Methology

            //Arrange
            string excepted = "happy";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(null);

            //ACT
            string actual = moodAnalyser.AnalyzeMood();

            //ASSERT
            Assert.AreEqual(excepted, actual);
        }
    }
}
