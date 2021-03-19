using System;
using System.Collections.Generic;
using System.Linq;
using StimaTest;

namespace StimaTest
{
    public class FriendRec
    {
        //Fields
        Graph g;
        string start;
        private IDictionary<Node, List<Node>> result = new Dictionary<Node, List<Node>>();

        //Constructors
        public FriendRec(Graph _g, string _s)
        {
            g = _g;
            start = _s;
        }

        //Getter and Setter
        public Graph G
        {
            get { return g; }
            set { g = value; }
        }

        public IDictionary<Node, List<Node>> Result
        {
            get { return result; }
            set { result = value; }
        }

        //Methods
        public void FriendRecRun()
        {
            BFS bfs = new BFS(g, start);

            //BFS - Mencari shortest distance masing-masing akun
            bfs.RunSearch();
            foreach (KeyValuePair<Node, int> kvp in bfs.Level)
            {
                List<Node> mutualFriends = new List<Node>();

                //Isolasi yang jarak terpendeknya = 2
                if (kvp.Value == 2)
                {
                    Node P = bfs.Start;
                    SuccNode T = P.Trail;

                    //DFS - Mencari mutual friend
                    while (T != null)
                    {
                        Node PSucc = T.Succ;
                        SuccNode TSucc = PSucc.Trail;
                        bool found = false;

                        while (TSucc != null && !found) {
                            if (TSucc.Succ.Id == kvp.Key.Id)
                            {
                                mutualFriends.Add(PSucc);
                                found = true;
                            }
                            TSucc = TSucc.NextT;
                        }
                        T = T.NextT;
                    }
                    result.Add(kvp.Key, mutualFriends);
                }
            }

            //Urutin hasil dari yang paling banyak mutual friend
            result = result.OrderByDescending(x => x.Value.Count).ToDictionary
                (x => x.Key, x => x.Value);

        }

        //DEBUG
        public void PrintResult()
        {
            FriendRecRun();
            Console.WriteLine("Daftar rekomendasi teman untuk akun {0}: ", start);
            foreach (KeyValuePair<Node, List<Node>> kvp in result)
            {
                Console.WriteLine("Nama akun: {0}", kvp.Key.Id);
                Console.WriteLine("{0} mutual friends: ", kvp.Value.Count);
                foreach (Node mutual in kvp.Value)
                {
                    Console.WriteLine("{0}", mutual.Id);
                }
                Console.WriteLine();
            }
        }
    }
}
