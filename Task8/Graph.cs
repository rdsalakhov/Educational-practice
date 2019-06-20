using System.Collections.Generic;

namespace Task8
{
    public class Graph
    {
        readonly  List<Edge> _edges;

        readonly List<Node> _nodes;
        
        public Graph(List<Edge> edges, List<Node> nodes)
        {
            this._edges = edges;
            this._nodes = nodes;
        }

        public Graph(int[,] incidenceMatrix)
        {
            var g = CreateFromIncidenceMatrix(incidenceMatrix);
            this._edges = g._edges;
            this._nodes = g._nodes;
        }

        private static Graph CreateFromIncidenceMatrix(int[,] incidenceMatrix)
        {
            var nodes = new List<Node>();
            var edges = new List<Edge>();
            
            for (int j = 0; j < incidenceMatrix.GetLength(1); j++)
            {
                edges.Add(new Edge(null, null, j));
            }
            for (int i = 0; i < incidenceMatrix.GetLength(0); i++)
            {
                nodes.Add(new Node(i, new List<Edge>()));
            }
            for (int j = 0; j < incidenceMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < incidenceMatrix.GetLength(0); i++)
                {
                    if (incidenceMatrix[i, j] == 1)
                    {
                        if (edges[j].StartNode == null)
                        {
                            edges[j].StartNode = nodes[i];
                        }
                        else
                        {
                            edges[j].EndNode = nodes[i];
                        }
                        nodes[i].Edges.Add(edges[j]);
                    }
                }
            }

            foreach (var node in nodes)
            {
                node.FillAdjacentNodes();
            }
            return new Graph(edges, nodes);
        }

        private void DFSForCycles(Node firstNode, Node currentNode, Node prevNode, Cycle cycle, List<Cycle> cycles)
        {
            var tempCycle = new Cycle(cycle);
            if (currentNode.Equals(firstNode) && tempCycle.Count != 0)
            {
                if (!tempCycle.IsContainedIn(cycles))
                {
                    tempCycle.Reverse();
                    if (!tempCycle.IsContainedIn(cycles))
                    {
                        tempCycle.Reverse();
                        cycles.Add(tempCycle);
                    }
                }
            }
            else if (currentNode.Color != 1)
            {
                currentNode.Color = 1;
                tempCycle.Add(currentNode);
                foreach (var node in currentNode.AdjacentNodes)
                {
                    this.ResetColors(tempCycle);
                    if (!node.Equals( prevNode) && !node.Equals(currentNode))
                    {
                        DFSForCycles(firstNode, node, currentNode, tempCycle, cycles);
                    }
                }
            }
        }

        public List<Cycle> Cycles()
        {
            var cycles = new List<Cycle>();
            foreach (var node in this._nodes)
            {
                this.DFSForCycles(node, node, null, new Cycle(), cycles);
                this.ResetColors();
            }

            return cycles;
        }

        public void ResetColors()
        {
            foreach (var node in this._nodes)
            {
                node.Color = 0;
            }
        }

        public void ResetColors(List<Node> exeptionalNodes)
        {
            foreach (var node in this._nodes)
            {
                if (!exeptionalNodes.Contains(node))
                {
                    node.Color = 0;
                }
            }
        }
    }
}