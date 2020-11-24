using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
   public interface IList
    {
        int Length { get; }

        void AddToEnd(int value);

        void AddToBeginning(int value);

        void AddByIndex(int value, int index);

        void DeleteFromEnd();
        
        void DeleteFromBeginning();

        void DeleteByIndex(int index);

        void Reverse();

        int FindMinElement();

        int FindMaxElement();

        int FindIndexOfMinElement();

        int FindIndexOfMaxElement();

        void SortInAscendingOrder();

        void SortInDescendingOrder();

        void AddArrayToBeginning(int[] array);

        void AddArrayToEnd(int[] array);

        int GetIndexByValue(int value);

        void DeleteByValueAllElement(int value);

        void DeleteByValueFirst(int value);

        void AddArrayByIndex(int index, int[] array);

        void DeleteNElementsfromEnd(int n);
    
        void DeleteNElementsFromBeginning(int n);

        void DeleteNElementsByIndex(int n, int index);

        void ChangeByIndex(int value, int index);
    }
}
