using NUnit.Framework;
using DataStructures;
using System;

namespace DataStructuresTest
{
    public class ArrayListTest
    {
        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        [TestCase(4, new int[] { }, new int[] { 4 })]
        [TestCase(4, new int[] { 1 }, new int[] { 4, 1 })]
        public void AddToBeginningTest(int value, int [] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList (expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.AddToBeginning(value);
            Assert.AreEqual(expected, actual);

        }
               
        [TestCase(3, new int[] { 1, 2, 3, 4 }, 2)]
        [TestCase(4, new int[] { }, -1)]
        [TestCase(1, new int[] { 1, 1, 1 }, 0)]
        public void GetIndexByValueTest(int value, int[] array, int expected)
        {
            ArrayList newArray = new ArrayList(array);
            int actual = newArray.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { }, new int[] { 4 })]
        [TestCase(4, new int[] { 1 }, new int[] { 1, 4 })]
        public void AddToEndTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.AddToEnd(value);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(1, 4, new int[] { 1, 2, 3 }, new int[] { 1, 4, 2, 3 })]
        [TestCase(0, 4, new int[] { 1, 2, 3 }, new int[] { 4, 1, 2, 3 })]
        [TestCase(3, 4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, 4, new int[] { }, new int[] { 4 })]
        [TestCase(0, 4, new int[] { 1 }, new int[] { 4, 1 })]
        public void AddByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.AddByIndex(value, index);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(44, 6, new int[] { 1, 2, 3, 4 })]
        [TestCase(-3, 6, new int[] { 1, 2, 3, 4})]
        [TestCase(4, 6, new int[] { })]
        public void AddByIndexNegativeTest(int index, int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DeleteFromEndTest( int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteFromEnd();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void DeleteFromBeginningTest(int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteFromBeginning();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4 })]
        [TestCase(3, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1 }, new int[] { })]
        public void DeleteByIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(44, new int[] { 1, 2, 3, 4 })]
        [TestCase(-3, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { })]
        public void DeleteByIndexNegativeTest(int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index));
        }


        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 11, 22, 33, 4 }, 4)]
        [TestCase(new int[] { -34, 45, 576, -4567, 5678 }, -4567)]
        [TestCase(new int[] { 1, 1, 1, 1 }, 1)]
        public void FindMinElementTest(int[] array, int expected)
        { 
            ArrayList newArray = new ArrayList(array);
            int actual = newArray.FindMinElement();
            Assert.AreEqual(expected, actual);

        }

        [TestCase( new int[] { })]
        public void FindMinElementNegativeTest( int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<ArgumentOutOfRangeException>(() => actual.FindMinElement());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 111, 22, 33, 4 }, 111)]
        [TestCase(new int[] { -34, 45, 576, -4567, -5678 }, 576)]
        [TestCase(new int[] { 1, 1, 1, 1 }, 1)]
        public void FindMaxElementTest(int[] array, int expected)
        {
            ArrayList newArray = new ArrayList(array);
            int actual = newArray.FindMaxElement();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void FindMaxElementNegativeTest(int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<ArgumentOutOfRangeException>(() => actual.FindMaxElement());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 111, 22, 33, 4 }, 3)]
        [TestCase(new int[] { -34, 45, 576, -4567, 5678 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 1 }, 0)]
        public void FindIndexOfMinElementTest(int[] array, int expected)
        {
            ArrayList newArray = new ArrayList(array);
            int actual = newArray.FindIndexOfMinElement();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void FindIndexOfMinElementNegativeTest(int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<ArgumentOutOfRangeException>(() => actual.FindIndexOfMinElement());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 111, 22, 33, 4 }, 0)]
        [TestCase(new int[] { -34, 45, 576, -4567, -5678 }, 2)]
        [TestCase(new int[] { 1, 1, 1, 1 }, 0)]
        public void FindIndexOfMaxElementTest(int[] array, int expected)
        {

            ArrayList newArray = new ArrayList(array);
            int actual = newArray.FindIndexOfMaxElement();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void FindIndexOfMaxElementNegativeTest(int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<ArgumentOutOfRangeException>(() => actual.FindIndexOfMaxElement());
        }

        [TestCase(new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 1, 4, 4, 4, 5, 6 })]
        [TestCase(new int[] { 3, 4, 4, 6, 8 }, new int[] { 3, 4, 4, 6, 8 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortInAscendingOrderTest(int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.SortInAscendingOrder();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 6, 5, 4, 4, 4, 1 })]
        [TestCase(new int[] { 8, 6, 4, 4, 3 }, new int[] { 8, 6, 4, 4, 3 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortInDescendingOrderTest(int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.SortInDescendingOrder();
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 1, 5, 6 }, new int[] { 1, 5, 6, 4, 1, 4, 5, 6, 4 })]
        [TestCase(new int[] { 3, 4, 4, 6, 8 }, new int[] { }, new int[] { 3, 4, 4, 6, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1 }, new int[] { 1, 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1 }, new int[] { 1, 1 })]
        public void AddArrayToBeginningTest(int[] array1, int [] array2, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array1);
            actual.AddArrayToBeginning(array2);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 1, 5, 6 }, new int[] { 4, 1, 4, 5, 6, 4, 1, 5, 6 })]
        [TestCase(new int[] { 3, 4, 4, 6, 8 }, new int[] { }, new int[] { 3, 4, 4, 6, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1 }, new int[] { 1, 2, 3, 4, 1 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1 }, new int[] { 1, 1 })]
        public void AddArrayToEndTest(int[] array1, int [] array2, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array1);
            actual.AddArrayToEnd(array2);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(2, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 1, 5, 6 }, new int[] { 4, 1, 1, 5, 6, 4, 5, 6, 4 })]
        [TestCase(0, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 1, 5, 6 }, new int[] { 1, 5, 6, 4, 1, 4, 5, 6, 4 })]
        [TestCase(6, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 1, 5, 6 }, new int[] { 4, 1, 4, 5, 6, 4, 1, 5, 6 })]
        [TestCase(5, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 1, 5, 6 }, new int[] { 4, 1, 4, 5, 6, 1, 5, 6, 4 })]
        [TestCase(3, new int[] { 3, 4, 4, 6, 8 }, new int[] { }, new int[] { 3, 4, 4, 6, 8 })]
        [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 1 }, new int[] { 1, 2, 1, 3, 4 })]
        [TestCase(0, new int[] { }, new int[] { }, new int[] { })]
        [TestCase(0, new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, new int[] { 1 }, new int[] { 1 }, new int[] { 1, 1 })]
        public void AddArrayByIndexTest(int index, int[] array1, int[] array2, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array1);
            actual.AddArrayByIndex(index, array2);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(44, new int[] { 1, 2 })]
        [TestCase( -3, new int[] { 1, 2, 3, 4 })]
        public void AddArrayByIndexNegativeTest( int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddArrayByIndex(index, array));
        }

        [TestCase(7, new int[] { }, new int[] { })]
        [TestCase(7, new int[] { 7, 7, 7 }, new int[] { })]
        [TestCase(7, new int[] { 0, 7, 7, 0, 7 }, new int[] { 0, 0 })]
        [TestCase(1, new int[] { 1, 0, 1, 4, 1, 6 }, new int[] { 0, 4, 6 })]
        public void DeleteByValueAllElementsTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByValueAllElement(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4 })]
        [TestCase(4, new int[] { }, new int[] { })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(1, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(77, new int[] { 1, 9, 3, 2 }, new int[] { 1, 9, 3, 2 })]
        public void DeleteByValueFirstTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByValueFirst(value);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(2, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4, 1, 4, 5, })]
        [TestCase(0, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4, 1, 4, 5, 6, 4 })]
        [TestCase(6, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { })]
        [TestCase(5, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4 })]
        [TestCase(2, new int[] { }, new int[] { })]
        [TestCase(0, new int[] { }, new int[] { })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        public void DeleteNElementsFromEndTest(int n, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteNElementsfromEnd(n);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(2, 3, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4, 1, 4, 4 })]
        [TestCase(2, 0, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4, 5, 6, 4 })]
        [TestCase(0, 2, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4, 1, 4, 5, 6, 4 })]
        [TestCase(5, 1, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4 })]
        [TestCase(1, 0, new int[] { 1 }, new int[] { })]
        [TestCase(0, 0, new int[] { }, new int[] { })]
        public void DeleteNElementsByIndexTest(int n, int index, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.DeleteNElementsByIndex(n, index);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(44, 3, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, -3, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, 4, new int[] { 1, 3})]
        [TestCase(6, 2, new int[] { 4, 1, 4, 5, 6, 4 })]
        public void DeleteNElementsByIndexNegativeTest(int n, int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteNElementsByIndex(n, index));
        }

        [TestCase(2, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4, 5, 6, 4 })]
        [TestCase(0, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4, 1, 4, 5, 6, 4 })]
        [TestCase(6, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { })]
        [TestCase(5, new int[] { 4, 1, 4, 5, 6, 4 }, new int[] { 4 })]
        [TestCase(2, new int[] { }, new int[] { })]
        [TestCase(0, new int[] { }, new int[] { })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        public void DeleteNElementsFromBeginningTest(int n, int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);

            actual.DeleteNElementsFromBeginning(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 7, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 7, 4 })]
        [TestCase(0, 7, new int[] { 1, 2, 3, 4 }, new int[] { 7, 2, 3, 4 })]
        [TestCase(3, 7, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 7 })]
        [TestCase(0, 7, new int[] { 1 }, new int[] { 7 })]
        public void ChangeByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(array);
            actual.ChangeByIndex(value, index);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(44, 6, new int[] { 1, 2, 3, 4 })]
        [TestCase(-3, 6, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, 6, new int[] { })]
        public void ChangeByIndexNegativeTest(int index, int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual[index] = value);
        }






    }
}