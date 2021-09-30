using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Mood_Analyzer_Problem
{/// <summary>
/// UC5 to create object by using reflector and use parameterized constructor
/// </summary>
    public class ModeAnalyzerFactory
    {
        public object CreateMoodAnalyzerObject(string className, string constructor)
        {
            string pattern = "." + constructor + "$";
            Match result = System.Text.RegularExpressions.Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    //Extracting assembly
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    //creating type means class, by taking class name
                    Type moodAnalyzerType = assembly.GetType(className);
                    //Activator-predefined class, used to create object
                    //CreateInstance will create an instance , means it it give reference to object of the given class
                    var res = Activator.CreateInstance(moodAnalyzerType);
                    return res;
                }
                catch (Exception)
                {
                    throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }

        //Uc5 to create parametrized constructor
        public object CreateMoodAnalyzerParameterizedObject(string className, string constructor, string message)
        {
            try
            {
                //tyoeof() used to get the type
                Type type = typeof(MoodAnalyzer);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructor))
                    {
                        //typeof(string) for decide which constrtor we need perticularly
                        ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                        //Invoke() used to pass the message to that parameterized constructor
                        //Invoke() will return a object
                        var obj = constructorInfo.Invoke(new object[] { message });
                        return obj;
                    }
                    else
                    {
                        throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                    }
                }
                else
                {
                    throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
