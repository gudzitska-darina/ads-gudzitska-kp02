using System;
using System.Diagnostics;
using System.IO;

namespace LinkedListImplementation
{
    class SLList
    {
        public Node head;

        public class Node
        {
            public string data;
            public Node next;

            public Node(string data)
            {
                this.data = data;
            }

            public Node(string data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }

        public SLList(string data)
        {
            head = new Node(data);
        }

        public void AddFirst(string data) 
        { 
            Node node =new Node(data);
            node.next = head;
            head = node;
        }


        public void AddLast(string data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = new Node(data);
            }
        }

        public void DeleteFirst() 
        {
            Node current = head;
            {
                if (current == head)
                {
                    head = head.next;
                }
                current = current.next;
            }
        }


        public void DeleteLast()
        {
            if (head != null && head.next != null) 
            {
                Node current = head;

                while (current.next.next != null)
                {
                    current = current.next;
                }

                current.next = null;
            }
            else head = null;
        }

        public void Print()
        {
            Console.WriteLine();
            Console.Write("Current list: ");

            Node current = head;

            while (current != null)
            {
                Console.Write(current.data);
                if (current.next != null) Console.Write(" -> ");
                current = current.next;
            }

            Console.WriteLine();
        }
    }
    public class Program
    {
        enum State
        {
            Initial,
            Bracket,
            Number,
            Separator
        }
        static string Find(string input)
        {
            string data = null;
            State state = State.Initial;
            foreach(char c in input)
            {
                if(state == State.Initial && c== '[')
                {
                    state = State.Bracket;
                }
                else if(state == State.Bracket)
                {
                    if(!char.IsNumber(c))
                    {
                        data = "Not correct input";
                        return data;
                    }
                    else if(char.IsNumber(c))
                    {
                        state = State.Number;
                        data = data + c;
                    }
                    else if(c == ']')
                    {
                        return data;
                    }
                }
            }
            if(state == State.Initial || state == State.Bracket)
            {
                data = "No input";
            }
            return data;
        }
        static void Main()
        {
            Console.WriteLine("Enter comand");
            string input = Console.ReadLine();
            string data = Find(input);
            SLList linkedList = new SLList(data);
            if(input.StartsWith("AddFirst") && input.EndsWith("]"))
            {
                linkedList.AddFirst(data);
                linkedList.Print();
            }
            else if(input.StartsWith("AddLast") && input.EndsWith("]"))
            {
                linkedList.AddLast(data);
                linkedList.Print();
                return;
            }
            else if(input.StartsWith("DeleteFirst") && input.EndsWith("]"))
            {
                linkedList.DeleteFirst();
                linkedList.Print();
                return;
            }
            else if(input.StartsWith("DeleteLast") && input.EndsWith("]"))
            {
                linkedList.DeleteLast();
                linkedList.Print();
                return;
            }
            
        }
    }
}