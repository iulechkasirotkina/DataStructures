using System.Collections;
using System;

namespace DataStructures.LinkList
{
    public class LinkedList
    {
        public int Length { get; private set; }

        private Node _root;

        public int this[int index]
        {
            get
            {
                CheckIndexOutOfRangeException(index);
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
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

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }

        public LinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;
                

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                   
                }

                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public void AddToBeginning(int value)
        {
            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
            Length++;
        }

        public void AddToEnd(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
            }
            else
            {
                Node tmp = GetLastElement(_root);
                tmp.Next = new Node(value);
            }
            Length++;
        }

        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
                Length++;
                return;
            }
            if (index == Length)
            {
                AddToEnd(value);
                return;
            }
            else
            {
                    CheckIndexOutOfRangeException(index);
                    Node current = _root;
                    for (int i = 1; i < index; i++)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = new Node(value);
                    current.Next.Next = tmp;
                    Length++;
            }
        }

        public void DeleteFromEnd()
        {
            if (Length != 0)
            {
                Node tmp = GetLastElement(_root);
                tmp = null;
                Length--;
            }
        }

        public void DeleteFromBeginning()
        {
            if (Length != 0)
            {
                _root = _root.Next;
                Length--;
            }
        }

        public void DeleteByIndex(int index)
        {
            CheckIndexOutOfRangeException(index);
            if (Length == 0)
            {
                return;
            }
            if (index == 0)
            {
                DeleteFromBeginning();
                return;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                Length--;
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

        public void ChangeByIndex (int index, int value)
        {
            CheckIndexOutOfRangeException(index);

            if (index == 0)
            {
                Node tmp = _root.Next;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                Node tmp = _root;
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                Node curr = tmp.Next.Next;
                tmp.Next = new Node(value);
                tmp.Next.Next = curr;
            }
        }

        public void Reverse()
        {
            if (Length != 0)
            {
                Node tmp = _root;
                tmp = GetLastElement(_root);
                 Node newList = tmp;
                int length = Length;
                DeleteByIndex(Length - 1);
                Node a = newList;
                for (int i = 1; i < length; i++)
                {
                    tmp = GetLastElement(_root);
                    a.Next = new Node(tmp.Value);
                    DeleteByIndex(Length - 1);
                    a = a.Next;
                }
                Length = length;
                _root = newList;
            }
            else
                return;
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
            int max= _root.Value;
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
          return  GetIndexByValue(FindMaxElement());
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
            LinkedList arrayAdd = new LinkedList(array);

            if (Length == 0)
            {
                if (array.Length != 0)
                {
                    _root = arrayAdd._root;
                    Length = array.Length;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (Length == 1)
                {
                    _root.Next = arrayAdd._root;
                    Length += array.Length;
                }
                else
                {
                    Node tmp = GetLastElement(_root);
                    tmp.Next = arrayAdd._root;
                    Length += array.Length;
                }
            }
        }

        public void AddArrayToBeginning(int[] array)
        {
            LinkedList arrayAdd = new LinkedList(array);
            if (Length == 0)
            {
                _root = arrayAdd._root;
                Length = array.Length;
                return;
            }
            if (array.Length == 0)
            {
                    return;
            }
            if (array.Length == 1)
            {
                 arrayAdd._root.Next = _root;
                        _root = arrayAdd._root;
                        Length += array.Length;
                return;
            }
            else
            {
                        Node tmp = GetLastElement(arrayAdd._root);
                        tmp.Next = _root;
                        _root = arrayAdd._root;
                        Length += array.Length;
            }    
        }

        public void AddArrayByIndex(int index, int[] array)
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
               LinkedList arrayAdd = new LinkedList(array);
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
                    tmp2.Next = curr;
                    Length += array.Length;
                }
            }
        }

        public void DeleteNElementsFromEnd (int n)
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
                Node newList = new Node(FindMinElement());
                int length = Length;
                DeleteByValueFirst(FindMinElement());
                Node tmp = _root;
                Node a = newList;
                for (int i = 1; i < length; i++)
                {
                    a.Next = new Node(FindMinElement());
                    DeleteByValueFirst(FindMinElement());
                    a = a.Next;
                }
                Length = length;
                _root = newList;
            }
            else
                return;
        }

        public void SortInDescendingOrder()
        {
            if (Length != 0)
            {
                Node newList = new Node(FindMaxElement());
                int length = Length;
                DeleteByValueFirst(FindMaxElement());
                Node tmp = _root;
                Node a = newList;
                for (int i = 1; i < length; i++)
                {
                    a.Next = new Node(FindMaxElement());
                    DeleteByValueFirst(FindMaxElement());
                    a = a.Next;
                }
                Length = length;
                _root = newList;
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
                throw new IndexOutOfRangeException("");
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
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }
            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
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
