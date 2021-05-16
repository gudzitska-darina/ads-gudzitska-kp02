using System;
using static System.Console;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trees
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			while (true)
            {
                WriteLine("Enter the selected tree\n\r[control|user|exit]");
                string input = ReadLine();
                switch (input)
                {
                    case "control":
                        Control();
                        break;
                    case "user":
                        User();
                        break;
                    case "exit":
                        WriteLine("Goodbye.");
                        return;
                    default:
                        WriteLine("Incorrect input");
                        break;
                }
            }
        
		}

		static void Control()
		{
			string math = "(1+(2*x))/(3-(4+y))";
			BinaryTree tree = new BinaryTree();
			BinaryTree sen = tree.ToRPN(math);
			Stack<char> result = new Stack<char>();
			BinaryTree.BinaryNode node = sen.root;
			
			Clear();
            sen.Print(node, 0, 0);

			WriteLine("\n---------------");
			WriteLine($"Infix form:");
			ForegroundColor = ConsoleColor.Cyan;
			WriteLine(math);
			ResetColor();

			tree.PreOrder(node, result);
			char[] pol = result.ToArray();
			Array.Reverse(pol);
			WriteLine("Prefix form:");
			ForegroundColor = ConsoleColor.Cyan;
			foreach(var elem in pol)
			{
				Write($"{elem} ");
			}
			Write("\r\n");
			ResetColor();     
		}

		static void User()
		{
			while(true)
			{
				ForegroundColor = ConsoleColor.Yellow;
				WriteLine("Enter an exampl\n\rImportant! Use only integer values and latin letters! Each operation must be bracketed!\r\n For example:(a+b)/(a-b)");
				ResetColor();
				string math = ReadLine();
				if(ChechString.IsCorrectInput(math))
				{
					BinaryTree tree = new BinaryTree();
					BinaryTree sen = tree.ToRPN(math);
					Stack<char> result = new Stack<char>();
					BinaryTree.BinaryNode node = sen.root;
					
					Clear();
					sen.Print(node, 0, 0);

					WriteLine("\n---------------");
					WriteLine($"Infix form:");
					ForegroundColor = ConsoleColor.Cyan;
					WriteLine(math);
					ResetColor();

					tree.PreOrder(node, result);
					char[] pol = result.ToArray();
					Array.Reverse(pol);
					WriteLine("Prefix form:");
					ForegroundColor = ConsoleColor.Cyan;
					foreach(var elem in pol)
					{
						Write($"{elem} ");
					}
					Write("\r\n");
					ResetColor();
					break;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					WriteLine("Try again!");
					ResetColor();
				}
			}
			
			  
		}
		
	}
}