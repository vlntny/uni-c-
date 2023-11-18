    
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размерность массива N:");
        int N = int.Parse(Console.ReadLine());

        int[] array = GenerateArray(N);

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        int product = GetProductOfEvenIndexedElements(array);
        Console.WriteLine("Произведение элементов массива с четными номерами: " + product);

        int sum = GetSumBetweenFirstAndLastZeros(array);
        Console.WriteLine("Сумма элементов массива, расположенных между первым и последним нулевыми элементами: " + sum);

        int[] transformedArray = TransformArray(array);
        Console.WriteLine("Преобразованный массив:");
        PrintArray(transformedArray);
    }

    // Генерация массива случайных чисел
    static int[] GenerateArray(int N)
    {
        Random random = new Random();
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = random.Next(-100, 101); // Генерация чисел от -100 до 100
        }
        return array;
    }

    // Вывод массива на экран
    static void PrintArray(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    // Вычисление произведения элементов массива с четными индексами
    static int GetProductOfEvenIndexedElements(int[] array)
    {
        int product = 1;
        for (int i = 0; i < array.Length; i += 2)
        {
            product *= array[i];
        }
        return product;
    }

    // Вычисление суммы элементов массива, расположенных между первым и последним нулевыми элементами
    static int GetSumBetweenFirstAndLastZeros(int[] array)
    {
        int firstZeroIndex = Array.IndexOf(array, 0);
        int lastZeroIndex = Array.LastIndexOf(array, 0);

        if (firstZeroIndex == -1 || lastZeroIndex == -1 || firstZeroIndex == lastZeroIndex)
        {
            return 0;
        }

        int sum = 0;

        if (firstZeroIndex < lastZeroIndex)
        {
            for (int i = firstZeroIndex + 1; i < lastZeroIndex; i++)
            {
                sum += array[i];
            }
        }
        else
        {
            for (int i = lastZeroIndex + 1; i < firstZeroIndex; i++)
            {
                sum += array[i];
            }
        }

        return sum;
    }

    // Преобразование массива: сначала положительные элементы, потом отрицательные (нули считаются положительными)
    static int[] TransformArray(int[] array)
    {
        int[] transformedArray = new int[array.Length];
        int positiveIndex = 0;
        int negativeIndex = array.Length - 1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] >= 0)
            {
                transformedArray[positiveIndex] = array[i];
                positiveIndex++;
            }
            else
            {
                transformedArray[negativeIndex] = array[i];
                negativeIndex--;
            }
        }

        return transformedArray;
    }
}