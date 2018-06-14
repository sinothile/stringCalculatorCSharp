
using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var sum = 0;

            if (IsEmpty(numbers))
            {
                return 0;
            }

            if (numbers.StartsWith("//["))
            {
                numbers = RemoveMultipleCustomDelimeters(numbers);
            }

            if (numbers.StartsWith("//"))
            {
                numbers = RemoveOneCustomDelimeter(numbers);
            }

            var numberArray = numbers.Replace('\n', ',').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            ValidateNegativeNumbers(numberArray);

            sum = numberArray.Where(x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
            return sum;
        }

        private static string RemoveMultipleCustomDelimeters(string numbers)
        {
            var delimiter = numbers.Substring(3, numbers.IndexOf("]") - 3);
            numbers = numbers.Replace("//", string.Empty)
                     .Replace(delimiter, ",")
                     .Remove(0, 3)
                     .TrimStart('\n');

            if (numbers.StartsWith("["))
            {
                numbers = RemoveMultipleCustomDelimeters($"//{numbers}");
            }
            return numbers;
        }

        private static string RemoveOneCustomDelimeter(string numbers)
        {
            var delimiter = numbers[2];
            numbers = numbers.Replace("//", string.Empty)
                                .Replace(delimiter, ',')
                                .TrimStart(',')
                                .TrimStart('\n');
            return numbers;
        }

        public bool IsEmpty(string numbers)
        {
            return string.IsNullOrWhiteSpace(numbers);
        }
        public void ValidateNegativeNumbers(string[] numberArray)
        {
            var negativeNumbers = numberArray.Where(x => int.Parse(x) < 0);

            if (negativeNumbers.Any())
            {
                var negativeNumber = string.Join(" ", negativeNumbers);
                throw new Exception($"Negatives not allowed {negativeNumber}");
            }
        }

    }
}
