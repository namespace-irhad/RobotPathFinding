using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatKompGeo.GeoObjekti
{
    internal class Graf
    {
        public int velicina { get; }
        List<Vektor2D> Node;
        List<List<Vektor2D>> NeighborList;
        // Helper za trapez. dekompoziciju
        public List<Vektor2D> SortiraneTackePuteva { get; set; }

        public Graf()
        {
            velicina = 0;
            Node = new List<Vektor2D>();
            NeighborList = new List<List<Vektor2D>>();
        }
        public Graf(int velicina)
        {
            this.velicina = velicina;
            Node = new List<Vektor2D>(velicina);
            NeighborList = Enumerable.Range(0, velicina).Select(c => new List<Vektor2D>(velicina)).ToList();
        }

        public void AddEdge(Vektor2D from, Vektor2D to)
        {
            if (from == to)
                return;

            if (!Node.Contains(from))
                Node.Add(from);

            NeighborList[from.V].Add(to);
            // NeighborList[to.V].Add(from);
        }
        public bool HasEdge(Vektor2D from, Vektor2D to)
        {
            return NeighborList[from.V].Any(val => val.V == to.V);
        }
        public List<Vektor2D> Neighbors(Vektor2D node)
        {
            return NeighborList[node.V];
        }
        public void printGrane()
        {
            for (int i = 0; i < NeighborList.Count; i++)
            {
                Debug.WriteLine("Cvor " + i + ": ");
                for (int j = 0; j < NeighborList[i].Count; j++)
                {
                    Debug.Write(NeighborList[i][j].V + ", ");
                }
                Debug.WriteLine("");
            }
        }

        public List<int> BFS(Vektor2D start, Vektor2D kraj, Graphics g)
        {
            Dictionary<int, Tuple<int, Vektor2D>> prethodni = new Dictionary<int, Tuple<int, Vektor2D>>();

            Queue<Vektor2D> queue = new Queue<Vektor2D>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (Vektor2D neighbor in NeighborList[vertex.V])
                {
                    if (prethodni.ContainsKey(neighbor.V))
                        continue;

                    prethodni[neighbor.V] = new Tuple<int, Vektor2D>(vertex.V, vertex);
                    queue.Enqueue(neighbor);
                }
            }

            var path = new List<Tuple<int, Vektor2D>> { };

            var current = kraj.V;
            while (!current.Equals(start.V))
            {
                path.Add(new Tuple<int, Vektor2D>(current, prethodni[current].Item2));
                current = prethodni[current].Item1;
            };

            path.Add(new Tuple<int, Vektor2D>(start.V, start));
            path.Reverse();


            for (int i = 0; i < path.Count - 1; i++)
            {
                // Draw line
                Segment s = new Segment(path[i].Item2, path[i + 1].Item2);
                s.DrawSegment(g, Color.Red);
            }
            return new List<int> { };
        }

        public List<int> DFS(Vektor2D start, Vektor2D kraj, Graphics g)
        {
            if (start.V == kraj.V)
                return new List<int> { start.V };

            List<bool> visited = new List<bool>(velicina);
            for (int i = 0; i < velicina; i++)
                visited.Add(false);

            Stack<int> stack = new Stack<int>();
            stack.Push(start.V);

            List<Tuple<int, Vektor2D>> path = new List<Tuple<int, Vektor2D>> { };

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                visited[vertex] = true;
                path.Add(new Tuple<int, Vektor2D>(vertex, Node[vertex]));

                foreach (Vektor2D neighbor in NeighborList[vertex])
                {
                    if (neighbor.V == kraj.V)
                    {
                        path.Add(new Tuple<int, Vektor2D>(neighbor.V, neighbor));
                        path.Add(new Tuple<int, Vektor2D>(vertex, Node[vertex]));
                        return new List<int> { };
                    }

                    if (!visited[neighbor.V])
                        stack.Push(neighbor.V);
                }

            }

            for (int i = 0; i < path.Count - 1; i++)
            {
                // Draw line
                Segment s = new Segment(path[i].Item2, path[i + 1].Item2);
                s.DrawSegment(g, Color.Red);
            }

            return new List<int> { };
        }

    }
}
