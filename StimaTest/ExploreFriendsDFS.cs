using System;
using StimaTest;
using System.Collections.Generic;

namespace StimaTest
{
    public class ExploreFriendsDFS
    {
        public List<string> SolverDFS(string X, string Y, Graph G)
        {
            Node start = G.SearchNode(X); //mencari node yang id-nya = X
            Node finish = G.SearchNode(Y);
            Stack dfsStack = new Stack(); //Stack untuk DFS
            bool friendFound = false;
            List<string> jalurPertemanan = new List<string>(); //return value
            List<string> adjId = new List<string>(); // list untuk menyimpan id dari adjacent node
            List<Node> allVisitedNode = new List<Node>(); // list untuk menyimpan semua node yang pernah dikunjungi


            if (start != null && finish != null) //Pastikan yang dicari ada di dalam graph
            {
                dfsStack.Push(start); //Tambahkan node pertama ke Stack

                while (!(dfsStack.IsEmpty()) && !friendFound)
                {
                    Node Visit = dfsStack.InfoTop; //Node yang sedang dikunjungi
                    dfsStack.Pop(); //Pop Node yang akan dikunjungi
                    if (!(Visit.visited))
                    {
                        jalurPertemanan.Add(Visit.Id);
                        allVisitedNode.Add(Visit);
                        Visit.visited = true;
                    }
                    if (Visit.Id == finish.Id)
                    {
                        friendFound = true;
                    }

                    SuccNode adjacent = Visit.Trail;
                    while (adjacent != null)
                    {
                        adjId.Add(adjacent.Succ.Id);
                        adjacent = adjacent.NextT;
                    }

                    adjId.Sort();
                    adjId.Reverse();
                    foreach(string adj in adjId)
                    {
                        Node NextVisit = G.SearchNode(adj);
                        if (!(NextVisit.visited))
                        {
                            dfsStack.Push(NextVisit);
                        }
                    }
                }
                //Reset bool visited = false
                foreach(Node visitedNode in allVisitedNode)
                {
                    visitedNode.visited = false;
                }
            }
            if (friendFound) { return jalurPertemanan; }
            else { return null; }
        }
    }
}