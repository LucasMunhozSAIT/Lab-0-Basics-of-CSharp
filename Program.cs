using System;
using System.Buffers.Text;

namespace Lab0BasicsOfCSharp;

class Program
{
    static void Main(string[] args)
    {
        // Task 1: Creating Variables;
        // Task 2: Looping and input Validation;
        Console.WriteLine("Task 1: Creating Variables");
        Console.WriteLine("Task 2: Looping and Input Validation");
        Console.WriteLine("Task 3: Using Arrays and File I/O\n");

        Console.WriteLine("Please enter a low number");
        int lowNum = GetPositiveLowNumber();
        Console.WriteLine("Please enter a high number");
        int highNum = GetHighNumber(lowNum);

        int difference = highNum - lowNum;
        Console.WriteLine($"The difference between {highNum} and {lowNum} is: {difference}.\n");

        // Task 3: Using Arrays and File I/O;
        int[] inputsArray = NumberArray(lowNum, highNum);
        WriteArray(inputsArray, "numbers.txt");

        // Additional Tasks;
        NumbersPrintSum("numbers.txt");

        List<double> numberList = CreateList(lowNum, highNum);

        PrimeNumber(lowNum, highNum);

        static int GetPositiveLowNumber()
        {
            int newLow;
            while (true)
            {
                string low = Console.ReadLine();
                if (int.TryParse(low, out newLow) && newLow > 0)
                {
                    return newLow;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        static int GetHighNumber(int lowNum)
        {
            int newHigh;
            while (true)
            {
                string high = Console.ReadLine();
                if (int.TryParse(high, out newHigh) && newHigh > lowNum)
                {
                    return newHigh;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        static int[] NumberArray(int low, int high)
        {
            int[] numbers = new int[high - low + 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = high--;
            }

            return numbers;
        }

        static void NumbersPrintSum(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            int sum = 0;
            foreach (string line in lines)
            {
                sum += int.Parse(line);
            }

            Console.WriteLine($"Sum of numbers from file: {sum}");
        }

        static void WriteArray(int[] array, string fileName)
        {
            File.WriteAllLines(fileName, Array.ConvertAll(array, x => x.ToString()));
        }

        static List<double> CreateList(int low, int high)
        {
            List<double> numbersList = new List<double>();
            for (int i = low; i <= high; i++)
            {
                numbersList.Add((double)i);
            }

            return numbersList;
        }
        // This part of the code was based on ChatGPT;
        static void PrimeNumber(int low, int high)
        {
            Console.WriteLine($"Prime numbers between {low} and {high}:");
            for (int i = low; i <= high; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
        // This part of the code was based on ChatGPT;
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
