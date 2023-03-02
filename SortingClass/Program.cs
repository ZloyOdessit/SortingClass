using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000; // количество итераций
            int sum = 0;     // сумма чисел
            Stopwatch stopwatch = new Stopwatch();
            


            Random random = new Random();            
            Console.WriteLine("Сколько будет чисел?");
            string input = Console.ReadLine();
            stopwatch.Start();
            while (!InputValidator.IsNonNegativeInt(input))
            {
                Console.WriteLine("Введите положительное число:");
                input = Console.ReadLine();
            }

            int count = Convert.ToInt32(input);
            int[] array_of_numbers = new int[count];
            int temp;
            Console.Clear();

            
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите число:");
                int randomNumber = random.Next(-10, 1000);
                int input_random = randomNumber;
                string input_number = Convert.ToString(input_random);
                while (!InputValidator.IsNumeric(input_number))
                {
                    Console.WriteLine("Ошибка ввода! Введите число:");
                    input_number = Console.ReadLine();
                }
                array_of_numbers[i] = int.Parse(input_number);
                Console.Clear();
            }
            Console.WriteLine("Ввод завершен, изначальный массив:");
            Console.WriteLine(array_of_numbers.ToCsvString());
            Console.WriteLine();

            int[] temp_array_of_numbers = array_of_numbers;
            Console.WriteLine("Сортировка Пузырьком: ");
            for (int i = 0; i < temp_array_of_numbers.Length; i++)
            {
                for (int j = 0; j < temp_array_of_numbers.Length; j++)
                {
                    if (temp_array_of_numbers[i] > temp_array_of_numbers[j])
                    {
                        temp = temp_array_of_numbers[j];
                        temp_array_of_numbers[j] = temp_array_of_numbers[i];
                        temp_array_of_numbers[i] = temp;
                    }
                }
            }
            Console.WriteLine(temp_array_of_numbers.ToCsvString());
            Console.WriteLine();

            temp_array_of_numbers = array_of_numbers;
            Console.WriteLine("Сортировка Пузырьком в обратном порядке: ");
            for (int i = 0; i < temp_array_of_numbers.Length; i++)
            {
                for (int j = 0; j < temp_array_of_numbers.Length; j++)
                {
                    if (temp_array_of_numbers[i] < temp_array_of_numbers[j])
                    {
                        temp = temp_array_of_numbers[j];
                        temp_array_of_numbers[j] = temp_array_of_numbers[i];
                        temp_array_of_numbers[i] = temp;
                    }
                }
            }
            Console.WriteLine(temp_array_of_numbers.ToCsvString());
            Console.WriteLine();

            temp_array_of_numbers = array_of_numbers;
            Console.WriteLine("Сортировка Вставками: ");

            for (int i = 1; i < temp_array_of_numbers.Length; i++)
            {
                int key = temp_array_of_numbers[i];
                int j = i - 1;

                while (j >= 0 && temp_array_of_numbers[j] > key)
                {
                    temp_array_of_numbers[j + 1] = temp_array_of_numbers[j];
                    j = j - 1;
                }

                temp_array_of_numbers[j + 1] = key;
            }
            Console.WriteLine(temp_array_of_numbers.ToCsvString());
            Console.WriteLine();







            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            stopwatch.Stop();
            Console.ReadKey();
        }
    }

    public class InputValidator
    {
        public static bool IsNonNegativeInt(string input)
        {
            int number;
            if (int.TryParse(input, out number))
            {
                if (number >= 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsNumeric(string str)
        {
            double number;
            return double.TryParse(str, out number);
        }

    }
    public static class ArrayExtensions
    {
        public static string ToCsvString<T>(this IEnumerable<T> array)
        {
            return string.Join(", ", array);
        }
    }
}
