using System;
using System.Collections.Generic;
using System.Text;

namespace JeongLIbrary.Data_Structor
{
    public class JeongBinaryTreeNode<T>
    {
 
        public JeongBinaryTreeNode<T> Left = null;
        public JeongBinaryTreeNode<T> Right = null;
        public T Data;
        public JeongBinaryTreeNode()
        {
            Data = default(T);
            Left = null;
            Right = null;
        }
    }
}
