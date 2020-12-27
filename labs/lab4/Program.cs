using static System.Console;

namespace lab4_
{
    class DLList
    {
        static private int size = 0;
        static DLNode tail;
        public class DLNode
        {
            public int data;
            public DLNode next;
            public DLNode prev;
            public DLNode(int data)
            {
                this.data = data;
            }
        }

        public DLList(int data)
        {
            tail = new DLNode(data);
        }

        public static void AddFirst(int data)
        {
            DLNode newNode = new DLNode(data);
            if (tail == null)
            {
                newNode.next = newNode.prev = newNode;
                tail = newNode;
            }
            else
            {
                DLNode head = tail.next;
                newNode.next = head;
                head.prev = newNode;
                newNode.prev = tail;
                tail.next = newNode;
            }
            size++;
        }

        public static void AddLast(int data)
        {
            DLNode newNode = new DLNode(data);
            if (tail == null)
            {
                newNode.next = newNode.prev = newNode;
                tail = newNode;
            }
            else
            {
                DLNode head = tail.next;
                newNode.next = head;
                head.prev = newNode;
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            size ++;
        }

        public static void AddAtPosition(int data, int pos)
        {
            if (pos <= 0)
            {
                WriteLine("Error: incorrect index");
                return;
            }
            else if (pos == 1 || tail == null)
            {
                AddFirst(data);
                return;
            }
            if (tail == tail.next)
            {
                AddLast(data);
                return;
            }
            DLNode newNode = new DLNode(data);
            DLNode current = tail.next;
            int counter = 1;
            while (counter != pos - 1)
            {
                current = current.next;
                counter++;
                if (current == tail && counter == pos - 1)
                {
                    AddLast(data);
                    return;
                }
                else if (current == tail.next)
                {
                    WriteLine("Error: incorrect index");
                    return;
                }
            }
            DLNode next = current.next;
            current.next = newNode;
            newNode.prev = current;
            newNode.next = next;
            next.prev = newNode;
            size ++;
        }

        public static void DeleteFirst()
        {
            if (tail == null)
            {
                WriteLine("Error: list already is empty");
                return;
            }
            else if (tail == tail.next)
            {
                tail = null;
                return;
            }
            else if (tail == tail.next.next)
            {
                tail.next = tail;
                tail = tail.prev;
                return;
            }
            tail.next = tail.next.next;
            tail.next.prev = tail;
            size--;
        }

        public static void DeleteLast()
        {
            if (tail == null)
            {
                WriteLine("Error: list already is empty");
                return;
            }
            DLNode head = tail.next;
            if (tail == tail.next)
            {
                tail = null;
            }
            else if (tail == tail.next.next)
            {
                head.next = head;
                head.prev = head;
            }
            else
            {
                tail.prev.next = head;
                head.prev = tail.prev;
            }
            size --;
        }

        public static void DeleteAtPosition(int pos)
        {
            if (tail == null)
            {
                return;
            }
            else if (tail == tail.next)
            {
                tail = null;
                return;
            }
            if (pos <= 0)
            {
                WriteLine("Error: list already is empty");
                return;
            }
            else if (pos == 1)
            {
                DeleteFirst();
                return;
            }
            DLNode current = tail.next;
            int counter = 1;
            while (counter != pos - 1)
            {
                current = current.next;
                counter++;
                if (current == tail && counter == pos - 1)
                {
                    DeleteLast();
                    return;
                }
                else if (current == tail.next)
                {
                    WriteLine("Error: list already is empty");
                    return;
                }
            }
            DLNode next = current.next.next;
            current.next = next;
            next.prev = current;
            size --;
        }

        public static void AddBeforeTail(int data)
        {
            if (tail == null || tail == tail.next)
            {
                AddFirst(data);
                return;
            }
            AddAtPosition(data, size);
            size ++;
        }
        public static void AddBeforeHead(int data)
        {
            if (tail == null || tail == tail.next)
            {
                AddFirst(data);
                return;
            }
            AddAtPosition(data, size+2);
            size ++;
        }
        public static void ProcessList()
        {
            WriteLine("List before procession: ");
            Print();
            SLList.Print();
        }

        public static void Print()
        {
            if (tail == null)
            {
                WriteLine("Error: list is empty");
                return;
            }
            DLNode current = tail.next;
            do
            {
                Write("{0}", current.data);
                if (current.next != tail.next)
                {
                    Write("-->");
                }
                current = current.next;
            }
            while (current != tail.next);
            {
                WriteLine();
            }
        }
    }

    class Program
    {
        static bool CheckInputType(string part)
        {
            bool canBeParsed = false;
            int result;
            if (int.TryParse(part, out result))
            {
                canBeParsed = true;
            }
            return canBeParsed;
        }
        static void Main(string[] args)
        {
            int counter = 1;
            while (true)
            {
                WriteLine("Commands: \r\n 1)AddFirst+value\r\n 2)AddLast+value\r\n 3)AddAtPosition +value +pos\r\n 4)DeleteFirst\r\n 5)DeleteLast\r\n 6)DeleteAtPosition +pos\r\n 7)AddBeforeTail+value\r\n 8)AddBeforeHead\r\n 9)ProcessList\r\n 10)DeleteOddNumbers\r\n 11)Exit") ;
                WriteLine("Enter command: ");
                string[] input = ReadLine().Trim().Split();
                if (input.Length > 3 || input.Length < 1)
                {
                    WriteLine("Error: invalid command");
                }
                switch (input[0])
                {
                    case "AddFirst":
                        if (input.Length != 2 || !CheckInputType(input[1]))
                        {
                            WriteLine("Error: invalid command or input type");
                        }
                        else
                        {
                            int data = int.Parse(input[1]);
                            DLList.AddFirst(data);
                            WriteLine("Current list: ");
                            DLList.Print();
                        }
                        break;
                    case "AddLast":
                        if (input.Length != 2 || !CheckInputType(input[1]))
                        {
                            WriteLine("Error: invalid command or input type");
                        }
                        else
                        {
                            int data = int.Parse(input[1]);
                            DLList.AddLast(data);
                            WriteLine("Current list: ");
                            DLList.Print();
                        }
                        break;
                    case "AddAtPosition":
                        if (input.Length != 3 || !CheckInputType(input[1]) || !CheckInputType(input[2]))
                        {
                            WriteLine("Error: invalid command or input type");
                        }
                        else
                        {
                            int data = int.Parse(input[1]);
                            int pos = int.Parse(input[2]);
                            DLList.AddAtPosition(data, pos);
                            WriteLine("Current list: ");
                            DLList.Print();
                        }
                        break;
                    case "DeleteFirst":
                        if (input.Length != 1)
                        {
                            WriteLine("Error: invalid command");
                        }
                        else
                        {
                            DLList.DeleteFirst();
                            WriteLine("Current list: ");
                            DLList.Print();
                        }
                        break;
                    case "DeleteLast":
                        if (input.Length != 1)
                        {
                            WriteLine("Error: unknown command");
                        }
                        else
                        {
                            DLList.DeleteLast();
                            WriteLine("Current list:");
                            DLList.Print();
                        }
                        break;
                    case "DeleteAtPosition":
                        if (input.Length != 2 || !CheckInputType(input[1]))
                        {
                            WriteLine("Error: invalid command or input type");
                        }
                        else
                        {
                            int pos = int.Parse(input[1]);
                            DLList.DeleteAtPosition(pos);
                            WriteLine("Current list: ");
                            DLList.Print();
                        }
                        break;
                    case "AddBeforeTail":
                        if (input.Length != 2 || !CheckInputType(input[1]))
                        {
                            WriteLine("Error: invalid command or input type");
                        }
                        else
                        {
                            int data = int.Parse(input[1]);
                            DLList.AddBeforeTail(data);
                            WriteLine("Current list:");
                            DLList.Print();
                        }
                        break;
                    case "AddBeforeHead":
                        if (input.Length != 2)
                        {
                            WriteLine("Error: unknown command");
                        }
                        else
                        {
                            int data = int.Parse(input[1]);
                            DLList.AddBeforeHead(data);
                            WriteLine("Current list:");
                            DLList.Print();
                        }
                        break;
                    // case "DeleteOddNumber":
                    //     if (input.Length != 1)
                    //     {
                    //         WriteLine("Error: unknown command");
                    //     }
                    //     else
                    //     {
                    //         int data = int.Parse(input[1]);
                    //         DLList.DeleteOddNumbers(DLList copy);
                    //         WriteLine("Current list:");
                    //         DLList.Print();
                    //     }
                    //     break;
                    case "ProcessList":
                        if (input.Length != 1)
                        {
                            WriteLine("Error: invalid command");
                        }
                        else
                        {
                            DLList.ProcessList();
                        }
                        break;
                    case "Exit":
                        if (input.Length != 1)
                        {
                            WriteLine("Error: invalid command"); 
                            break;
                        }
                        else
                        {
                            WriteLine("Exit"); 
                            return;
                        }
                    default: WriteLine("Error: unknown command"); 
                    break;
                }
                counter++;
            }
        }
    }
    class SLList
    {
        static SLNode head;

        public class SLNode
        {
            public int data;
            public SLNode next;

            public SLNode(int data)
            {
                this.data = data;
            }
        }

        public SLList(int data)
        {
            head = new SLNode(data);
        }
        public static void Print()
        {
            WriteLine("SLList: ");
            if (head == null)
            {
                WriteLine("List is empty");
                return;
            }
            SLNode current = head;
            while (current != null)
            {
                 Write("{0}", current.data);
                if (current.next != null)
                {
                    Write("-->");
                }
                current = current.next;
            }
            WriteLine();
            head = null;
        }
    }
}