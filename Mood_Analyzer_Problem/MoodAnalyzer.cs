using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analyzer_Problem
{/// <summary>
/// Analyzing user mood based on happy or sad word 
/// </summary>
    public class MoodAnalyzer
    {
        public string message;
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            try
            {
                if (message.ToLower().Contains("sad"))
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
                return "happy";
            }
            
        }
    }
}
