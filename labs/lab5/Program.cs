using System;
using System.Linq;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        string[] controlArray = new string[]{"ff12345A","tr21453t","re12345G","HG12347G",
            "yt45367H", "ff54321A","rt34124T","tt13456G","hg21435G","po15476J",
            "hg87965J"};

        int command = 0;
        string[] sorted = new string[0];
        
        while (command != 1 && command != 2)
        {
            WriteLine("Enter 1 to sort control array or enter 2 to enter all elements.");
            string value = ReadLine();
            bool commandCheck = int.TryParse(value, out command);
            if((commandCheck))
            {
                continue;
            }
            else
            {
                WriteLine("Incorrect format of command");
            }
        }
        try
        {        
            if (command == 2)
            {
                WriteLine("Enter amount of elements: ");
                int count = 0;
                bool countCheck = int.TryParse(ReadLine(), out count);
                string[] elements = new string[count];

                if (!countCheck)
                {
                    throw new ArgumentException("Amount must be int.");
                }

                for (int i = 0; i < count; ++i)
                {
                    WriteLine("Enter element({0})", i + 1);
                    string element = ReadLine();

                    if (element.Length != 8)
                    {
                        WriteLine("Invalid length of element.");
                        i =- 1;
                        continue;
                    }
                    if (!CheckInput(element))
                    {
                        WriteLine("Enter element in correct format(XX00000X)!");
                        i =- 1;
                        continue;
                    }

                    elements[i] = element;
                }
                controlArray = elements;
            }
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
            Environment.Exit(-1);
        }
        sorted = Sort(controlArray);
        Array.Reverse(sorted);
        PrintArray(controlArray, sorted);
    } 
    static string[] Sort(string[] array)
    {
        const int wordLength = 8;
        int length = array.Length;
        string[] sorted = new string[length];
        Array.Copy(array, sorted, length);

        for (int i = wordLength - 1; i >= 0; i--)
        {
            string[] tempArray = new string[length];
            int[] charArray = new int[length];
            Array.Copy(sorted, tempArray, length);

            for (int j = 0; j < length; ++j)
            {
                charArray[j] = (int) sorted[j][i];
            }

            int[] counters = new int[charArray.Max() + 1];
            
            for (int j = 0; j < length; ++j)
            {
                counters[charArray[j]] += 1;
            }
            for (int j = 1; j < counters.Length; ++j)
            {
                counters[j] += counters[j - 1];
            }

            for (int j = length - 1; j >= 0; --j)
            {
                counters[charArray[j]] -= 1;
                sorted[counters[charArray[j]]] = tempArray[j];
            }
        }
        return sorted;
    }
    static bool CheckInput(string s)
    {
        if(s.Length > 0)
        {
            int i = 0;
                if (char.IsLetter(s[i]) && char.IsLetter(s[i+1]) && char.IsDigit(s[i+2]) && char.IsDigit(s[i+3]) 
                    && char.IsDigit(s[i+4]) && char.IsDigit(s[i+5]) && char.IsDigit(s[i+6]) && char.IsLetter(s[i+7]))
                {
                    return true;           
                }
                else
                {
                    return false;
                }
        }
        else
        {
            return false;
        }        
    }
    static void PrintArray(string[] controlArray, string[] sorted)
    {
        WriteLine();
        WriteLine("Old array:");
        for (int i = 0; i < controlArray.Length; ++i)
        {
            if (String.Equals(controlArray[i], sorted[i]))
            {
                WriteLine(controlArray[i]);
                continue;
            }
            ForegroundColor = ConsoleColor.DarkGreen;
            Write("{0} ", controlArray[i]);
            ResetColor();
        }
        WriteLine();
        WriteLine("Sorted array:");
        for (int i = 0; i < sorted.Length; ++i)
        {
            if (String.Equals(controlArray[i], sorted[i]))
            {
                WriteLine(sorted[i]);
                continue;
            }
            ForegroundColor = ConsoleColor.Magenta;
            Write("{0} ", sorted[i]);
            ResetColor();
        }
    }
}
