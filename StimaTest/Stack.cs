using System;
using StimaTest;

namespace StimaTest
{
    public class Stack
    {
        //Fields
        private ElmtStack top;

        //Constructors

        public Stack()
        {
            top = null;
        }

        //Getter and Setter
        public ElmtStack Top
        {
            get { return top; }
            set { top = value; }
        }

        public Node InfoTop
        {
            get { return top.Info; }
        }

        //Methods
        public bool IsEmpty()
        {
            return top == null;
        }

        public void Push(Node X)
        {
            ElmtStack P = new ElmtStack(X);

            if (P != null)
            {
                if (IsEmpty())
                {
                    top = P;
                    P.Next = null;
                } else
                {
                    P.Next = top;
                    top = P;
                }
            }
        }

        public void Pop()
        {
            ElmtStack P;

            P = top;
            if (top.Next == null)
            {
                top = null;
            } else
            {
                top = top.Next;
                P.Next = null;
            }
        }


    }

    public class ElmtStack
    {
        //Fields
        private ElmtStack next;
        private Node info;

        //Constructors
        public ElmtStack(Node P)
        {
            info = P;
            next = null;
        }

        //Getter and Setter
        public ElmtStack Next
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
