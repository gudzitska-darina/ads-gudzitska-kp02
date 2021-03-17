using System;
using static System.Console;
using System.Collections.Generic;

namespace lab6
{
    class ReversePN
    {
        public static string ToRPN(string initialString)
        {

            Stack<char> operationsStack = new Stack<char>();
            char lastOperation;
 
            string result = string.Empty;

            initialString = initialString.Replace(" ", "");
 
            for(int i = 0; i < initialString.Length; i++)
            {
                if (Char.IsDigit(initialString[i]))
                {
                    result += initialString[i];
                    continue;
                }
                if(IsOperation(initialString[i]))
                {
                    if (!(operationsStack.Count == 0))
                        lastOperation = operationsStack.Peek();

                    else
                    {
                        operationsStack.Push(initialString[i]);
                        continue;
                    }
                    if(GetOperationPriority(lastOperation) < GetOperationPriority(initialString[i]))
                    {
                        operationsStack.Push(initialString[i]);
                        continue;
                    }
                    else
                    {
                        result += operationsStack.Pop();
                        operationsStack.Push(initialString[i]);
                        continue;
                    }
                }
                if(initialString[i].Equals('('))
                {
                    operationsStack.Push(initialString[i]);
                    continue;
                }
                if(initialString[i].Equals(')'))
                {
                    while(operationsStack.Peek() != '(')
                    {
                        result += operationsStack.Pop();
                    }
                    operationsStack.Pop();
                }
            }
            while(!(operationsStack.Count == 0))
            {
                result += operationsStack.Pop();
            }
            return result;
        }
        private static bool IsOperation(char c)
        {
            if(c == '+' ||
                c == '-' ||
                c == '*' ||
                c == '/')
                return true;
            else
                return false;
        }
        private static int GetOperationPriority(char c)
        {
            switch(c)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 0;
            }
        }
    }
    class Program
    {
        static bool StringContains(string input)
        {
            foreach(char c in input)
                if(Char.IsNumber(c) || Char.IsSymbol(c))
                    return true;
            return false;
        }
        static void Control()
        {
            string controlString = "1*2/(3+4-5)";
            WriteLine($"\nКонтрольный пример: {controlString}");
            WriteLine($"Запись в обратной польськой нотации: {ReversePN.ToRPN(controlString)}");
        }
        static void ByUser()
        {
            string userString = ReadLine();
            if(!StringContains(userString))
            {
                throw new Exception($"Введена НЕ цифра или знак.");
            }
            WriteLine($"Ваш пример: {userString}");
            WriteLine($"Запись в обратной польськой нотации: {ReversePN.ToRPN(userString)}");
        }

        static void Main(string[] args)
        {
            WriteLine($"Для завершения программы нажмите Esc.");
            ConsoleKeyInfo answer;
            do{
                WriteLine("\nЗапустить контрольный пример?(y/n)");
                answer = ReadKey();
                if(answer.KeyChar == 'y' || answer.KeyChar == 'д')
                {
                    Control();
                }
                else if(answer.KeyChar == 'n' || answer.KeyChar == 'н')
                {
                    WriteLine("\nВведите свой пример.");
                    ByUser();
                }
                else if (answer.Key == ConsoleKey.Escape)
                {
                    WriteLine("\nGoodbye!");
                    break;
                }
                else
                    WriteLine("\nError. Выберите пример.");
            }
            while(true); 
        }
    }
}
