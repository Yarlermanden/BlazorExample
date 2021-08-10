using System;

namespace RegexGenerator.Helpers
{
    public interface IHelper
    {
        public void HelperMethod(string test);
    }
    public class Helper : IHelper
    {
        public void HelperMethod(string test)
        {
            Console.WriteLine(test);
        }
    }
}