
using System.Collections.Generic;
using System.Threading;

namespace Day1
{
    public class Program
    {
        private static String[] numbers = {
            "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static void Main(string[] args)
        {
            List<int> fileList = ReadFile();
            int res = fileList.Sum(i => i);
            Console.WriteLine(res);

        }

        private static List<int> ReadFile()
        {
            List<int> valueList = new List<int>();
            try
            {
                String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                String fullName = Path.Combine(desktopPath, "b.txt");

                StreamReader sr = new StreamReader(fullName);

                String line = sr.ReadLine();

                while (line != null)
                {
                    int value = HandleLine(line); 
                    valueList.Add(value);   
                    line = sr.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return valueList;

        }

        private static int HandleLine(String line)
        {
            int result = 0;
            String first = "null";
            String last = "null";
            int posF = 0;
            int posL = 0;

            for(int i=0; i<line.Length; i++)
            {
                if (Char.IsDigit(line[i]))
                {
                    if(first == "null")
                    {
                        first = Convert.ToString(line[i]);
                        posF = i;
                    }
                    else
                    {
                        last = Convert.ToString(line[i]);
                        posL = i;
                    }
                }
                
            }
            if(last == "null")
            {
                last = first;
                posL = posF;
            }

            
            List<String> wordsInLine = new List<String>();
            List<int> ind = new List<int>();


            foreach (String w in numbers)
            {
                AllIndexesOf(line, w, ind, wordsInLine);
            }

            if (ind.Count > 0)
            {
                if (posF > ind[0])
                {
                    first = GetNumber(wordsInLine[0]);
                }

                for (int i = 0; i < ind.Count; i++)
                {
                    if (posL < ind[i])
                    {
                        last = GetNumber(wordsInLine[i]);
                    }
                }
            }


            if (last == "null")
            {
                last = first;
            }
            try
            {

                result = Convert.ToInt32(first + last);
                return result;

            }

            catch (Exception e)
            {
                Console.WriteLine("Debug");

                for (int i = 0; i < ind.Count; i++)
                {
                    Console.Write(wordsInLine[i] + " ");

                }
            }

            return 0;

        }

        public static void AllIndexesOf(string str, string value, List<int> indexes, List<String> words)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return;
                indexes.Add(index);
                words.Add(value);


            }
        }

        private static String GetNumber(string str)
        {
            switch(str)
            {
                case "one": return "1";
                case "two": return "2";
                case "three": return "3";
                case "four": return "4";
                case "five": return "5";
                case "six": return "6";
                case "seven": return "7";
                case "eight": return "8";
                case "nine": return "9";
                default: return "0";

            }
        }
    }
}