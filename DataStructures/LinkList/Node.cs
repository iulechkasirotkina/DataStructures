using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkList
{
    public class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

        public Node Prev { get; set; }

        public Node()
        {
            Next = null;
            Prev = null;
        }

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
       
    }
}
