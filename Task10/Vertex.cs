using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Task10
{
    public class Vertex
    {
        public int Value {get; set;}
        
        public int Index { get; set; }
        
        
        public LinkedList AdjacentVerts { get; set; }

        public Vertex(int index, int value)
        {
            this.Index = index;
            this.Value = value;
            this.AdjacentVerts = new LinkedList();
        }

        public override string ToString()
        {
            return $"Value: {Value}; Index: {Index}; Links: {AdjacentVerts.Count()}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vertex))
            {
                return false;
            }

            var vertex = obj as Vertex;
            return this.Index == vertex.Index && this.Value == vertex.Value;
        }
    }
}