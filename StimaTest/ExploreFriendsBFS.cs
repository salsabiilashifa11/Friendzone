using System;
using StimaTest;
using System.Collections.Generic;

namespace StimaTest
{
    public class ExploreFriendsBFS
    {
        public List<string> SolverBFS(string X, string Y, Graph G)
        {
            Node start = G.SearchNode(X); //mencari node yang id-nya = X
            Node finish = G.SearchNode(Y);
            Queue bfsQueue = new Queue(); //Queue untuk BFS
            bool friendFound = false;
            List<string> jalurPertemanan = new List<string>(); //return value
            List<string> adjId = new List<string>(); // list untuk menyimpan id adjacent node dari sebuah node
            List<Node> allVisitedNode = new List<Node>(); // list untuk menyimpan semua node yang pernah dikunjungi
            

            if (start != null && finish != null) //Pastikan yang dicari ada di dalam graph
            {
                jalurPertemanan.Add(start.Id);

                start.visited = true; //Tandai node yang sudah dikunjungi
                allVisitedNode.Add(start);

                bfsQueue.Enqueue(start); //Tambahkan node pertama ke Queue

                while (!(bfsQueue.IsEmpty()) && !friendFound)
                {
                    Node Visit = bfsQueue.InfoHead; //Node yang sedang dikunjungi
                    bfsQueue.Dequeue();//Dequeue Node yang dikunjungi

                    SuccNode adjacent = Visit.Trail;
                    while(adjacent != null)
                    {
                        adjId.Add(adjacent.Succ.Id);
                        adjacent = adjacent.NextT;
                    }

                    adjId.Sort();
                    foreach(string adj in adjId)
                    {
                        Node NextVisit = G.SearchNode(adj);
                        if (!(NextVisit.visited))
                        {
                            jalurPertemanan.Add(NextVisit.Id);
                            bfsQueue.Enqueue(NextVisit);
                            NextVisit.visited = true;
                            allVisitedNode.Add(NextVisit);

                            if(NextVisit.Id == finish.Id)
                            {
                                friendFound = true;
                                break;
                            }
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