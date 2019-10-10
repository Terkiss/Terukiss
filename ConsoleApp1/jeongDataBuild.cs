using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Data_Structor;

    public class jeongDataBuild<T>
    {

        public JeongLinkedList<T> GenList()
        {
            return new JeongLinkedList<T>();
        }

        public JeongStack<T> GenStack()
        {
            return new JeongStack<T>();
        }
        public JeongQueue<T> GenQueue()
        {
            return new JeongQueue<T>();
        }
        public JeongBinaryTree<T> GenBinaryTree()
        {
        return new JeongBinaryTree<T>();
        }

    }



