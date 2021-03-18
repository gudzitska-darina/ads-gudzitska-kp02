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
        static void Control()
        {
            string controlString = "1*2/(3+4-5)";
            WriteLine($"\nКонтрольный пример: {controlString}");
            WriteLine($"Запись в обратной польськой нотации: {ReversePN.ToRPN(controlString)}");
        }
        static void ByUser()
        {
            WriteLine($"Для завершения ввода введите '.'");
            string userString = string.Empty;
            Stack<char> enter = new Stack<char>();
            while(true)
            {
                char lastOperation = ReadKey().KeyChar;
                if(Char.IsNumber(lastOperation) || lastOperation == '+' || lastOperation == '-' 
                    || lastOperation == '*' || lastOperation == '/' || lastOperation == '(' || lastOperation == ')')
                {
                    enter.Push(lastOperation);
                    userString += char.ToString(lastOperation);
                    WriteLine($"\nВаш пример: {userString}");
                    continue;
                }
                else if(lastOperation == '.')
                {
                   WriteLine($"\nЗапись в обратной польськой нотации: {ReversePN.ToRPN(userString)}");
                   break; 
                }
                else
                {
                    WriteLine($"\nВведен неверный символ!");
                    continue;
                }
            }
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
