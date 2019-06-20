namespace Task10
{
    public class ListNode
    {
        public Vertex Value { get; set; }

        public ListNode Next { get; set; }

        public ListNode(Vertex value, ListNode next)
        {
            this.Value = value;
            this.Next = next;
        }


    }
}