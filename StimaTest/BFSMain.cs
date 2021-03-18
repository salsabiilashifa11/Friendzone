using System;
using QueueMain;
using GraphMain;

namespace BFSMain
{
    public class BFS
    {
        public void SolverBFS(string X, string Y, Graph G, string[] arrOfGraph)
        {
            Node start = G.SearchNode(X); //mencari node yang id-nya = X
            Node finish = G.SearchNode(Y);
            Queue bfsQueue = new Queue(); //Queue untuk BFS
            bool friendFound = false;

            if (start != null && finish != null) //Pastikan yang dicari ada di dalam graph
            {
                Console.Write(X);
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
                                    string result = $" --> {NextVisit.Id}";
                                    Console.Write(result);
                                    bfsQueue.Enqueue(NextVisit); //Tambahkan Node tetangga ke Queue
                                    NextVisit.visited = true;
                                    if (NextVisit.Id == finish.Id)
                                    {
                                        Console.WriteLine();
                                        friendFound = true; //Ketemu Node yang dituju
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                //Reset visited = false
                for (int i = 0; i < arrOfGraph.Length; i++)
                {
                    Node temp = G.SearchNode(arrOfGraph[i]);
                    temp.visited = false;
                }
            }

            //Tidak ditemukan jalur pertemanan atau teman tidak terdaftar dalam graph Friendzone
            if (!friendFound)
            {
                Console.WriteLine("Tidak ada jalur pertemanan");
            }
        }
    }
}