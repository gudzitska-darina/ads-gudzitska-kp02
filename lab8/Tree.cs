using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace Trees
{
    class BinaryTree
    {
        public class BinaryNode //узел дерева
        {
            public BinaryNode left { get; set; } //указатели узла
            public BinaryNode right { get; set; }
            public char value; //вставляемое значение

            public BinaryNode(char val)
            {
                value = val; //конструктор заполняет узел значением
                left = null;
                right = null;
            }
        }

        public BinaryNode root; //корень дерева
        public BinaryTree() //конструктор (по умолчанию) создания дерева
        {
            root = null; //при создании корень не определен
        }

        public BinaryTree(char value)
        {
            root = new BinaryNode(value); //если изначально задаём корневое значение
        }

        public bool IsCharIsNull(char? e)
        {
            if(e == null)
            {
                return true;
            }
            else return false;
        }
        public void Clear()
        {
            root = null;
        }
        //нерекурсивное добавление
         public BinaryTree ToRPN(string initialString)
        {
            Stack<char> operationsStack = new Stack<char>();
            BinaryTree tree = new BinaryTree();
            char previous = '\0';
 
            string result = string.Empty;

            initialString = initialString.Replace(" ", "");
            foreach(var elem in initialString)
            {
                if(IsOperation(elem))
                {
                    if(IsCharIsNull(previous))
                    {
                        tree.root = new BinaryNode(elem);
                        previous = elem;
                    }
                    else
                    {
                        if(GetOperationPriority(previous) <= GetOperationPriority(elem))
                        {
                            tree.root = new BinaryNode(elem);
                            previous = elem;
                        }
                        else
                        {
                            continue;
                        }
                    }                   
                }
            }
            BinaryTree current = new BinaryTree();
            BinaryTree current2 = new BinaryTree(); 
            for(int i = 0; i < initialString.Length; i++)
            {
               
                if(initialString[i].Equals('('))
                {  
                    i++;
                    do
                    {
                        if(initialString[i] == '(')
                        {
                            operationsStack.Push(initialString[i]);
                            i--;
                            break;
                        }
                        operationsStack.Push(initialString[i]);
                        i++;

                    }
                    while(!operationsStack.Contains(')'));
                    operationsStack.Pop();

                    foreach(var elem in operationsStack)
                    {
                        if(IsOperation(elem))
                        {
                            if(current.root == null)
                                current.root = new BinaryNode(elem);
                            else
                                current2.root = new BinaryNode(elem);
                        }
                        else continue;
                    }
                    foreach(var elem in operationsStack)
                    {
                        if(IsOperation(elem))
                        {
                            if(current.root.value == elem || current2.root.value == elem)
                            {
                                continue;
                            }
                            else
                            {
                                current.root.right = new BinaryNode(elem);
                                current2.root = current.root.right;
                                
                            }
                        }
                        else
                        {
                            if(current2.root != null)
                            {
                                if(current2.root.left == null)
                                {
                                    current2.root.left = new BinaryNode(elem);
                                    continue;
                                }
                                else
                                {
                                    current2.root.right = new BinaryNode(elem);
                                    current.root.right = null;
                                    current.root.right = current2.root;
                                }
                            }

                            if(current.root.left == null)
                            {
                                current.root.left = new BinaryNode(elem);
                                continue;
                            }
                            else if(current.root.right == null)
                            {
                                current.root.right = new BinaryNode(elem);
                                if(tree.root.right == null)
                                {
                                    tree.root.right = current.root;
                                }
                                else
                                {
                                    tree.root.left = current.root;
                                }
                            }
                            else
                            {
                                if(tree.root.right == null)
                                {
                                    tree.root.right = current.root;
                                }
                                else
                                {
                                    tree.root.left = current.root;
                                }
                            }
                            

                        }
                    }
                    if(current.root.left != null && current.root.right != null)
                        current.Clear();
                    if(current2.root != null)
                    {
                        if(current2.root.left != null && current2.root.right != null)
                        current2.Clear();
                    }
                    operationsStack.Clear();
                    
                }
                else if(tree.root.right == null)
                {
                    tree.root.right = current.root;
                }
                else
                {
                    tree.root.left = current.root;
                }
            }
            return tree;
        }
        public static bool IsOperation(char c)
        {
            if(c == '+' ||
                c == '-' ||
                c == '*' ||
                c == '/')
                return true;
            else
                return false;
        }
        public static int GetOperationPriority(char c)
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
        public int Print(BinaryNode node, int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(node.value);
            Console.ResetColor();

            var loc = y;

            if (node.right != null)
            {
                Console.SetCursorPosition(x + 2, y);
                Console.Write("--|  ");
                y = Print(node.right, x + 4, y);
            }

            if (node.left != null)
            {
                while (loc <= y)
                {
                    Console.SetCursorPosition(x, loc + 1);
                    Console.Write("|  ");
                    loc++;
                }
                y = Print(node.left, x, y + 2);
            }

            return y;
        }

        public void PreOrder(BinaryNode node, Stack<char> result)
        { 
            if(node == null)
            {
                return;
            }
            result.Push(node.value);
            
            PreOrder(node.left, result);
            PreOrder(node.right, result);
        }
        
    }

   
    
}