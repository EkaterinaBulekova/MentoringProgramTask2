using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringToIntParserLibrary
{
    /// <summary>
    /// A class that provide parse from string to integer functionality
    /// </summary>
    public static class StringToIntParser
    {
        private static readonly Dictionary<char, int> Digits = new Dictionary<char, int>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
        };

        /// <summary>
        /// Extention method for String type that convert string to integer 
        /// </summary>
        /// <param name="str"> A string that represents some number </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <returns> Integer that was represented in string </returns>
        public static int StringToIntParse(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(string.Empty, $"String is empty");

            var resultInt = 0;
            var isNegative = false;
            var rgx = new Regex(@"^-?\d+");

            if (!rgx.IsMatch(str)) throw new FormatException($"Wrong format of number");
            if (str[0] == '-')
            {
                str = str.Substring(1);
                isNegative = true;
            }

            var power = str.Length - 1;
            if (power > 9) throw new OverflowException($"Too long number");
            foreach (var chr in str)
            {
                try
                {
                    checked
                    {
                        resultInt += Digits[chr] * GetMultiplier(power--);
                    }
                }
                catch (OverflowException)
                {
                    throw new OverflowException($"Too long number");
                }
            }

            return isNegative ? -1 * resultInt : resultInt;
        }

        private static int GetMultiplier(int power)
        {
            var multipier = 1;
            for (var j = 0; j < power; j++)
            {
                multipier *= 10;
            }

            return multipier;
        }
    }
}
