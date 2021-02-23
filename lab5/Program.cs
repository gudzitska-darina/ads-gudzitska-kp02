using System;
using static System.Console;

class Program
{
    private static void QSort(int[] arr, int left, int right) 
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QSort(arr, left, pivot - 1);
            QSort(arr, pivot + 1, arr.Length-1);             
        }
    }

    private static int Partition(int[] arr, int left, int right)
    {
        int mid = left;
        int pivot = arr[left];
        while (true) 
        {
            while (arr[left] < pivot) 
            {
                left++;
                mid++;
            }
            while (arr[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (arr[left] == pivot) left++;

                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }
            else 
            {
                return right;
            }
        }
    }

   static int EnumerateNumb(int[,] matrix, out int counter)
        {
            counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(i % 2 == 0 && i != j)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        static int[] CreateMass(int length, int[,] matrix)
        {
            int[] countersL = new int[length];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(i % 2 == 0 && i != j)
                    {
                        countersL[k] = matrix[i, j];
                        k++;
                    }     
                } 
            }
            return countersL;                   
        }

        static int[,] CreateSortedMatrix(int[,] matrix, int[] mass)
        {
            WriteLine();
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i % 2 == 0 && i != j)
                    {
                        matrix[i, j] = mass[k];
                        k++;
                        ForegroundColor = ConsoleColor.Green;
                        Write($"{matrix[i, j]} ");
                        ResetColor();
                    }
                    else
                    {
                        Write($"{matrix[i, j]} ");
                    }     
                }
                WriteLine();    
            }
            return matrix; 
        }

    static void Control()
    {
        int[,] unsorted = new int[5, 5];
        Random rand = new Random();
        for (int i = 0; i < unsorted.GetLength(0); i++)
        {
            for (int j = 0; j < unsorted.GetLength(1); j++)
            {
                unsorted[i, j] = rand.Next(0, 3);
                if(i % 2 == 0 && i != j)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Write($"{unsorted[i, j]} ");
                    ResetColor();
                }
                else
                {
                    Write($"{unsorted[i, j]} ");
                }
            }
            WriteLine();
        }  
        int counter;
        int length = EnumerateNumb(unsorted, out counter);
        int[]countersL = CreateMass(length, unsorted);
        // foreach ( int k in countersL )
        // Console.Write(k + " ");
        QSort(countersL, 0, countersL.Length - 1);
        WriteLine("\nSorted");
        // foreach ( int k in countersL )
        // Console.Write(k + " ");
        CreateSortedMatrix(unsorted, countersL);
    }
    static void UnsortedOfUser()
    {
        int n;
        int m;
        WriteLine("Введите размер массива:");
        bool N = int.TryParse(ReadLine(), out n);
        bool M = int.TryParse(ReadLine(), out m);
        if (N & M)
        {
            int[,] unsorted = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < unsorted.GetLength(0); i++)
            {
                for (int j = 0; j < unsorted.GetLength(1); j++)
                {
                    unsorted[i, j] = rand.Next(-10, 20);
                    if(i % 2 == 0 && i != j)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        Write($"{unsorted[i, j]} ");
                        ResetColor();
                    }
                    else
                        Write($"{unsorted[i, j]} ");
                }
                WriteLine();
            }    
            int counter;
            int length = EnumerateNumb(unsorted, out counter);
            int[]countersL = CreateMass(length, unsorted);
            // foreach ( int k in countersL )
            // Console.Write(k + " ");
            QSort(countersL, 0, countersL.Length - 1);
            WriteLine("\nSorted");
            // foreach ( int k in countersL )
            // Console.Write(k + " ");
            CreateSortedMatrix(unsorted, countersL);
        }
        else 
        {
            Console.WriteLine("Ошибка: введено не целое число.");
        }
    }    
    static void Main(string[] args)
    {
        ConsoleKeyInfo answer;
        do{
            WriteLine("Запустить контрольную матрицу?(y/n)");
            answer = ReadKey();
            if(answer.KeyChar == 'y' || answer.KeyChar == 'д')
            {
                WriteLine();
                Control();
            }
            else if(answer.KeyChar == 'n' || answer.KeyChar == 'н')
            {
                WriteLine();
                UnsortedOfUser();
            }
            else if (answer.Key == ConsoleKey.Escape)
            {
                WriteLine("\nGoodbye!");
                break;
            }
            else
            {
                WriteLine("\nError. Выберите матрицу.");
            }
        }
        while(true);
    }
}