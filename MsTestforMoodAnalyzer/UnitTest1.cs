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
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
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
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                obj = factory.CreateMoodAnalyzerObject("Mood_Analyzer_Problem.MoodAnalyzer", "MoodAnaly");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }

        public void GivenMoodAnalyzerUsingReflectionReturnClassException()
        {
            string expected = "Class not found";
            object obj = null;
            try
            {
                //ACT
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                obj = factory.CreateMoodAnalyzerObject("Mood_Analyzer_Problem.EmployeeWage", "EmployeeWage");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }

        //TC5.1 to get parameterized constructor by using Reflection
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyzerUsingReflectionReturnParameterizedConstructor()
        {
            string message = "I am in a happy mode";
            MoodAnalyzer expected = new MoodAnalyzer();
            object obj = null;
            try
            {
                //ACT
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                obj = factory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzer", "MoodAnalyzer",message);
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }
        
        //Negative scenarios for TC5.2
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyzerParamerterizedReflectionReturnConstructorException()
        {
            string message = "I am in a happy mode";
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                //ACT
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                obj = factory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzer", "MoodAnaly", message);
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
            catch (Exception ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //Negative scenarios for TC5.3
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenMoodAnalyzerParamerterizedReflectionReturnClassException()
        {
            string message = "I am in a happy mode";
            string expected = "Class not found";
            object obj = null;
            try
            {
                //ACT
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                obj = factory.CreateMoodAnalyzerParameterizedObject("EmployeeWage", "EmployeeWage",message);
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
            catch (Exception ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// TC6.1-Using Reflection-Invoke Method
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void Given_MoodAnalyzer_Reflection_Return_Method()
        {
            string expected = "happy";
            string actual = "";
            try
            {
                //ACT
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                actual = factory.InvokeAnalyzer("I am in happy mood", "AnalyzeMood");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                throw new Exception(ex.Message);
            }
            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        /// TC6.2-Giving improper method return happy
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void GivenInvalidmethodReturnhappy()
        {
            string expected = "happy";
            string actual = "";
            try
            {
                //ACT
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                actual = factory.InvokeAnalyzer("I am in happy mood", "Analyze");
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }       
        }
    }
}
