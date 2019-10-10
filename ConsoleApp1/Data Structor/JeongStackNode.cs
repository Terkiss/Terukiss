using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data_Structor
{
    public class JeongStackNode<T>
    {
        public T Data;
        public JeongStackNode<T> Next;

        public JeongStackNode()
        {
            Data = default(T);
            Next = null;
        }
    }
}
