using System;
using System.Collections.Generic;

namespace Task10
{
    public class Graph
    {
        public LinkedList Vertexes { get; set; }

        public Graph()
        {
            this.Vertexes = new LinkedList();
        }

        public Graph(int[,] adjacencyMatr, int[] values)
        {
            this.Vertexes = new LinkedList();
            for (int i = 0; i < adjacencyMatr.GetLength(0); i++)
            {
                var newVertex = new Vertex(i, values[i]);
                this.Vertexes.Add(newVertex);
            }
            
            for (int i = 0; i < adjacencyMatr.GetLength(0); i++)
            {
                for (int j = i; j < adjacencyMatr.GetLength(1); j++)
                {
                    if (adjacencyMatr[i, j] == 1)
                    {
                        this.Vertexes[j].AdjacentVerts.Add(this.Vertexes[i]);
                        this.Vertexes[i].AdjacentVerts.Add(this.Vertexes[j]);

                    }
                }
            }
        }
        

        public void RemoveVertexes(int value)
        {
            foreach (var currentVertex in this.Vertexes)
            {
                if (currentVertex.Value == value)
                {
                    foreach (var adjacentVertex in currentVertex.AdjacentVerts)
                    {
                        adjacentVertex.AdjacentVerts.Remove(currentVertex);
                    }

                    this.Vertexes.Remove(currentVertex);
                }
            }
        }

        public void Show()
        {
            foreach (var vertex in Vertexes)
            {
                Console.WriteLine(vertex);
            }
        }
    }
}