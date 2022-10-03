using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private class ListNode
        {
            public ListNode(T element)
            {
                Node = element;
            }

            public T Node { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }
        }

        private ListNode Head { get; set; }

        private ListNode Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(T element)
        {
            Count++;
            if (Head == null)
            {
                Head = new ListNode(element);
                Tail = Head;
                return;
            }

            ListNode OldHead = Head;
            Head = new ListNode(element);
            OldHead.PreviousNode = Head;
            Head.NextNode = OldHead;
        }

        public void AddLast(T element)
        {
            Count++;
            if (Tail == null)
            {
                Tail = new ListNode(element);
                Head = Tail;
                return;
            }

            ListNode OldTail = Tail;
            Tail = new ListNode(element);
            OldTail.NextNode = Tail;
            Tail.PreviousNode = OldTail;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            ListNode CurrHead = Head;
            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.NextNode;
                Head.PreviousNode = null;
            }
            Count--;
            return CurrHead.Node;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            ListNode CurrTail = Tail;
            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.PreviousNode;
                Tail.NextNode = null;
            }
            Count--;
            return CurrTail.Node;
        }

        public void ForEach(Action<T> action)
        {
            ListNode currNode = Head;
            while (currNode != null)
            {
                action(currNode.Node);
                currNode = currNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];
            ListNode currNode = Head;
            for (int i = 0; i < Count; i++)
            {
                result[i] = currNode.Node;
                currNode = currNode.NextNode;
            }

            return result;
        }
    }
}
