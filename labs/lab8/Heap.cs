using System;
using System.Text;
using static System.Console;

namespace lab8
{
    public class Heap
    {
        private int[] items;
        private int size;
        public Heap()
        {
            this.items = new int[16];
            this.size = 0;
        }
        public void Insert(int value)
        {
            if (size == this.items.Length)
            {
                Expand();
            }
            items[size] = value;
            size++;
        }
        private void Heapify(int i)
        {
            WriteLine("A binary tree is not a maximum binary heap.");
            WriteLine("Restoration of properties of a binary heap:");
            WriteLine();
            while (i > 0)
            {
                if (items[i] > items[(i - 1) / 2])
                {
                    WriteLine($"Swap node [{items[i]}] with node [{items[(i - 1) / 2]}]");
                    int tmp = this.items[(i - 1) / 2];
                    this.items[(i - 1) / 2] = this.items[i];
                    this.items[i] = tmp;
                    this.Print(0, 0);
                    WriteLine();
                }
                i = (i - 1) / 2;
            }
        }

        public void DoPreorderTraversal(int i)
        {
            if (items[i].ToString() == null)
            {
                return;
            }
            if ((2 * i + 1) < this.items.Length)
            {
                if (items[2 * i + 1] > items[i])
                {
                    this.Heapify(2 * i + 1);
                }
            }
            if ((2 * i + 2) < this.items.Length)
            {
                if (items[2 * i + 2] > items[i])
                {
                    this.Heapify(2 * i + 2);
                }
            }
            try
            {
                DoPreorderTraversal(2 * i + 1);
                DoPreorderTraversal(2 * i + 2);
            }
            catch
            {
                return;
            }
        }

        public bool CheckCompleteness()
        {
            string[] copyHeap = this.CopyHeap();
            for (int i = 0; i < size; i++)
            {
                if ((2 * i + 1) < size && (2 * i + 2) < size)
                {
                    if (copyHeap[2 * i + 1] == null && copyHeap[2 * i + 2] != null)
                    {
                        return false;
                    }
                    else if (copyHeap[2 * i + 1] != null && copyHeap[2 * i + 2] == null)
                    {
                        int j = 2 * i + 1;
                        if ((2 * j + 1) < size)
                        {
                            if (copyHeap[2 * j + 1] != null)
                            {
                                return false;

                            }
                        }
                    }
                }
            }
            return true;
        }
        private void Expand()
        {
            int oldCapacity = this.items.Length;
            int[] oldArray = this.items;
            this.items = new int[oldCapacity * 2];
            Array.Copy(oldArray, this.items, oldCapacity);
        }
        private string[] CopyHeap()
        {
            string[] copy = new string[size];
            for (int i = 0; i < size; i++)
            {
                copy[i] = this.items[i].ToString();
            }
            return copy;
        }
        public void Print(int i, int position)
        {
            if (size == 0)
            {
                WriteLine("Tree is empty");
                return;
            }
            else if (i >= size)
            {
                return;
            }
            position += 10;
            this.Print((2 * i + 2), position);
            WriteLine("\n");
            for (int j = 5; j < position; j++)
                Write(" ");
            if (i == 0)
            {
                Write("\r"+"ROOT: " + items[i] + "\n");
            }
            else
            {        
                Write(items[i] + "\n");
            }
            this.Print((2 * i + 1), position);
        }
    }
}