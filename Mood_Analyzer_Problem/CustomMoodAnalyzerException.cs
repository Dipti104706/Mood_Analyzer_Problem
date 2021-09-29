using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analyzer_Problem
{
    public class CustomMoodAnalyzerException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            INVALID_MOOD_EXCEPTION,
            EMPTY_TYPE_EXCEPTION,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
        }

        public CustomMoodAnalyzerException(ExceptionType type,string massage):base(massage)
        {
            this.type = type;
        }
    }
}
