namespace Task9
{
    public class ListNode
    {
        public int Value { get; set; }
        
        public ListNode Next { get; set; }

        public ListNode(int value)
        {
            this.Value = value;
            this.Next = null;
        }

        public ListNode(int value, ListNode next)
        {
            this.Next = next;
            this.Value = value;
        }
    }
}