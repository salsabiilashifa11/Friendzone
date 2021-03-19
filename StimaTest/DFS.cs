using System;
using System.Collections.Generic;
using StimaTest;

namespace StimaTest

{
    public class DFS
    {
        //Fields
        private IDictionary<Node, int> visited = new Dictionary<Node, int>();
        private IDictionary<Node, int[]> interval = new Dictionary<Node, int[]>();
        private IDictionary<Node, Node> parent = new Dictionary<Node, Node>();
        private List<Node> result = new List<Node>();
        private Queue q = new Queue();
        private Graph g;
        private Node start;
        private int time = 0;

        //Constructors
        public DFS(Graph _g, string _start)
        {
            g = _g;
            start = g.SearchNode(_start);
            Init();
        }

        //Getter and Setter
        public Graph G
        {
            get { return g; }
            set { g = value; }
        }

        public IDictionary<Node, int[]> Level
        {
            get { return interval; }
            set { interval = value; }
        }

        public Node Start
        {
            get { return start; }
            set { start = value; }
        }

        //Methods
        //Note: W = 0, G = 1, B = 2
        private void Init()
        {
            Node P = g.First;
            while (P != null)
            {
                int[] temp = new int[2] { -1, -1 };
                visited.Add(P, 0);
                parent.Add(P, null);
                interval.Add(P, temp);
                P = P.Next;
            }

        }

        public void RunSearch()
        {
            DFSRecc(start);
        }

        private void DFSRecc(Node P)
        {
            visited[P] = 1;
            interval[P][0] = time;
            result.Add(P);
            time += 1;

            SuccNode T = P.Trail;
            while (T != null)
            {
                if (visited[T.Succ] == 0)
                {
                    parent[T.Succ] = P;
                    DFSRecc(T.Succ);
                }
                T = T.NextT;
            }
            visited[P] = 2;
            interval[P][1] = time;
            time += 1;
        }

        public List<Node> GetPath(string end)
        {
            List<Node> path = new List<Node>();
            Node v = g.SearchNode(end);
            while (v != null)
            {
                path.Add(v);
                v = parent[v];
                //path.Reverse();
            }
            return path;
        }


        //DEBUG
        public void PrintPath(List<Node> path)
        {
            foreach (Node n in path)
            {
                Console.Write("{0} ", n.Id);
            }
            Console.WriteLine();
        }

        public void PrintVisited()
        {
            foreach (KeyValuePair<Node, int> kvp in visited)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Id, kvp.Value);
            }
        }

        public void PrintInterval()
        {
            foreach (KeyValuePair<Node, int[]> kvp in interval)
            {
                Console.WriteLine("Key: {0}, Value: [{1}]", kvp.Key.Id, string.Join(", ", kvp.Value));
            }
        }



        public void PrintParent()
        {
            foreach (KeyValuePair<Node, Node> kvp in parent)
            {
                if (kvp.Value == null)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Id, kvp.Value);
                }
                else
                {
                    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Id, kvp.Value.Id);
                }

            }

        }

        public void PrintResult()
        {
            foreach (Node node in result)
            {
                Console.Write("{0} ", node.Id);

            }
            Console.WriteLine();
        }

    }
}
