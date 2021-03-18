using System;
using System.Collections.Generic;
using GraphMain;
using QueueMain;
using StackMain;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------------------- Graph Driver ------------------------
            string[] ids = new string[5] { "C1", "C2", "C3", "C4", "C5" };

            Graph g = new Graph("C1");
            for (int i = 1; i < 5; i++)
            {
                g.InsertNode(ids[i]);
            }

            g.InsertEdge("C1", "C2"); //Artinya: menambahkan busur berarah dari C1 KE C2
            g.InsertEdge("C1", "C5");
            g.InsertEdge("C2", "C5");
            g.InsertEdge("C2", "C3");
            g.InsertEdge("C2", "C4");
            g.InsertEdge("C3", "C2");
            g.InsertEdge("C3", "C4");
            g.InsertEdge("C4", "C2");
            g.InsertEdge("C4", "C5");
            g.InsertEdge("C4", "C3");
            g.InsertEdge("C5", "C4");
            g.InsertEdge("C5", "C2");
            g.DeleteNode("C1");

            Node cP = g.First;
            while (cP != null)
            {
                Console.WriteLine("Terdapat {0} busur terhubung ke node dengan Id = {1}", cP.NPred, cP.Id);
                cP = cP.Next;
            }

            //---------------------- Queue Driver ------------------------
            Queue q = new Queue();

            q.Enqueue(g.SearchNode("C2"));
            q.Enqueue(g.SearchNode("C3"));
            q.Dequeue();
            q.Enqueue(g.SearchNode("C4"));
            q.Dequeue();

            if (q.IsEmpty())
            {
                Console.WriteLine("Queue is empty");
            } else
            {
                Console.WriteLine("Head Id: {0}", q.InfoHead.Id);
            }

            //---------------------- Stack Driver ------------------------
            Stack s = new Stack();

            s.Push(g.SearchNode("C2"));
            s.Push(g.SearchNode("C3"));
            s.Push(g.SearchNode("C4"));
            s.Pop();

            if (q.IsEmpty())
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                Console.WriteLine("Head Id: {0}", s.InfoTop.Id);
            }

            Console.WriteLine("Hello World!");


        }
    }
}
