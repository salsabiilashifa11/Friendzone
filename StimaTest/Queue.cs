using System;
using StimaTest;

namespace StimaTest
{
    public class Queue
    {
        //Fields
        private ElmtQueue head;
        private ElmtQueue tail;

        //Constructors
        public Queue()
        {
            head = null;
            tail = null;
        }

        //Getter and Setter
        public ElmtQueue Head
        {
            get { return head; }
            set { head = value; }
        }

        public ElmtQueue Tail
        {
            get { return tail; }
            set { tail = value; }
        }

        public Node InfoHead
        {
            get { return head.Info; }
        }

        public Node InfoTail
        {
            get { return tail.Info; }
        }

        //Methods
        public bool IsEmpty()
        {
            return head == null && tail == null;
        }

        public int NbElmt()
        {
            ElmtQueue P;
            int i;

            i = 0;
            P = head;
            while (P != null)
            {
                i += 1;
                P = P.Next;
            }
            return i;
        }

        public void Enqueue(Node X)
        {
            ElmtQueue P = new ElmtQueue(X);

            if (P != null)
            {
                if (IsEmpty())
                {
                    head = P;
                } else
                {
                    tail.Next = P;
                }

                tail = P;
            }
        }

        public Node Dequeue()
        {
            ElmtQueue P;

            P = head;
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }

            P.Next = null;
            return P.Info;
        }
    }

    public class ElmtQueue
    {
        //Fields
        private ElmtQueue next;
        private Node info;

        //Constructors
        public ElmtQueue(Node P)
        {
            info = P;
            next = null;
        }

        //Getter and Setter
        public ElmtQueue Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node Info
        {
            get { return info; }
            set { info = value; }
        }


        //Methods
    }
}
