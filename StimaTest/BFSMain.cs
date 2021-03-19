using System;
using QueueMain;
using GraphMain;
using System.Collections.Generic;

namespace BFSMain
{
    public class BFS
    {
        public List<string> SolverBFS(string X, string Y, Graph G, string[] arrOfGraph)
        {
            Node start = G.SearchNode(X); //mencari node yang id-nya = X
            Node finish = G.SearchNode(Y);
            Queue bfsQueue = new Queue(); //Queue untuk BFS
            bool friendFound = false;
            List<string> jalurPertemanan = new List<string>(); //return value
            

            if (start != null && finish != null) //Pastikan yang dicari ada di dalam graph
            {
                jalurPertemanan.Add(start.Id);

                start.visited = true; //Tandai node yang sudah dikunjungi

                bfsQueue.Enqueue(start); //Tambahkan node pertama ke Queue

                while (!(bfsQueue.IsEmpty()) && !friendFound)
                {
                    Node Visit = bfsQueue.InfoHead; //Node yang sedang dikunjungi
                    bfsQueue.Dequeue();//Dequeue Node yang dikunjungi

                    for (int i = 0; i < arrOfGraph.Length; i++) //Loop pencarian Node yang bertetangga dengan node "Visit"
                    {
                        if (arrOfGraph[i] != Visit.Id)
                        {
                            if (G.SearchEdge(Visit.Id, arrOfGraph[i]) != null) //Ketemu node yang bertetangga
                            {
                                Node NextVisit = G.SearchNode(arrOfGraph[i]);
                                if (!(NextVisit.visited)) //Node tetangga belum pernah dikunjungi
                                {
                                    jalurPertemanan.Add(NextVisit.Id);
                                    bfsQueue.Enqueue(NextVisit); //Tambahkan Node tetangga ke Queue
                                    NextVisit.visited = true;
                                    if (NextVisit.Id == finish.Id)
                                    {
                                        friendFound = true; //Ketemu Node yang dituju
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                //Reset bool visited = false
                for (int i = 0; i < arrOfGraph.Length; i++)
                {
                    Node temp = G.SearchNode(arrOfGraph[i]);
                    temp.visited = false;
                }
            }
            if (friendFound) { return jalurPertemanan; }
            else { return null; }
        }
    }
}