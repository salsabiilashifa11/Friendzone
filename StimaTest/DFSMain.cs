using System;
using StackMain;
using GraphMain;

namespace DFSMain
{
    public class DFS
    {
        public void SolverDFS(string X, string Y, Graph G, string[] arrOfGraph)
        {
            Node start = G.SearchNode(X); //mencari node yang id-nya = X
            Node finish = G.SearchNode(Y);
            Stack dfsStack = new Stack(); //Stack untuk DFS
            bool friendFound = false;

            if (start != null && finish != null) //Pastikan yang dicari ada di dalam graph
            {
                //Console.Write(X);
                //start.visited = true; //Tandai node yang sudah dikunjungi

                dfsStack.Push(start); //Tambahkan node pertama ke Stack

                while (!(dfsStack.IsEmpty()) && !friendFound)
                {
                    Node Visit = dfsStack.InfoTop; //Node yang sedang dikunjungi
                    dfsStack.Pop(); //Pop Node yang akan dikunjungi
                    if (!(Visit.visited))
                    {
                        if (Visit.Id == start.Id)
                        {
                            Console.Write(Visit.Id);
                        }
                        else
                        {
                            string result = $" --> {Visit.Id}";
                            Console.Write(result);
                        }
                        Visit.visited = true;
                    }
                    if (Visit.Id == finish.Id)
                    {
                        Console.WriteLine();
                        friendFound = true;
                    }

                    //Loop dimulai dari belakang supaya prioritas tetap sesuai berdasarkan abjad
                    //jadi yang disort tinggal arraynya aja buat menuhin syarat prioritas
                    for (int i = arrOfGraph.Length-1; i > -1; i--) //Loop pencarian Node yang bertetangga dengan node "Visit"
                    {
                        if (arrOfGraph[i] != Visit.Id)
                        {
                            if (G.SearchEdge(Visit.Id, arrOfGraph[i]) != null) //Ketemu node yang bertetangga
                            {
                                Node NextVisit = G.SearchNode(arrOfGraph[i]);
                                if (!(NextVisit.visited)) //Node tetangga belum pernah dikunjungi
                                {
                                    dfsStack.Push(NextVisit); //Tambahkan Node tetangga ke Stack
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