using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data_Structor
{
    public class JeongListNode<T>
    {

        public JeongLinkedList<T> list;
        public T Data;
        public JeongListNode<T> Next;


        public JeongListNode()
        {
            Data = default(T);
            Next = null;
            list = null;
        }
    }
}
