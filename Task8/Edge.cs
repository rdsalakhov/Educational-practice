namespace Task8
{
    public class Edge
    {
        public Node StartNode { get; set; }
        
        public Node EndNode { get; set; }
        
        public int Index { get; set; }

        public Edge(Node startNode, Node endNode, int index)
        {
            this.EndNode = endNode;
            this.StartNode = startNode;
            this.Index = index;
        }

        public override bool Equals(object obj)
        {
            Edge e = obj as Edge;
            bool equal = this.Index == e.Index && this.StartNode == e.StartNode && this.EndNode == e.EndNode;
            return equal;
        }
    }
}