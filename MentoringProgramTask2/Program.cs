using System;
using StringToIntParserLibrary;

namespace MentoringProgramTask2
{
    internal class Program
    {
        protected static void Main()
        {

            const int count = 5;
            var userStrings = new string[count];


            #region First solution of task2 part 1

            Console.WriteLine($"Input {count} strings:");
            var i = 0;
            while (i < count)
            {
                Console.Write($"{i + 1} : ");
                try
                {
                    var tempString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(tempString))
                        userStrings[i++] = tempString;
                    else
                        throw new ArgumentNullException($"Don't input string!");
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"First chars of string:");
            for (var j = 0; j < count; j++)
            {
                Console.WriteLine($"{j + 1} : {userStrings[j][0]}");
            }

            #endregion

            #region Second solution of task2 part 1

            Console.WriteLine($"Input {count} strings:");
            for (var j = 0; j < count; j++)
            {
                userStrings[j] = Console.ReadLine();
            }

            Console.WriteLine($"First chars of string:");
            for (var j = 0; j < count; j++)
            {
                try
                {
                    Console.WriteLine($"{j + 1} : {userStrings[j][0]}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Input empty string!");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Input null string!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            #endregion

            #region Test for task2 part 2

            try
            {
                Console.Write($"Integer number: ");
                var numString = Console.ReadLine();
                Console.WriteLine($"{numString.StringToIntParse()} was input");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            Console.ReadLine();
        }
    }
}
