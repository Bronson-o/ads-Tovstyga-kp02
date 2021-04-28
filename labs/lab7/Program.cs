using System;
using System.Collections.Generic;

namespace lab7
{
    class Program
    { 
        class HashTable
        {
            public double loadness;
            public int size;
            public int maxSize = 2000;
            Entry [] table;
            public HashTable()
            {
                table = new Entry[maxSize];
                for (int i = 0; i < maxSize; i++)
                {
                    table[i] = null;
                }
                loadness = 0;
                size = 0;
            }
            class Entry
            {
                Key key;
                Value value;
                public Entry(Key key, Value value)
                {
                    this.key = key;
                    this.value = value;
                }
                public Key getKey()
                {
                    return key;
                }
                public Value getValue()
                {
                    return value;
                }
                public override string ToString()
                {
                    return $"{key} {value}";
                }
            }
            public void Print()
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] == null && i <= maxSize)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("{0} --> {1}", table[i].getKey(), table[i].getValue());
                    }
                }
            }
            private bool CheckOpenSpace()
            {
                bool isOpen = false;
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] == null)
                    {
                        isOpen = true;
                    }
                }
                return isOpen;
            }
            public void InsertEntry(Key key, Value value)
            {
                loadness = size / maxSize;
                Rehashing();
                Entry entry = new Entry(key, value);
                int hash = GetHash(key);
                if (!CheckOpenSpace())
                {
                    Console.WriteLine("Table is full");
                    Rehashing();
                    return;
                }
                while (table[hash] != null && table[hash].getKey() != key)
                {
                    hash = (hash + 1) % table.Length;
                }
                table[hash] = entry;
                size++;
                loadness = size / maxSize;
            }
            public void Remove(Key key)
            {
                int hash = GetHash(key);
                if (table[hash] == null)
                {
                    Console.WriteLine("No such element");
                }
                else
                {
                    table[hash] = null;
                    size--;
                    loadness = size / maxSize;
                    Console.WriteLine("Element was deleted");
                }
            }
            public bool Rehashing()
            {
                if(loadness == 0.6)
                {
                    Entry[] newTable = new Entry[table.Length * 2];
                    for(int j = 0; j < table.Length; j++)
                    {
                       if(table[j] != null)
                       {
                            Entry entry = table[j];
                            int hash = GetHash(entry.getKey());
                            for(int i = 0; i < newTable.Length; i++)
                            {
                                int c = i;
                                int key = (hash + c) % newTable.Length;
                                if(newTable[key] == null)
                                {
                                    newTable[key] = entry;
                                    break;
                                }
                            }
                        }
                    }
                    table = newTable;
                    return true;
                }
                return false;
            }
            public Value FindEntry(Key key)
            {
                int hash = GetHash(key);
                if (table[hash] == null)
                {
                    Console.WriteLine("No such element");
                    return null;
                }
                else
                {
                    Console.WriteLine("{0} --> {1}", table[hash].getKey(), table[hash].getValue());
                }
                return table[hash].getValue();
            }
            public int HashCode(Key key) 
            {
                int hashKey = 0;
                int n = key.ToString().Length;
                string strKey = key.ToString();
                for(int i = 0; i < n; i ++)
                {
                    hashKey = strKey[i] + hashKey;
                }
                return (int)(hashKey);
            }
            public int GetHash(Key key) 
            {
                int hashCode = this.HashCode(key);
                size = table.Length - 1;
                int hash = hashCode % size;
                return hash;
            }
        }
        class Key
        {
            public string firstName;
            public string lastName;
            public Key()
            {
                firstName = "";
                lastName = "";
            }
            public override string ToString()
            {
                return $"{firstName} {lastName}";
            }
        }
        class Value
        {
            public int patientID;
            public string familyDoctor;
            public  string address;
            public Value()
            {
                patientID = 0;
                familyDoctor = "";
                address = "";
            }
            public override string ToString()
            {
                return $"{patientID} {familyDoctor} {address}";
            }
        }
        static int GenerateID(int count)
        {
            int start = 35900;
            return start + count;
        }
        
        static bool CheckCountOfPatients(List<string> list, string doctor)
        {
            int counter = 0;
            string [] arr = new string[list.Count];
            list.CopyTo(arr);
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == doctor)
                {
                    counter++;
                }
                if(counter == 6)
                {
                    return false;
                }
            }
            return true;
        }
        static void PrintListOfCommands()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Commands you can use:");
            Console.WriteLine("control - fill table with control values");
            Console.WriteLine("add - add new patient");
            Console.WriteLine("remove - remove element");
            Console.WriteLine("find - find element");
            Console.WriteLine("print - print table");
            Console.WriteLine("findAll - find all patients of doctor");
            Console.WriteLine("exit - end the programm");
            Console.ResetColor();
            Console.WriteLine();
        }
        static void ControlValues(HashTable hs, int count, List<string> listDoctor,
        List<string> baseOfDoctors, AddHashTable addedHS, string firstName, string lastName, string address,
        string familyDoctor)
        {
            Key key = new Key();
            Value value = new Value();
            key.firstName = firstName;
            key.lastName = lastName;
            value.patientID = GenerateID(count);
            value.address = address;
            value.familyDoctor = familyDoctor;
            listDoctor.Add(value.familyDoctor);
            if(!baseOfDoctors.Contains(value.familyDoctor))
            {
                baseOfDoctors.Add(value.familyDoctor);
            }
            hs.InsertEntry(key, value);
            string newValue = value.patientID + " " + key.ToString() + " " + value.address;
            addedHS.Insert2(value.familyDoctor, newValue);
        }
        static void Main(string[] args)
        {
            HashTable hs = new HashTable();
            AddHashTable addedHS = new AddHashTable();
            List<string> listDoctor = new List<string>();
            List<string> baseOfDoctors = new List<string>();
            int count = 0;
            while(true)
            {
                Key key = new Key();
                Value value = new Value();
                PrintListOfCommands();
                Console.WriteLine("Enter your command:");
                string command = Console.ReadLine();
                string[] subcommands = command.Split(' ');
                if((subcommands[0] == "control")&&(subcommands.Length == 1))
                {
                    ControlValues(hs, count, listDoctor, baseOfDoctors, addedHS, "Anthony",
                    "Byrne", "Deckergasse", "Max");
                     count++;
                    ControlValues(hs, count, listDoctor, baseOfDoctors, addedHS, "Colm",
                    "McCarthy", "Dorotheergasse", "Max");
                     count++;
                    ControlValues(hs, count, listDoctor, baseOfDoctors, addedHS, "Tim",
                    "Mielants", "Schönlaterngasse", "Max");
                     count++;
                    ControlValues(hs,  count, listDoctor, baseOfDoctors, addedHS, "Steven",
                    "Knight", "Wienzeile", "Vladislav");
                     count++;
                    ControlValues(hs, count, listDoctor, baseOfDoctors, addedHS, "Sofia",
                    "Knight", "Museumsquartier", "Vladislav");
                     count++;
                    ControlValues(hs, count, listDoctor, baseOfDoctors, addedHS, "Cillian",
                    "Murphy", "Pazmanitengasse", "John");
                     count++;
                     ControlValues(hs, count, listDoctor, baseOfDoctors, addedHS, "Paul",
                    "Anderson", "Karlsplatz", "Jacob");
                     count++;
                     Console.WriteLine("The table was filled");
                }
                else if((subcommands[0] == "add")&&(subcommands.Length == 1))
                {
                    Console.WriteLine("Enter name: ");
                    key.firstName = Console.ReadLine();
                    Console.WriteLine("Enter surname: ");
                    key.lastName = Console.ReadLine();
                    value.patientID = GenerateID(count);
                    Console.WriteLine("Enter address: ");
                    value.address = Console.ReadLine();
                    Console.WriteLine("Enter doctor: ");
                    value.familyDoctor = Console.ReadLine();
                    listDoctor.Add(value.familyDoctor);
                    if(!baseOfDoctors.Contains(value.familyDoctor))
                    {
                        baseOfDoctors.Add(value.familyDoctor);
                    }
                    if(CheckCountOfPatients(listDoctor, value.familyDoctor))
                    {
                        hs.InsertEntry(key, value);
                        string newValue = value.patientID + " " + key.ToString() + " " + value.address;
                        addedHS.Insert2(value.familyDoctor, newValue);
                        count++;
                        Console.WriteLine("Patient was added to base");
                    }
                    else
                    {
                        Console.WriteLine($"Doctor {value.familyDoctor} have no free places");
                        Console.WriteLine("You can choose another doctor");
                        string freeDoctor = "";
                        string [] arr = new string[baseOfDoctors.Count];
                        baseOfDoctors.CopyTo(arr);
                        for(int j = 0; j < arr.Length; j++)
                        {
                            string doctor = arr[j];
                            if(CheckCountOfPatients(listDoctor, doctor))
                            {
                               freeDoctor += doctor + "\r\n";
                            }
                        }
                        if(freeDoctor.Length > 0)
                        {
                            Console.WriteLine("Free doctors: ");
                            Console.Write(freeDoctor);
                        }
                        else
                        {
                            Console.WriteLine("There are no free doctors");
                        }
                    }
                }
                else if((subcommands[0] == "remove")&&(subcommands.Length == 1))
                {
                    Console.WriteLine("Enter name: ");
                    key.firstName = Console.ReadLine();
                    Console.WriteLine("Enter surname: ");
                    key.lastName = Console.ReadLine();
                    Value value2 = hs.FindEntry(key);
                    string newValue = " " + value2.patientID + " " + key.ToString() + " " + value2.address;
                    hs.Remove(key);
                    addedHS.Delete(value2.familyDoctor, newValue);
                    listDoctor.Remove(value2.familyDoctor);
                }
                else if((subcommands[0] == "find")&&(subcommands.Length == 1))
                {
                    Console.WriteLine("Enter name: ");
                    key.firstName = Console.ReadLine();
                    Console.WriteLine("Enter surname: ");
                    key.lastName = Console.ReadLine();
                    hs.FindEntry(key);
                }
                else  if((subcommands[0] == "print")&&(subcommands.Length == 1))
                {
                    Console.WriteLine("Hash table:");
                    hs.Print();
                }
                else if((subcommands[0] == "findAll")&&(subcommands.Length == 1))
                {
                    Console.WriteLine("Enter doctor's name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Doctor's {name} list of patients");
                    addedHS.Find2(name);
                }
                else if(command == "exit")
                {
                    Console.WriteLine("Programm was closed");
                    Console.WriteLine("Bye!");
                    break;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unknown command");
                    Console.ResetColor();
                }
            }
        }
    }
}
