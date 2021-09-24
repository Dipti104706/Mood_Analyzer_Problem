using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mood_Analyzer_Problem;

namespace MsTestforMoodAnalyzer
{
    [TestClass]
    [TestCategory("sadgroup")]
    public class MsTestForMoodAnalyzer
    {
        
        [TestMethod]
        public void GivenSadShouldReturnSad()
        {
            //AAA Methology

            //Arrange
            string excepted = "sad";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer("I am in a sad Mood");

            //ACT
            string actual = moodAnalyser.AnalyzeMood();

            //ASSERT
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        [TestCategory("happygroup")]
        public void GivenAnyShouldReturnHappy()
        {
            //AAA Methology

            //Arrange
            string excepted = "happy";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer("I am in any Mood");

            //ACT
            string actual = moodAnalyser.AnalyzeMood();

            //ASSERT
            Assert.AreEqual(excepted, actual);
        }
    }
}
