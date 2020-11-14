using System;    

    Console.WriteLine("Введите размер матрицы");
    int N = int.Parse(Console.ReadLine());
    int[,] mrx = new int[N, N];
    int max1 = 0, maxX1 = N-1 , maxY1 = 0;
    int max2 = 0, maxX2 = 0, maxY2 = 0;
    int max3 = 0, maxX3 = N-2, maxY3 = N-1;
    int min1 = 0, minX1 = N-1, minY1 = 0;
    int min2 = 0, minX2 = 0, minY2 = 0;
    int min3 = 0, minX3 = N-2, minY3 = N-1;
    Random rand = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            mrx[i, j] = rand.Next(N*N) + 1;
            Console.Write("{0} ", mrx[i, j]);
        }
        Console.WriteLine();
    }
    max1 = mrx[maxX1, maxY1]; min1 = mrx[minX1, minY1];
    max2 = mrx[maxX2, maxY2]; min2 = mrx[minX2, minY2];
    max3 = mrx[maxX3, maxY3]; min3 = mrx[minX2, minY2];

    Console.WriteLine("Первая часть обхода матрицы:");
    int c1=0;
    for (int i = N-1; i > 0; i--)
    {
        if ((c1 % 2) != 0) 
        {
            for (int j = i-1; j >= 0; j--)
            {
                Console.Write("{0} ", mrx[i, j]);
                if (mrx[i, j] > max1) 
                {
                    maxX1 = i; maxY1 = j;
                    max1 = mrx[maxX1, maxY1];
                }
                if (mrx[i, j] < min1)
                {
                    minX1 = i; minY1 = j;
                    min1 = mrx[minX1, minY1];
                }
            }
            Console.WriteLine();
        }                    
        else 
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("{0} ", mrx[i, j]);
                if (mrx[i, j] > max1)
                {
                    maxX1 = i; maxY1 = j;
                    max1 = mrx[maxX1, maxY1];
                }
                if (mrx[i, j] < min1)
                {
                    minX1 = i; minY1 = j;
                    min1 = mrx[minX1, minY1];
                }
            }
            Console.WriteLine();
        }
        c1++;
    }

    Console.WriteLine("Вторая часть обхода матрицы:");
    for (int i = 0; i < N; i++)
    {
        Console.WriteLine("{0} ", mrx[i, i]);
        if (mrx[i, i] > max2)
        {
            maxX2 = i; maxY2 = i;
            max2 = mrx[maxX2, maxY2];
        }
        if (mrx[i, i] < min2)
        {
            minX2 = i; minY2 = i;
            min2 = mrx[minX2, minY2];
        }
    }

    Console.WriteLine("Третья часть обхода матрицы:");
    int c2=0;
    for (int j = N - 1; j > 0; j--)
    {
        if ((c2 % 2) != 0)
        {
            for (int i = 0; i < j; i++)
            {
                Console.Write("{0} ", mrx[i, j]);
                if (mrx[i, j] > max3)
                {
                    maxX3 = i; maxY3 = j;
                    max3 = mrx[maxX3, maxY3];
                }
                if (mrx[i, j] < min3)
                {
                    minX3 = i; minY3 = j;
                    min3 = mrx[minX3, minY3];
                }
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = j - 1; i >= 0; i--)
            {
                Console.Write("{0} ", mrx[i, j]);
                if (mrx[i, j] > max3)
                {
                    maxX3 = i; maxY3 = j;
                    max3 = mrx[maxX3, maxY3];
                }
                if (mrx[i, j] < min3)
                {
                    minX3 = i; minY3 = j;
                    min3 = mrx[minX3, minY3];
                }
            }
            Console.WriteLine(); 
        }
    c2++;
    }
    Console.WriteLine("Максимальные элементы:");
    Console.WriteLine("Часть 1: [{0},{1}] = {2}", maxX1+1, maxY1+1, max1);
    Console.WriteLine("Часть 2: [{0},{1}] = {2}", maxX2+1, maxY2+1, max2);
    Console.WriteLine("Часть 3: [{0},{1}] = {2}", maxX3+1, maxY3+1, max3);
    Console.WriteLine("Минимальные элементы:");
    Console.WriteLine("Часть 1: [{0},{1}] = {2}", minX1+1, minY1+1, min1);
    Console.WriteLine("Часть 2: [{0},{1}] = {2}", minX2+1, minY2+1, min2);
    Console.WriteLine("Часть 3: [{0},{1}] = {2}", minX3+1, minY3+1, min3);
