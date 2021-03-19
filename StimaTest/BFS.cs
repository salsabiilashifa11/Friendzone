using System;
using System.Collections.Generic;
using StimaTest;

namespace StimaTest
{

    public class BFS
    {
        //Fields
        private IDictionary<Node, bool> visited = new Dictionary<Node, bool>();
        private IDictionary<Node, int> level = new Dictionary<Node, int>();
        private IDictionary<Node, Node> parent = new Dictionary<Node, Node>();
        private List<Node> result = new List<Node>();
        private Queue q = new Queue();
        private Graph g;
        private Node start;

        //Constructors
        public BFS(Graph _g, string _start)
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

        public IDictionary<Node, int> Level
        {
            get { return level; }
            set { level = value; }
        }

        public Node Start
        {
            get { return start; }
            set { start = value; }
        }

        //Methods
        private void Init()
        {
            Node P = g.First;
            while (P != null)
            {
                visited.Add(P, false);
                parent.Add(P, null);
                level.Add(P, -1);
                P = P.Next;
            }
            
        }

        public void RunSearch()
        {
            visited[start] = true;
            level[start] = 0;
            q.Enqueue(start);

            while (!q.IsEmpty())
            {
                Node u = q.Dequeue();
                result.Add(u);

                SuccNode t = u.Trail;
                while (t != null)
                {
                    if (!visited[t.Succ])
                    {
                        visited[t.Succ] = true;
                        parent[t.Succ] = u;
                        level[t.Succ] = level[u] + 1;
                        q.Enqueue(t.Succ);
                        
                    }
                    t = t.NextT;
                }
            }
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
            foreach (KeyValuePair<Node, bool> kvp in visited)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Id, kvp.Value);
            }

        }

        public void PrintLevel()
        {
            foreach (KeyValuePair<Node, int> kvp in level)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key.Id, kvp.Value);
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
