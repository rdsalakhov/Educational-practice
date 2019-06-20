using System;

namespace Task9
{
    public class LinkedList
    {
        public ListNode FirstNode { get; set;}

        public LinkedList(int quantity)
        {
            this.FirstNode = new ListNode(1);
            RecursiveCreation(quantity, 2, FirstNode);
        }

        private static void RecursiveCreation(int quantity, int currentStep, ListNode prevNode)
        {
            if (quantity + 1 == currentStep)
                return;
            var newNode = new ListNode(currentStep);
            prevNode.Next = newNode;
            RecursiveCreation(quantity, currentStep + 1, newNode);
        }

        public void Show()
        {
            var current = FirstNode; 
            while (current != null )
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}