using System;
using System.Collections;

namespace DataStructures
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            int[] _array = new int[12];
            Length = 0;

        }

        public ArrayList (int [] array)
        {
            _array = new int [(int)(array.Length*1.33)];
            Length = array.Length;
            Array.Copy(array, 0, _array, 0, Length);
        }

        public ArrayList( int value)
        {
            _array = new int[12];
            _array[0] = value;
            Length = 1;
        }

        public int this[int i]
        {
            get
            {
                CheckIndexOutOfRangeException(i);
                return _array[i];
            }
            set
            {
                CheckIndexOutOfRangeException(i);
                _array[i] = value;
            }
        }

        public void AddToEnd (int value)
        {
            if (Length >= _array.Length)
            {
                IncreaseLenght();
            }
            _array [Length] = value;
            Length++;
        }

        public void AddToBeginning (int value)
        {
            if (Length >= _array.Length)
            {
                IncreaseLenght();
            }
            Length++;
            for(int i = Length-1; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = value;
        }

        public void AddByIndex (int value, int index)
        {
            if (index != 0)
            {
                CheckIndexOutOfRangeException(index-1);
            }
            if (Length >= _array.Length)
            {
                IncreaseLenght();
            }
            int[] newArray = new int[_array.Length+1];
            Array.Copy(_array, 0, newArray, 0, index);
            newArray[index] = value;
            Array.Copy(_array, index, newArray, index + 1, Length - index);
            _array = newArray;
            Length++;
        }

        public void DeleteFromEnd()
        {
            if (Length != 0)
            {
                if (Length == 1)
                {
                    _array[0] = 0;
                    Length--;
                }
                else
                {
                    _array[Length] = 0;
                    Length--;

                    if (Length < _array.Length / 2)
                    {
                        DecreaseLenght();
                    }
                }
            }
        }

        public void DeleteFromBeginning()
        {
            if (Length != 0)
            {
                if (Length == 1)
                {
                    DeleteFromEnd();
                }
                else
                {
                    int[] newArray = new int[_array.Length - 1];
                    Array.Copy(_array, 1, newArray, 0, _array.Length - 1);
                    _array = newArray;
                    Length--;
                }
                if (Length < _array.Length / 2)
                {
                    DecreaseLenght();
                }
            }
        }

        public void DeleteByIndex(int index)
        {
            CheckIndexOutOfRangeException(index);
            if (Length != 0)
            {

                if (Length == 1 || index == Length - 1)
                {
                    DeleteFromEnd();
                    return;
                }
                    if (index == 0)
                    {
                        DeleteFromBeginning();
                    return;
                    }
                int[] newArray = new int[_array.Length - 1];
                        Array.Copy(_array, 0, newArray, 0, index);
                        Array.Copy(_array, index + 1, newArray, index, Length - index);
                        _array = newArray;
                        Length--;
                        if (Length < _array.Length / 2)
                        {
                            DecreaseLenght();
                        }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int b = _array[i];
                _array[i] = _array[Length - 1 - i];
                 _array[Length - 1 - i] = b;
            }
        }

        public int FindMinElement()
        {
            ChekArgumentOutOfRangeException(Length);
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public int FindMaxElement()
        {
            ChekArgumentOutOfRangeException(Length);
            int max = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        public int FindIndexOfMinElement()
        {
            ChekArgumentOutOfRangeException(Length);
            int index = 0;
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public int FindIndexOfMaxElement()
        {
            ChekArgumentOutOfRangeException(Length);
            int index = 0;
            int max = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public void SortInAscendingOrder()
        {
            int temp;
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i] > _array[j])
                    {
                        temp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = temp;
                    }
                }
            }
        }
                     
        public void SortInDescendingOrder()
        {
            int temp;
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length - 1; j++)
                {
                    if (_array[j + 1] > _array[j])
                    {
                        temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }
            }
        }

        public void AddArrayToBeginning (int [] array)
        {
            if (Length>= _array.Length)
            {
                IncreaseLenght();
            }
            int[] newArray = new int[Length + array.Length];
            Array.Copy(array, 0, newArray, 0, array.Length);
            Array.Copy(_array, 0, newArray, array.Length, Length);
            _array = newArray;
            Length += array.Length;
        }

        public void AddArrayToEnd(int[] array)
        {
            if (Length >= _array.Length)
            {
                IncreaseLenght(array.Length);
            }
            int[] newArray = new int[Length + array.Length];
            Array.Copy(_array, 0, newArray, 0, Length);
            Array.Copy(array, 0, newArray, Length , array.Length);
            _array = newArray;
            Length += array.Length;
        }

        public int GetIndexByValue (int value)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    return i;
                }
            }
            return index;
        }
        
        public void DeleteByValueAllElement (int value)
        {
            int count = 0;
            for (int i = 0; i < Length; i++)
            {
                if ( value == _array[i])
                {
                    DeleteByIndex(i);
                    count++;
                    i=-1;
                }
            }
        }

        public void DeleteByValueFirst (int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (value == _array[i])
                {
                    DeleteByIndex(i);
                    break;
                }
            }
        }

        public void AddArrayByIndex (int index, int [] array)
        {
            if (index != 0)
            {
                CheckIndexOutOfRangeException(index - 1);
            }
            if (Length >= _array.Length)
            {
                IncreaseLenght(array.Length);
            }
            int[] newArray = new int[Length + array.Length];
            Array.Copy(_array, 0, newArray, 0, index);
            Array.Copy(array, 0, newArray, index, array.Length);
            Array.Copy(_array, index, newArray, index + array.Length, Length - index);
            _array = newArray;
            Length += array.Length;
        }

        public void DeleteNElementsfromEnd(int n)
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

        public void ChangeByIndex(int value, int index)
        {
            CheckIndexOutOfRangeException(index);
            _array[index] = value;
        }


        private void CheckIndexOutOfRangeException(int index)
        {
            
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

        }

        private void IncreaseLenght (int number = 1)
        {
            int newLenght = _array.Length;
            while ( newLenght < (_array.Length+number))
            {
                newLenght = (int)(newLenght*1.33d + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

        private void DecreaseLenght (int number =1)
        {
            int newLength = _array.Length;
            while (newLength > 2*(Length + number) )
            {
                newLength = newLength * 2 / 3 +1;
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, Length);
            _array = newArray;
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
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (Length != 0)
            {
               for(int i = 0; i<Length; i++)
                {
                    s += _array[i] + ";";
                }
            }
            return s;
        }
    }
}
