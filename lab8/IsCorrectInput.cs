using System;
using System.Collections.Generic;

public class ChechString
{   
    public static bool IsCorrectInput(string input)
    {
        if (input == "")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("String is empty");
            Console.ResetColor();
            return false;
        }
        if (!IsCorrectBrackets(input))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Incorect brackets!");
            Console.ResetColor();
            return false;
        }
        for (int i = 0; i < input.Length; i++)
        {
            if (input[0] == '+' || input[0] == '-' || input[0] == '*' || input[0] == '/')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("The expression cannot begin and end with an operator sign!");
                Console.ResetColor();
                return false;
            }
            if (!char.IsDigit(input[i]) && !IsOperator(input[i]) && input[i] != '(' && input[i] != ')' && !char.IsLetter(input[i]))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Expression should only contain numbers, parentheses, letter and `+`, `-`,`*`,`/`");
                Console.ResetColor();
                return false;
            }
            if (input[i] == '.')
            {
                Console.WriteLine("Use only integer values!");
            }
            if (i != input.Length - 1)
            {
                if (IsOperator(input[i]) && IsOperator(input[i + 1]))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You cannot use 2 operators in a row!");
                    Console.ResetColor();
                    return false;
                }
            }
            if (input[i] == '/' && input[i+1] == '0')
            {
                if (i + 1 == input.Length - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You can't divide by zero!");
                    Console.ResetColor();
                    return false;
                }
                else if (IsOperator(input[i+2]) || input[i+2] == '(' || input[i+2] == ')')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You can't divide by zero!");
                    Console.ResetColor();
                    return false;
                }
            }
        }
        if (!char.IsDigit(input[input.Length-1]) && input[input.Length-1] != ')' && input[input.Length-1] != '.')
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The expression cannot begin and end with an operator sign!");
            Console.ResetColor();
            return false;
        }
        return true;
    }

    static bool IsCorrectBrackets(string input)
    {
        Stack<char> stackOfBrackets = new Stack<char>();
        foreach (char c in input)
        {
            if (c == '(')
            {
                stackOfBrackets.Push(c);
                continue;
            }
            if (c == ')')
            {
                if (stackOfBrackets.Count == 0)
                {
                    return false;
                }
                stackOfBrackets.Pop();
            }
        }
        if (stackOfBrackets.Count != 0)
        {
            return false;
        }
        return true;
    }

    static bool IsOperator(char c)
    {
        if (c != '+' && c != '-' && c != '*' && c != '/')
        {
            return false;
        }
        return true;
    }

}
