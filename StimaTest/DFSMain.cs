using System;
using StackMain;
using GraphMain;
using System.Collections.Generic;

namespace DFSMain
{
    public class DFS
    {
        public List<string> SolverDFS(string X, string Y, Graph G, string[] arrOfGraph)
        {
            Node start = G.SearchNode(X); //mencari node yang id-nya = X
            Node finish = G.SearchNode(Y);
            Stack dfsStack = new Stack(); //Stack untuk DFS
            bool friendFound = false;
            var jalurPertemanan = new List<string>(); //return value

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
                        Visit.visited = true;
                    }
                    if (Visit.Id == finish.Id)
                    {
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