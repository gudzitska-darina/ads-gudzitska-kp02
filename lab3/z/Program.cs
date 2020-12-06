using System;
 
namespace CombSort
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Введите размер массива.");
            int N = int.Parse(Console.ReadLine());
            int[] unsorted = new int[N];
            Random rand = new Random();
            for (int i = 0; i < unsorted.Length; i++)
            {
                    unsorted[i] = rand.Next(-100, 500);
                    if((unsorted[i] > -10 && unsorted[i] < 10) || (unsorted[i] >= 1000) )
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", unsorted[i]);
                    }
                    if((unsorted[i] >= 10  && unsorted[i] < 100) || (unsorted[i] <= -10  && unsorted[i] > -100))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0} ", unsorted[i]);
                    }
                    if((unsorted[i] >= 100  && unsorted[i] < 999) || (unsorted[i] <= -100  && unsorted[i] > -999))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", unsorted[i]);
                        Console.ResetColor();
                    }
            }            
            Console.WriteLine('\n');
            Console.ResetColor();
            Console.Write(string.Join(",", combSort(unsorted)));
        }
        public static int[] combSort(int[] input)
        {
            double gap = input.Length;
            bool swaps = true;           
            while (gap > 1 || swaps)
            {                
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < input.Length)
                {
                    int igap = i + (int)gap;
                    if((input[i] >= 10  && input[i] < 100) || (input[i] <= -10  && input[i] > -100))
                    {
                        if (input[i] > input[igap])
                        {
                            int swap = input[i];
                            input[i] = input[igap];
                            input[igap] = swap;
                            swaps = true;
                        }
                    }
                    if((input[i] >= 100  && input[i] < 1000) || (input[i] <= -100  && input[i] > -1000))
                    {
                        if (input[i] < input[igap])
                        {
                            int swap = input[i];
                            input[i] = input[igap];
                            input[igap] = swap;
                            swaps = true;
                        }
                    }
                    i++;
                }
            }              
            return input;
        }       
    }
}