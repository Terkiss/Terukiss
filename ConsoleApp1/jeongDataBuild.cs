using System;
using System.Collections.Generic;
using System.Text;
using JeongLIbrary.Data_Structor;

public class jeongDataBuild<T>
{

    /// <summary>
    /// 지 정 형식의  링크 리스트를 반환 합니다
    /// </summary>
    /// <returns></returns>
    public JeongLinkedList<T> GenList()
    {
        return new JeongLinkedList<T>();
    }

    /// <summary>
    ///  지정 형식의 스택을 반환 합니다
    /// </summary>
    /// <returns></returns>
    public JeongStack<T> GenStack()
    {
        return new JeongStack<T>();
    }

    /// <summary>
    /// 지정 형식의 큐를 반환 합니다.
    /// </summary>
    /// <returns></returns>
    public JeongQueue<T> GenQueue()
    {
        return new JeongQueue<T>();
    }

    /// <summary>
    /// 지정 형식의 바이너리 트리를 반환 합니다.
    /// </summary>
    /// <returns></returns>
    public JeongBinaryTree<T> GenBinaryTree()
    {
        return new JeongBinaryTree<T>();
    }


    /// <summary>
    /// 지정 형식의 레드 블렉 트리를 반환 합니다. 
    /// </summary>
    /// <returns></returns>
    public JeongRedBlackTree<T> GenRBTree()
    {
        return new JeongRedBlackTree<T>();
    }


}



