using System;

namespace StimaTest
{
    public class Graph
    {
        //Fields
        private Node first;

        //Constructors
        public Graph(string X)
        {
            Node P = new Node(X);
            this.first = P;
        }

        //Getter and Setter
        public Node First
        {
            get { return first; }
            set { first = value; }
        }


        //Methods
        public Node SearchNode(string X)
        {
            Node P;
            P = first;
            while (P != null && P.Id != X)
            {
                P = P.Next;
            }
            return P;
        }

        public SuccNode SearchEdge(string prec, string succ)
        {
            Node P;
            SuccNode T;

            P = SearchNode(prec);

            if (P == null) { return null; }
            else
            {
                T = P.Trail;
                if (T == null) { return null; }
                else
                {
                    while ((T.Succ).Id != succ && (T.NextT != null))
                    {
                        T = T.NextT;
                    }
                    if (T.Succ.Id != succ) { return null; }
                    else { return T; }
                }
            }
        }

        public void InsertNode(string X)
        {
            Node LastG;

            LastG = first;
            Node Pn = new Node(X);
            if (Pn != null)
            {
                while (LastG.Next != null)
                {
                    LastG = LastG.Next;
                }
                LastG.Next = Pn;
            }

        }

        //Can only be used for nodes with NPred = 0 for now
        public void DeleteNode(string X)
        {
            Node P;
            Node Prev;

            P = SearchNode(X);
            Prev = first;

            //removing from main list
            if (P != null)
            {
                if (P == first)
                {
                    first = P.Next;
                } else
                {
                    while (Prev.Next != P)
                    {
                        Prev = Prev.Next;
                    }
                    Prev.Next = P.Next;
                }

                //Removing all edges that P is connected to
                DeleteAllEdges(P);
            }
        }

        public void InsertEdge(string prec, string succ)
        {
            Node Pprec = SearchNode(prec);
            Node Psucc = SearchNode(succ);
            SuccNode T;

            if (SearchEdge(prec, succ) == null)
            {
                T = Pprec.Trail;
                if (T == null)
                {
                    SuccNode temp = new SuccNode(Psucc);
                    Pprec.Trail = temp;
                } else
                {
                    while (T.NextT != null)
                    {
                        T = T.NextT;
                    }
                    SuccNode temp = new SuccNode(Psucc);
                    T.NextT = temp;
                }
                Psucc.NPred += 1;
            }

        }

        public void DeleteAllEdges(Node Pn)
        {
            SuccNode Pt;

            Pt = Pn.Trail;
            while (Pt != null)
            {
                (Pt.Succ).NPred -= 1;
                Pt = Pt.NextT;
            }
        }

    }

    public class Node
    {
        //Fields
        private int nPred;
        private string id;
        private Node next;
        private SuccNode trail;

        //Constructors
        public Node(string _Id)
        {
            this.id = _Id;
            this.nPred = 0;
            this.next = null;
            this.trail = null;
        }

        //Getter and Setter
        public int NPred
        {
            get { return nPred; }
            set { nPred = value;  }
        }

        public string Id
        {
            get { return id; }
            set { id = value;  }
        }

        public Node Next
        {
            get { return next; }
            set { next = value;  }
        }

        public SuccNode Trail
        {
            get { return trail; }
            set { trail = value; }
        }


        //Methods
    }

    public class SuccNode
    {
        //Fields
        private Node succ;
        private SuccNode nextT;

        //Constructors
        public SuccNode(Node Pn)
        {
            this.succ = Pn;
        }

        //Getter and Setter
        public Node Succ
        {
            get { return succ; }
            set { succ = value; }
        }

        public SuccNode NextT
        {
            get { return nextT; }
            set { nextT = value; }
        }

    }
}
