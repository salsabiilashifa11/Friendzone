using System;
using System.Collections.Generic;
using GraphMain;

namespace Main
{
    class DriverGraph
    {
        static void Main(string[] args)
        {

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

            Console.WriteLine("Hello World!");

        }
    }
}
