using System.Collections.Generic;

namespace Task8
{
    public class Node
    {
        public int Color { get; set; }
        
        public int Index { get; set; }
        
        public List<Edge> Edges { get; set; }
        
        public List<Node> AdjacentNodes { get; set; }

        public Node(int index, List<Edge> edges)
        {
            this.Index = index;
            this.Edges = edges;
            this.Color = 0;
            edges = new List<Edge>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Node n = obj as Node;
            var equal = this.Index == n.Index && this.Edges == n.Edges;
            return equal;
        }

        public void FillAdjacentNodes()
        {
            this.AdjacentNodes = new List<Node>();
            foreach (var edge in this.Edges)
            {
                if (!this.Equals((edge.StartNode)))
                {
                    this.AdjacentNodes.Add(edge.StartNode);
                }
                else
                {
                    this.AdjacentNodes.Add((edge.EndNode));
                }
            }
        }

        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
}