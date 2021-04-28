using System;
using System.Collections.Generic;
class AddHashTable
{
    List<string> [] table2;
    public int defSize = 2000;
    public int size2 = 0;
    public AddHashTable()
    {
        table2 = new List<string>[defSize];
        for (int i = 0; i < defSize; i++)
        {
            table2[i] = null;
        }
        size2 = 0;
    }
    class Entry2
    {
        string value;
        public Entry2(string value)
        {
            this.value = value;
        }
        public string getValue()
        {
            return value;
        }
        public override string ToString()
        {
            return $" {value}";
        }
    }
    public void Insert2(string key, string value)
    {
        Entry2 entry2 = new Entry2(value);
        int hash = GetHash2(key);
        List<string> list = new List<string>();
        for(int i = 0; i < table2.Length; i++)
        {
            if(table2[hash] == null)
            {
                list.Add(entry2.ToString());
                table2[hash] = list;
                return;
            }
        }
        for(int i = 0; i < table2.Length; i++)
        {
            if(table2[hash] != null)
            {
                list = table2[hash];
                list.Add(entry2.ToString());
                return;
            }
        }
    }
    public void Find2(string key)
    {
        var hash = GetHash2(key);
        var hashTableItem = table2[hash];
        List<string> list = new List<string>();
        if (table2[hash] == null && hash <= defSize)
        {
            Console.WriteLine("No such element");
        }
        else
        {
            list = table2[hash];
            string [] arr = new string [list.Count];
            list.CopyTo(arr);
            for(int j = 0; j < arr.Length; j++)
            {
                Console.WriteLine(arr[j]);
            }
        }
    }
    public void Delete(string key, string name)
    {
        var hash = GetHash2(key);
        if (table2[hash] == null && hash <= defSize)
        {
            return;
        }
        var hashTableItem = table2[hash];
        hashTableItem.Remove(name);
    }
    public void Print2()
    {
        List<string> list = new List<string>();
        for (int i = 0; i < table2.Length; i++)
        {
            if (table2[i] == null && i <= defSize)
            {
                continue;
            }
            else
            {
                list = table2[i];
                string [] arr = new string [list.Count];
                list.CopyTo(arr);
                for(int j = 0; j < arr.Length; j++)
                {
                    Console.WriteLine(arr[j]);
                }
                Console.WriteLine(arr.Length);
            }
        }
    }
    public int HashCode2(string key) 
    {
        int hashKey = 0;
        int n = key.ToString().Length;
        string strKey = key.ToString();
        for(int i = 0; i < n; i++)
        {
            hashKey = strKey[i] + hashKey;
        }
        return (int)(hashKey);
    }
    public int GetHash2(string key) 
    {
        int hashCode = this.HashCode2(key);
        size2 = table2.Length - 1;
        int hash = hashCode % size2;
        return hash;
    }
}