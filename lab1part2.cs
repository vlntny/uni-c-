using System;

class Program
{
    static void Main()
    {
        // Получение размеров матрицы от пользователя
        Console.WriteLine("Введите количество строк матрицы:");
        int rows = ReadPositiveInteger();

        Console.WriteLine("Введите количество столбцов матрицы:");
        int columns = ReadPositiveInteger();

        // Создание и заполнение матрицы случайными числами
        int[,] matrix = GenerateRandomMatrix(rows, columns);
        
        Console.WriteLine("Сгенерированная матрица:");
        PrintMatrix(matrix);

        // Определение количества столбцов с нулевыми элементами
        int zeroColumns = CountColumnsWithZeros(matrix);
        Console.WriteLine($"Количество столбцов с нулевыми элементами: {zeroColumns}");

        // Определение номера строки с самой длинной серией одинаковых элементов
        int longestSeriesRow = FindRowWithLongestSeries(matrix);
        Console.WriteLine($"Номер строки с самой длинной серией одинаковых элементов: {longestSeriesRow}");
    }

    static int ReadPositiveInteger()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.WriteLine("Введите положительное целое число:");
        }
        return number;
    }

    static void PrintMatrix(int[,] matrix)
    {
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
        }
    }


    static int[,] GenerateRandomMatrix(int rows, int columns)
    {
        Random random = new Random();
        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(10); // Заполняем случайными числами от 0 до 9
            }
        }
        return matrix;
    }

    static int CountColumnsWithZeros(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        int zeroColumns = 0;

        for (int j = 0; j < columnCount; j++)
        {
            for (int i = 0; i < rowCount; i++)
            {
                if (matrix[i, j] == 0)
                {
                    zeroColumns++;
                    break;
                }
            }
        }

        return zeroColumns;
    }

    static int FindRowWithLongestSeries(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        int longestSeriesRow = -1;
        int longestSeriesLength = 0;
        int currentSeriesRow = -1;
        int currentSeriesLength = 0;

        for (int i = 0; i < rowCount; i++)
        {
            currentSeriesRow = i;
            currentSeriesLength = 0;

            for (int j = 1; j < columnCount; j++)
            {
                if (matrix[i, j] == matrix[i, j - 1])
                {
                    currentSeriesLength++;
                }
                else
                {
                    // Новая серия начинается, проверяем длину
                    if (currentSeriesLength > longestSeriesLength)
                    {
                        longestSeriesRow = currentSeriesRow;
                        longestSeriesLength = currentSeriesLength;
                    }

                    currentSeriesRow = i;
                    currentSeriesLength = 0;
                }
            }

            // Проверяем длину последней серии в строке
            if (currentSeriesLength > longestSeriesLength)
            {
                longestSeriesRow = currentSeriesRow;
                longestSeriesLength = currentSeriesLength;
            }
        }

        return longestSeriesRow;
    }
}