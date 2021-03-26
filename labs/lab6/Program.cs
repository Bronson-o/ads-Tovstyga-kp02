using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int inputInt = 0;
            Console.WriteLine("Enter command:\r\nPress Q for Control\r\nPress E for Standart");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.E)
            {
                do
                {
                    Console.WriteLine("\r\nEnter a positive number: ");
                    input = Console.ReadLine();
                    bool temp = int.TryParse(input, out inputInt);
                } while (inputInt <= 0);
            }
            if (keyInfo.Key == ConsoleKey.Q)
            {
                RunCommands(123);
                Console.WriteLine();
                RunCommands(65433456);
            }
            else
            {
                RunCommands(inputInt);
            }
        }

        static void RunCommands(int number)
        {
            Console.WriteLine($"Number: {number}");
            DLNode deck = WriteInputInDeckAndPrint(number);
            if (CheckOnPalindrome(deck) == true)
            {
                Console.WriteLine($"Number: {number} is a palindrome.");
            }
            else
            {
                Console.WriteLine($"Number: {number} isn't a palindrome.");
                deck = MakePalindrome(deck);
                Console.WriteLine($"Number: {deck.ToString()} is a palindrome.");
            }
        }

        static DLNode WriteInputInDeckAndPrint(int inputNum)
        {
            int temp;
            DLNode deck = new DLNode();
            while (inputNum != 0)
            {
                temp = inputNum%10;
                deck.AddFirst(temp);    
                inputNum = inputNum / 10;
                PrintDeck("AddFirst", deck);
            }
            return deck;
        }

        static void PrintDeck(string cmd, DLNode deck)
        {
            Console.WriteLine($"Deck {cmd}: {deck.Print()}");
        }

        static bool CheckOnPalindrome(DLNode deck)
        { 
            DLNode tempDeck = deck;
            for (int i = 0; i < deck.GetCount()/2; i++)
            {
                if (tempDeck.head.data == tempDeck.tail.data)
                {
                    tempDeck.head = tempDeck.head.next;
                    tempDeck.tail = tempDeck.tail.prev;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static DLNode MakePalindrome(DLNode deck)
        {
            DLNode copyDeck = deck;
            int length = copyDeck.GetCount();
            Node current = copyDeck.tail;
            for (int i = 0; i < length; i++)
            {
                deck.AddLast(current.data);
                PrintDeck("AddLast", deck);
                current = current.prev;
            }
            return deck;
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data)
        {
            this.data = data;
        }
    }

    class DLNode
    {
        public Node head;
        public Node tail;
        private int _size;

        public DLNode()
        {
            this.head = null;
            this.tail = null;
            _size = 0;
        }

        public void AddFirst(int data)
        {
            Node newHead = new Node(data);
            if (head == null)
            {
                head = newHead;
                tail = head;
            }
            else if (head == tail)
            {
                newHead.next = tail;
                tail.prev = newHead;
                head = newHead;
            }
            else
            {
                newHead.next = head;
                head.prev = newHead;
                head = newHead;
            }
            _size++;
        }

        public void AddLast(int data)
        {
            Node newTail = new Node(data);
            if (head == null)
            {
                head = newTail;
                tail = head;
            }
            else if (head == tail)
            {
                head.next = tail;
                tail.next = newTail;
                newTail.prev = tail;
                tail = newTail;
            }
            else
            {
                tail.next = newTail;
                newTail.prev = tail;
                tail = newTail;
            }
            _size++;
        }

        public void DeleteFirst()
        {
            if (head == null)
            {
                Console.WriteLine("Error: can't do operation - list is empty.");
                return;
            }
            else if (head == tail)
            {
                head = null;
                tail = head;
            }
            else if (head.next == tail)
            {
                tail.prev = null;
                head = tail;
            }
            else
            {
                head = head.next;
                head.prev = null;
            }
            _size--;
        }

        public void DeleteLast()
        {
            if (head == null)
            {
                Console.WriteLine("Error: can't do operation - list is empty.");
                return;
            }
            else if (head == tail)
            {
                head = null;
                head = tail;
            }
            else if (head.next == tail)
            {
                head.next = null;
                tail = head;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            _size--;
        }

        public string Print()
        {
            if (head ==  null)
            {
                return("Error: list is empty.");
            }

            Node current = head;
            string result = "";
            do
            {
                result += current.data.ToString();
                if (current.next != null)
                {
                    if (current.next != head) result += " - ";
                    current = current.next;
                }
                else 
                {
                    break;
                }
            } while (current != head);
            return result;
        }

        public int GetCount()
        {
            return _size;
        }

        public override string ToString()
        {
            Node current = head;
            string res = "";
            do
            {
                res += current.data.ToString();
                if (current.next != null)
                {
                    current = current.next;
                }
                else 
                {
                    break;
                }
            } while (current != head);
            return res;
        }
    }
}