
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

namespace Day1
{
    public class Program
    {
        static Dictionary<string, char> numberWords = new Dictionary<string, char>()
    {
        {"one", '1'}, {"two", '2'}, {"three", '3'}, {"four", '4'},
        {"five", '5'}, {"six", '6'}, {"seven", '7'}, {"eight", '8'}, {"nine", '9'}
    };

        static void Main(string[] args)
        {
            int res = ReadFile();
            //int res = fileList.Sum(i => i);
            Console.WriteLine(res);

        }

        private static int ReadFile()
        {
            int counter = 0;
            List<int> valueList = new List<int>();
            try
            {
                String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                String fullName = Path.Combine(desktopPath, "a.txt");

                StreamReader sr = new StreamReader(fullName);

                var lines = File.ReadAllLines(fullName);
                foreach (var line in lines)
                {
                    var cleanLine = line
                        .Replace("one", "o1e")
                        .Replace("two", "t2o")
                        .Replace("three", "t3e")
                        .Replace("four", "f4r")
                        .Replace("five", "f5e")
                        .Replace("six", "s6x")
                        .Replace("seven", "s7n")
                        .Replace("eight", "e8t")
                        .Replace("nine", "n9e");

                    var firstNumber = cleanLine.First(Char.IsDigit);

                    var lastNumber = cleanLine.Last(Char.IsDigit);

                    var combinedNumber = firstNumber.ToString() + lastNumber.ToString();

                    counter += int.Parse(combinedNumber);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return counter;

        }

     
    }
}