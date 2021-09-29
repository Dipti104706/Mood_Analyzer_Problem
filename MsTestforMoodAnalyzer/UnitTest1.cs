using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mood_Analyzer_Problem;

namespace MsTestforMoodAnalyzer
{
    [TestClass]  
    public class MsTestForMoodAnalyzer
    {
        //TC-3 given null will return customized null exception message
        [TestMethod]
        [TestCategory("Customexception")]
        public void GivenNullShouldReturnCustomNullException()
        {
            //AAA Methology

            //Arrange
            string expected = "Message should not be null";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(null);
            try
            {
                //ACT
                string actual = moodAnalyser.AnalyzeMood();
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }
        
        //TC-3 given empty will return customized empty  message
        [TestMethod]
        [TestCategory("Customexception")]
        public void GivenEmptyShouldReturnCustomEmptyException()
        {
            //AAA Methology

            //Arrange
            string expected = "Message should not be empty";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(string.Empty);
            try
            {
                //ACT
                string actual = moodAnalyser.AnalyzeMood();
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }

        /// TC-4 Create Default Constructor Using Reflection
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void Given_MoodAnalyzer_Using_Reflection_Return_defaultConstructor()
        {
            //Creating object of the class to test
            MoodAnalyzer expected = new MoodAnalyzer();
            object obj = null;
            try
            {
                //ACT
                //
                ModeAnalyzerFactory factory = new ModeAnalyzerFactory();
                obj = factory.CreateMoodAnalyzerObject("Mood_Analyzer_Problem.MoodAnalyzer", "MoodAnalyzer");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                throw new Exception(ex.Message);
            }
            obj.Equals(expected);
        }
        //For negative scenario, if class or constrotor name passed wrong it will give custom exception message
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyzerUsingReflectionReturnException()
        {
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                //ACT
                ModeAnalyzerFactory factory = new ModeAnalyzerFactory();
                obj = factory.CreateMoodAnalyzerObject("Mood_Analyzer_Problem.MoodAnalyzer", "MoodAnaly");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
