using System;
using static System.Console;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHelp();
            bool temp = true;
            Heap heap = new Heap();
            while (temp)
            {
                WriteLine("Enter the command");
                string command = ReadLine();
                string[] subcommands = command.Split(' ');
                if (subcommands.Length == 1)
                {
                    if(subcommands[0] == "add")
                    {
                        ProcessAdd(heap);                       
                    }
                    else if(subcommands[0] == "output")
                    {
                        ProcessVisualize(heap);
                    }
                    else if(subcommands[0] == "exit")
                    {
                        temp = false;
                        break;
                    }
                    else if(subcommands[0] == "help")
                    {
                        GetHelp();
                    }
                    else
                    {
                        WriteLine("Unknown command");
                    }
                }
                else
                {
                    WriteLine("Unknown command");
                }
                WriteLine();
            }
        }
        static void GetHelp()
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Commands you can use:");
            WriteLine("'help' - interface");
            WriteLine("'add' - add new nodes to the tree.");
            WriteLine("'output' - displays the created tree");
            WriteLine("'exit' - close program");
            Console.ResetColor();
        }
        static void ProcessAdd(Heap heap)
        {
            bool temp = true;
            while (temp)
            {
                WriteLine("Enter the value to add");
                string value = ReadLine();
                if (value == "")
                {
                    temp = false;
                    break;
                }
                else if (value == "output")
                {
                    ProcessVisualize(heap);
                    continue;
                }
                int item;
                bool isValue = int.TryParse(value, out item);
                if (isValue)
                {
                    heap.Insert(item);
                }
                else
                {
                    WriteLine();
                    Console.Error.WriteLine("Incorrect value!");
                }
            }
            bool isComplete = heap.CheckCompleteness();
            if (isComplete == true)
            {
                heap.DoPreorderTraversal(0);
                WriteLine();
                WriteLine("A binary tree is a maximum binary heap.");
            }
            else
            {
                Console.Error.WriteLine("It's not a completed binary tree");
                return;
            }
        }
        static void ProcessVisualize(Heap heap)
        {
            heap.Print(0, 0);
        }
    }
}
