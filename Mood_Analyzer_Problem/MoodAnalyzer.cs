using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analyzer_Problem
{/// <summary>
/// uc3 to show custom exception message to user 
/// </summary>
    public class MoodAnalyzer
    {
        public string message;
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzer"/> class.
        /// </summary>
        /// <param name="message">The message.</param
        public MoodAnalyzer()
        {
            Console.WriteLine("Default Constructor");
        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            try
            {
                if (message.ToLower().Equals(string.Empty))
                {
                    throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.EMPTY_TYPE_EXCEPTION, "Message should not be empty");
                }
                else if (message.ToLower().Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.INVALID_MOOD_EXCEPTION,"Message should not be null");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
