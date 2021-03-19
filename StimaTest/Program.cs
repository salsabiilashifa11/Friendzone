using System;
using System.Collections.Generic;
using StimaTest;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ////---------------------- Graph Driver ------------------------
            //string[] ids = new string[5] { "C1", "C2", "C3", "C4", "C5" };

            //Graph g = new Graph("C1");
            //for (int i = 1; i < 5; i++)
            //{
            //    g.InsertNode(ids[i]);
            //}

            //g.InsertEdge("C1", "C2"); //Artinya: menambahkan busur berarah dari C1 KE C2
            //g.InsertEdge("C1", "C5");
            //g.InsertEdge("C2", "C5");
            //g.InsertEdge("C2", "C3");
            //g.InsertEdge("C2", "C4");
            //g.InsertEdge("C3", "C2");
            //g.InsertEdge("C3", "C4");
            //g.InsertEdge("C4", "C2");
            //g.InsertEdge("C4", "C5");
            //g.InsertEdge("C4", "C3");
            //g.InsertEdge("C5", "C4");
            //g.InsertEdge("C5", "C2");
            //g.DeleteNode("C1");

            //Node cP = g.First;
            //while (cP != null)
            //{
            //    Console.WriteLine("Terdapat {0} busur terhubung ke node dengan Id = {1}", cP.NPred, cP.Id);
            //    cP = cP.Next;
            //}

            ////---------------------- Queue Driver ------------------------
            //Queue q = new Queue();

            //q.Enqueue(g.SearchNode("C2"));
            //q.Enqueue(g.SearchNode("C3"));
            //q.Dequeue();
            //q.Enqueue(g.SearchNode("C4"));
            //q.Dequeue();

            //if (q.IsEmpty())
            //{
            //    Console.WriteLine("Queue is empty");
            //}
            //else
            //{
            //    Console.WriteLine("Head Id: {0}", q.InfoHead.Id);
            //}

            ////---------------------- Stack Driver ------------------------
            //Stack s = new Stack();

            //s.Push(g.SearchNode("C2"));
            //s.Push(g.SearchNode("C3"));
            //s.Push(g.SearchNode("C4"));
            //s.Pop();

            //if (q.IsEmpty())
            //{
            //    Console.WriteLine("Queue is empty");
            //}
            //else
            //{
            //    Console.WriteLine("Head Id: {0}", s.InfoTop.Id);
            //}

            //Console.WriteLine("Hello World!");

            //----------------------- BFS Driver -------------------------
            string[] ids_bfs = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };

            Graph g_bfs = new Graph("A");
            for (int i = 1; i < 8; i++)
            {
                g_bfs.InsertNode(ids_bfs[i]);
            }

            g_bfs.InsertEdge("A", "B");
            g_bfs.InsertEdge("A", "C");
            g_bfs.InsertEdge("A", "D");
            g_bfs.InsertEdge("B", "A");
            g_bfs.InsertEdge("B", "C");
            g_bfs.InsertEdge("B", "E");
            g_bfs.InsertEdge("B", "F");
            g_bfs.InsertEdge("C", "A");
            g_bfs.InsertEdge("C", "B");
            g_bfs.InsertEdge("C", "F");
            g_bfs.InsertEdge("C", "G");
            g_bfs.InsertEdge("D", "A");
            g_bfs.InsertEdge("D", "F");
            g_bfs.InsertEdge("D", "G");
            g_bfs.InsertEdge("E", "B");
            g_bfs.InsertEdge("E", "F");
            g_bfs.InsertEdge("E", "H");
            g_bfs.InsertEdge("F", "B");
            g_bfs.InsertEdge("F", "C");
            g_bfs.InsertEdge("F", "D");
            g_bfs.InsertEdge("F", "E");
            g_bfs.InsertEdge("F", "H");
            g_bfs.InsertEdge("G", "C");
            g_bfs.InsertEdge("G", "D");
            g_bfs.InsertEdge("H", "E");
            g_bfs.InsertEdge("H", "F");


            //BFS bfs = new BFS(g_bfs, "A");

            //Console.WriteLine("f");

            //bfs.RunSearch();
            //bfs.PrintVisited();

            //bfs.PrintLevel();

            //List<Node> bfs_path = bfs.GetPath("G");
            //path.Reverse();

            //bfs.PrintPath(bfs_path);


            FriendRec fitur1 = new FriendRec(g_bfs, "B");
            fitur1.PrintResult();

            //----------------------- DFS Driver -------------------------
            string[] ids_test = new string[6] { "A", "B", "C", "D", "E", "F"};

            Graph graph_test = new Graph("A");
            for (int i = 1; i < 6; i++)
            {
                graph_test.InsertNode(ids_test[i]);
            }

            graph_test.InsertEdge("A", "B");
            graph_test.InsertEdge("A", "C");
            graph_test.InsertEdge("B", "D");
            graph_test.InsertEdge("B", "E");
            graph_test.InsertEdge("C", "B");
            graph_test.InsertEdge("C", "F");
            graph_test.InsertEdge("E", "F");

            Console.WriteLine("BFS and DFS Comparison");

            DFS dfs = new DFS(graph_test, "A");
            dfs.RunSearch();
            List<Node> dfs_path = dfs.GetPath("F");
            dfs_path.Reverse();
            dfs.PrintPath(dfs_path);

            BFS bfs = new BFS(graph_test, "A");
            bfs.RunSearch();
            List<Node> bfs_path = bfs.GetPath("F");
            bfs_path.Reverse();
            bfs.PrintPath(bfs_path);
        }
    }
}
