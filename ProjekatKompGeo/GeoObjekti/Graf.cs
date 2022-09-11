using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace ProjekatKompGeo.GeoObjekti
{
    internal class Graf
    {
        public int velicina { get; }
        List<Vektor2D> Node;
        public List<List<Vektor2D>> NeighborList { get; set; }
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
            Node = new List<Vektor2D>( new Vektor2D[velicina] );
            NeighborList = Enumerable.Range(0, velicina).Select(c => new List<Vektor2D>(velicina)).ToList();
        }

        public void AddNode(Vektor2D node)
        {
            Node.Add(node);
            NeighborList.Add(new List<Vektor2D>());
        }

        public void AddEdge(Vektor2D from, Vektor2D to)
        {
            if (from == to)
                return;

            if (Node[from.V] == null)
                Node[from.V] = from;

            if (Node[to.V] == null)
                Node[to.V] = to;

            NeighborList[from.V].Add(to);
            NeighborList[to.V].Add(from);
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

        private Tuple<Vektor2D, Vektor2D> UbaciPocetakKraj(Vektor2D pocetak, Vektor2D kraj, Graphics g, Color color) {
            Vektor2D najkraci = null;
            double najkracaUdaljenost = double.MaxValue;
            Tuple<Vektor2D, Vektor2D> rez = new Tuple<Vektor2D, Vektor2D>(null, null); 

            for (int i = 0; i < velicina; i++)
            {
                if (najkracaUdaljenost > Vektor2D.getUdaljenost(pocetak, Node[i])) {
                    najkracaUdaljenost = Vektor2D.getUdaljenost(pocetak, Node[i]);
                    najkraci = Node[i];
                }
            }
            if (najkraci != null) {
                new Segment(pocetak, najkraci).DrawSegment(g, color);
                rez = Tuple.Create(najkraci, rez.Item2);
            }

            najkraci = null;
            najkracaUdaljenost = int.MaxValue;
            for (int i = 0; i < velicina; i++)
            {
                if (najkracaUdaljenost > Vektor2D.getUdaljenost(Node[i], kraj))
                {
                    najkracaUdaljenost = Vektor2D.getUdaljenost(Node[i], kraj);
                    najkraci = Node[i];
                }
            }

            if (najkraci != null)
            {
                new Segment(najkraci, kraj).DrawSegment(g, color);
                rez = Tuple.Create(rez.Item1, najkraci);
            }

            return rez;
        }

        public void BFS(Vektor2D start, Vektor2D kraj, Graphics g)
        {
            var novo = UbaciPocetakKraj(start, kraj, g, Color.Blue);
            start = novo.Item1;
            kraj = novo.Item2;

            // printGrane();

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

            int trenutni = kraj.V;
            Vektor2D trenutniCvor = kraj;
            while (!trenutni.Equals(start.V))
            {
                path.Add(new Tuple<int, Vektor2D>(trenutni, trenutniCvor));
                trenutni = prethodni[trenutni].Item1;
                trenutniCvor = prethodni[trenutni].Item2;
            };

            path.Add(new Tuple<int, Vektor2D>(start.V, start));
            path.Reverse();

            path.ToList().Take(10).ToList().ForEach(p => Debug.Write(p.Item1 + " "));


            for (int i = 0; i < path.Count - 1; i++)
            {
                // Crtaj
                Segment s = new Segment(Node[path[i].Item1], Node[path[i+1].Item1]);
                s.DrawSegment(g, Color.Blue);
            }
        }


        public void DFS(Vektor2D start, Vektor2D kraj, Graphics g)
        {
            var novo = UbaciPocetakKraj(start, kraj, g, Color.Red);
            start = novo.Item1;
            kraj = novo.Item2;
            
            List<bool> posjeceni = new List<bool>(new bool[velicina]);
            Stack<Vektor2D> stack = new Stack<Vektor2D>();
            stack.Push(start);

            Dictionary<int, Tuple<int, Vektor2D>> prethodni = new Dictionary<int, Tuple<int, Vektor2D>>();

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();
                if (posjeceni[vertex.V])
                    continue;

                posjeceni[vertex.V] = true;
                foreach (Vektor2D neighbor in NeighborList[vertex.V])
                {
                    if (prethodni.ContainsKey(neighbor.V))
                        continue;

                    prethodni[neighbor.V] = new Tuple<int, Vektor2D>(vertex.V, vertex);
                    stack.Push(neighbor);
                }
            }

            var path = new List<Tuple<int, Vektor2D>> { };

            int trenutni = kraj.V;
            Vektor2D trenutniCvor = kraj;
            while (!trenutni.Equals(start.V))
            {
                path.Add(new Tuple<int, Vektor2D>(trenutni, trenutniCvor));
                trenutni = prethodni[trenutni].Item1;
                trenutniCvor = prethodni[trenutni].Item2;
            };

            path.Add(new Tuple<int, Vektor2D>(start.V, start));
            path.Reverse();

            path.ToList().ForEach(p => Debug.Write(p.Item1 + " "));
            for (int i = 0; i < path.Count - 1; i++)
            {
                // Crtaj
                Segment s = new Segment(Node[path[i].Item1], Node[path[i + 1].Item1]);
                s.DrawSegment(g, Color.Red);
            }

        }

        public void DJIKSTRA(Vektor2D start, Vektor2D kraj, Graphics g) {
            var novo = UbaciPocetakKraj(start, kraj, g, Color.Green);
            start = novo.Item1;
            kraj = novo.Item2;
            int startV = start.V;
            int krajV = kraj.V;
            int[] dist = new int[velicina];
            int[] prethodni = new int[velicina];

            for (int i = 0; i < velicina; i++)
            {
                dist[i] = int.MaxValue;
                prethodni[i] = -1;
            }

            dist[startV] = 0;
            List<int> Q = new List<int>();
            Q.Add(startV);

            while (Q.Count > 0)
            {
                int u = Q[0];
                Q.RemoveAt(0);
                foreach (Vektor2D v in NeighborList[u])
                {
                    if (dist[v.V] > dist[u] + Vektor2D.getUdaljenost(Node[u], Node[v.V]))
                    {
                        dist[v.V] = dist[u] + (int)Vektor2D.getUdaljenost(Node[u], Node[v.V]);
                        prethodni[v.V] = u;
                        if (!Q.Contains(v.V))
                            Q.Add(v.V);
                    }
                }
            }
            // Print
            List<int> path = new List<int>();
            int trenutni = krajV;
            while (!trenutni.Equals(startV))
            {
                path.Add(trenutni);
                trenutni = prethodni[trenutni];
            }
            path.Add(startV);
            path.Reverse();
           // path.ForEach(p => Debug.Write(p + " "));
            for (int i = 0; i < path.Count - 1; i++)
            {
                // Crtaj
                Segment s = new Segment(Node[path[i]], Node[path[i + 1]]);
                s.DrawSegment(g, Color.Green);
            }

        }

        public void A_STAR(Vektor2D start, Vektor2D kraj, Graphics gr)
        {
            var novo = UbaciPocetakKraj(start, kraj, gr, Color.Black);
            start = novo.Item1;
            kraj = novo.Item2;


            List<int> otvorenaLista = new List<int>();
            List<int> zatvorenaLista = new List<int>();
            int[] prethodni = new int[velicina];

            otvorenaLista.Add(start.V);
            int[] f = new int[velicina];
            int[] g = new int[velicina];
            int[] h = new int[velicina];

            for (int i = 0; i < velicina; i++)
            {
                f[i] = int.MaxValue;
                g[i] = int.MaxValue;
                h[i] = int.MaxValue;
                prethodni[i] = -1;
            }

            g[start.V] = 0;
            h[start.V] = (int)Vektor2D.getUdaljenost(start, kraj);
            f[start.V] = g[start.V] + h[start.V];

            while (otvorenaLista.Count > 0)
            {
                int min = int.MaxValue;
                int minIndex = -1;
                for (int i = 0; i < otvorenaLista.Count; i++)
                {
                    if (f[otvorenaLista[i]] < min)
                    {
                        min = f[otvorenaLista[i]];
                        minIndex = i;
                    }
                }

                int trenutni = otvorenaLista[minIndex];
                otvorenaLista.RemoveAt(minIndex);
                zatvorenaLista.Add(trenutni);

                if (trenutni == kraj.V)
                {
                    // Print
                    List<int> path = new List<int>();
                    int trenutniCvor = kraj.V;
                    while (!trenutniCvor.Equals(start.V))
                    {
                        path.Add(trenutniCvor);
                        trenutniCvor = prethodni[trenutniCvor];
                    }
                    path.Add(start.V);
                    path.Reverse();
                    //path.ForEach(p => Debug.Write(p + " "));
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        // Crtanje
                        Segment s = new Segment(Node[path[i]], Node[path[i + 1]]);
                        s.DrawSegment(gr, Color.Black);
                    }
                    return;
                }

                foreach (Vektor2D susjed in NeighborList[trenutni])
                {
                    if (zatvorenaLista.Contains(susjed.V))
                        continue;

                    int tempG = g[trenutni] + (int)Vektor2D.getUdaljenost(Node[trenutni], Node[susjed.V]);
                    if (!otvorenaLista.Contains(susjed.V))
                        otvorenaLista.Add(susjed.V);
                    else if (tempG >= g[susjed.V])
                        continue;

                    prethodni[susjed.V] = trenutni;
                    g[susjed.V] = tempG;
                    h[susjed.V] = (int)Vektor2D.getUdaljenost(Node[susjed.V], kraj);
                    f[susjed.V] = g[susjed.V] + h[susjed.V];
                }
            }
        }
    }
}
