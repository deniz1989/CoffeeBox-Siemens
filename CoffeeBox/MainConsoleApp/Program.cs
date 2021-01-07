using System;

namespace MainConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //Example call
            EvaluateTestResult(1, true);
        }

        private static void EvaluateTestResult(int testCaseNumber, bool compareResult)
        {
            string result = compareResult ? "SUCCESS" : "FAIL";
            Console.WriteLine("TestCase" + testCaseNumber + ": " + result);
        }
    }
}
