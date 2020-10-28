using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.Write("Введите век ");
                byte x = byte.Parse(Console.ReadLine());
                const int d = 13;
                int c = x - 1;
                int y = 0;
                int m = 0;
                int mm = 0;
                int res = 0;
                int yy = 0;
                while (y < 100)
                {
                    m = 1;
                    int cc = x - 1;
                    while (m <= 12)
                    {
                    if (m < 3)
                    {
                        yy = y - 1;
                        mm = m + 10;
                    }
                    else
                    {
                        mm = m - 2;
                        yy = y;
                    }
                        if (yy < 0)
                        {
                            yy = 100 + yy;
                            cc = cc - 1; 
                        }
                        int a = ((13 * mm - 1)/5 + d + yy + (yy / 4) + (cc / 4) - 2 * cc + 777);
                        if (a % 7 == 5)
                        {
                            res++;
                        }
                        m++;
                    }
                y++;
                }
                Console.WriteLine(res);
                Console.ReadKey();
        }
    }
}