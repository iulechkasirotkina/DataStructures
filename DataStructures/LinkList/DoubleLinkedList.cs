using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkList
{
    public class DoubleLinkedList
    {
        private Node _root;
        private Node _tail;
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                CheckIndexOutOfRangeException(index);
                Node tmp;
                if(index < Length/2)
                {
                    tmp = _root;
                    for (int i = 1; i <= index; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    tmp = _tail;
                    for (int i = 1; i <= index; i++)
                    {
                        tmp = tmp.Prev;
                    }
                }
                return tmp.Value;
            }

            set
            {
                CheckIndexOutOfRangeException(index);
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root =  new Node(value);
            _tail = _root;
        }
        public DoubleLinkedList(int [] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                _tail = new Node(array[0]);
                Node tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {

                    tmp.Next = new Node(array[i]);
                    tmp.Next.Prev = tmp;
                    tmp = tmp.Next;
                }
                _tail = tmp;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        public void AddToBeginning(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
                _tail = _root;
                Length++;
            }
            else
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
                tmp.Prev = _root;
                Length++;
            }
        }

        public void AddToEnd(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Node tmp = GetLastElement(_root);
                tmp.Next = new Node(value);
                tmp.Next.Prev = tmp;
                _tail = tmp.Next;
            }
            Length++;
        }

        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                AddToBeginning(value);
            }
            else
            {
                if (index == Length)
                {
                    AddToEnd(value);
                }
                else
                {
                    CheckIndexOutOfRangeException(index);
                    Node a = _root;
                    for (int i = 1; i < index; i++)
                    {
                        a = a.Next;
                    }

                    Node tmp = a.Next;
                    a.Next = new Node(value);
                    a.Next.Next = tmp;
                    a.Next.Next.Prev = a.Next;
                    a.Next.Prev = a;
                    Length++;
                }
            }
        }

        public void DeleteFromEnd()
        {
            if (Length != 0)
            {
                if (Length == 1)
                {
                    _tail = null;
                    _root = _tail;
                    Length--;
                    return;
                }
                _tail = _tail.Prev;
                _tail.Next = null;
                Length--;
            }
        }

        public void DeleteFromBeginning()
        {
            if (Length != 0)
            {
                if (Length == 1)
                {
                    _root = null;
                    _tail = _root;
                    Length--;
                    return;
                }
                _root = _root.Next;
                _root.Prev = null;
                Length--;
                
            }
        }

        public void DeleteByIndex(int index)
        {
            CheckIndexOutOfRangeException(index);
            if (Length == 0)
            {
                _root = null;
                _tail = _root;
            }
            else
            {
                if (index == 0)
                {
                    DeleteFromBeginning();
                }
                else
                {
                    if (index == Length - 1)
                    {
                        DeleteFromEnd();
                    }
                    else
                    {
                        Node a = _root;
                        for (int i = 1; i < index; i++)
                        {
                            a = a.Next;
                        }
                        a.Next = a.Next.Next;
                        a.Next.Prev = a;
                        Length--;
                    }
                }
            }
        }

        public int GetIndexByValue(int value)
        {
            int index = -1;
            if (Length == 0)
            {
                return index;
            }
            if (_root.Value == value)
            {
                return index = 0;
            }
            else
            {
                Node tmp = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (tmp.Value == value)
                    {
                        index = i;
                        break;
                    }
                    tmp = tmp.Next;
                }
            }
            return index;
        }

        public void ChangeByIndex(int index, int value)
        {
            CheckIndexOutOfRangeException(index);

            if (index == 0)
            {
                if(Length == 1)
                {
                    _root = new Node(value);
                    _tail = _root;
                    return;
                }
                Node tmp = _root.Next;
                _root = new Node(value);
                _root.Next = tmp;
                tmp.Prev = _root;

            }
            else
            {
                if (index == Length - 1)
                {
                    Node tmp = _tail.Prev;
                    _tail = new Node(value);
                    _tail.Prev = tmp;
                    tmp.Next = _tail;

                }
                else
                {
                    AddByIndex(index, value);
                    DeleteByIndex(index + 1);
                }
            }
        }

        public int FindMinElement()
        {
            ChekArgumentOutOfRangeException(Length);
            int min = _root.Value;
            Node tmp = _root;
            while (tmp != null)
            {
                if (tmp.Value < min)
                {
                    min = tmp.Value;
                }
                tmp = tmp.Next;
            }

            return min;
        }

        public int FindMaxElement()
        {
            ChekArgumentOutOfRangeException(Length);
            int max = _root.Value;
            Node tmp = _root;
            while (tmp != null)
            {
                if (tmp.Value > max)
                {
                    max = tmp.Value;
                }
                tmp = tmp.Next;
            }

            return max;
        }

        public int FindIndexOfMinElement()
        {
            return GetIndexByValue(FindMinElement());
        }

        public int FindIndexOfMaxElement()
        {
            return GetIndexByValue(FindMaxElement());
        }

        public void DeleteByValueFirst(int value)
        {
            if (GetIndexByValue(value) != -1)
            {
                DeleteByIndex(GetIndexByValue(value));
            }
        }

        public void DeleteByValueAll(int value)
        {
            while (GetIndexByValue(value) != -1)
            {
                DeleteByValueFirst(value);
            }
        }
        
        public void AddArrayToEnd(int[] array)
        {
            DoubleLinkedList arrayNew = new DoubleLinkedList(array);

            if (array.Length == 0)
            {
                return;
            }
            if (Length == 0)
            {
                if (array.Length != 0)
                {
                    _root = arrayNew._root;
                    _tail = arrayNew._tail;
                    Length = array.Length;
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                if (Length == 1)
                {
                    _root.Next = arrayNew._root;
                    _root.Next.Prev = _root;
                    _tail = arrayNew._tail;
                    Length += array.Length;
                }
                else
                {
                    Node tmp = GetLastElement(_root);
                    tmp.Next = arrayNew._root;
                    arrayNew._root.Prev = tmp;
                    _tail = arrayNew._tail;

                    Length += array.Length;
                }
            }
        }
        
        public void AddArrayToBeginning(int[] array)
        {
            DoubleLinkedList arrayNew = new DoubleLinkedList(array);

            if (Length == 0)
            {
                _root = arrayNew._root;
                _tail = arrayNew._tail;
                Length = array.Length;
                return;
            }
            if (array.Length == 0)
                {
                    return;
                }
                  if (array.Length == 1)
                    {
                        AddToBeginning(array[0]);
                return;
                    }
                    else
                    {
                        Node tmp = GetLastElement(arrayNew._root);
                        tmp.Next = _root;
                        tmp.Next.Prev = tmp;
                        _root = arrayNew._root;
                        Length += array.Length;
                    }
        }

        public void AddArrayByIndex(int index, int [] array)
        {
            if (index == Length)
            {
                AddArrayToEnd(array);
                return;
            }
            if (index == 0)
            {
                AddArrayToBeginning(array);
                return;
            }
            else
            {
                DoubleLinkedList arrayAdd = new DoubleLinkedList(array);
                if (arrayAdd._root == null)
                {
                    return;
                }
                if (arrayAdd._root.Next == null)
                {
                    AddByIndex(index, arrayAdd._root.Value);
                    return;
                }
                else
                {
                    CheckIndexOutOfRangeException(index);
                    Node tmp = _root;
                    Node tmp2 = GetLastElement(arrayAdd._root);
                    for (int i = 1; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    Node curr = tmp.Next;
                    tmp.Next = arrayAdd._root;
                    tmp.Next.Prev = tmp;
                    tmp2.Next = curr;
                    tmp2.Next.Prev = tmp2;
                    Length += array.Length;
                }
            }
        }

        public void DeleteNElementsFromEnd(int n)
        {
            for (int i = 0; i < n; i++)
            {
                DeleteFromEnd();
            }

        }

        public void DeleteNElementsFromBeginning(int n)
        {
            for (int i = 0; i < n; i++)
            {
                DeleteFromBeginning();
            }
        }

        public void DeleteNElementsByIndex(int n, int index)
        {
            for (int i = 0; i < n; i++)
            {
                DeleteByIndex(index);
            }
        }

        public void SortInAscendingOrder()
        {
            if (Length != 0)
            {
                Node newRoot = new Node(FindMinElement());
                int length = Length;
                DeleteByValueFirst(FindMinElement());
                Node a = newRoot;
                for (int i = 1; i < length; i++)
                {
                    a.Next = new Node(FindMinElement());
                    a.Next.Prev = a;
                    DeleteByValueFirst(FindMinElement());
                    a = a.Next;
                }
                _tail = a;
                Length = length;
                _root = newRoot;
            }
            else
                return;
        }

        public void SortInDescendingOrder()
        {
            if (Length != 0)
            {
                Node newRoot = new Node(FindMaxElement());
                int length = Length;
                DeleteByValueFirst(FindMaxElement());
                Node tmp = _root;
                Node a = newRoot;
                for (int i = 1; i < length; i++)
                {
                    a.Next = new Node(FindMaxElement());
                    a.Next.Prev = a;
                    DeleteByValueFirst(FindMaxElement());
                    a = a.Next;
                }
                _tail = a;
                Length = length;
                _root = newRoot;
            }
            else
                return;
        }

        public void Reverse()
        {
            if (Length != 0)
            {
                Node tmp = GetLastElement(_root);
                Node newRoot = new Node(tmp.Value);
                int length = Length;
                DeleteByIndex(Length - 1);
                Node a = newRoot;
                for (int i = 1; i < length; i++)
                {
                    tmp = GetLastElement(_root);
                    a.Next = new Node(tmp.Value);
                    a.Next.Prev = a;
                    DeleteByIndex(Length - 1);
                    a = a.Next;
                }
                _tail = a;
                Length = length;
                _root = newRoot;
            }
            else
                return;
        }

        private Node GetLastElement(Node tmp)
        {
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            return tmp;
        }

        private void CheckIndexOutOfRangeException(int index)
        {

            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException("my");
            }

        }

        private void ChekArgumentOutOfRangeException(int Length)
        {
            if (Length <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList doublelinkedList = (DoubleLinkedList)obj;

            if (Length != doublelinkedList.Length)
            {
                return false;
            }
            Node tmp1 = _root;
            Node tmp2 = doublelinkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            tmp1 = _tail;
            tmp2 = doublelinkedList._tail;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Prev;
                tmp2 = tmp2.Prev;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
    }
}
