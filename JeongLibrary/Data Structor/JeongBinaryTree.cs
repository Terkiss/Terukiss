﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JeongLIbrary.Data_Structor
{
    public class JeongBinaryTree<T>
    {
        private JeongBinaryTreeNode<T> Root = null;
        private int count = 0;
        private int length = 0;
        private int depth = 0;

        public bool isEmptyRoot
        {
            get 
            {
                return (Root == null) ? true : false; 
            }
        }




        public void AddNode(T Data)
        {
            JeongStack<JeongBinaryTreeNode<T>> JJStack = new JeongStack<JeongBinaryTreeNode<T>>();

            JeongBinaryTreeNode<T> ParrentNode = null;

            try
            {
                SearchBinaryTree(ref ParrentNode, Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("이진 트리 range 에러");
            }

            if (ParrentNode != null)
            {// 설정한 임시 부모노드가 널이 아닐경우 삽입을 시작 에외처리에 주의 

                if (Comparerser(Data, ParrentNode.Data) == true)
                {
                    /// 입력 데이터가 부모 노드의 키보다 작을 경우 
                    JeongBinaryTreeNode<T> tempDataNode = new JeongBinaryTreeNode<T>();
                    tempDataNode.Data = Data;
                    ParrentNode.Left = tempDataNode;
                    count++;
                }
                else
                {
                    /// 입력 데잍터가 부모 노드의 키보다 클 경우 
                    JeongBinaryTreeNode<T> tempDataNode = new JeongBinaryTreeNode<T>();
                    tempDataNode.Data = Data;
                    ParrentNode.Right = tempDataNode;
                    count++;
                }

            }
            else
            {
                // 아무데이터도 없을때 현재 데이터  노드를 루트노드 로 설정
                JeongBinaryTreeNode<T> TempData = new JeongBinaryTreeNode<T>();
                TempData.Data = Data;
                Root = TempData;

            }

        }

        public void RemoveNode(T Data)
        {
            JeongBinaryTreeNode<T> current = Root;
            JeongBinaryTreeNode<T> ParrentNode = Root;
            JeongBinaryTreeNode<T> LeftChiled = null;
            JeongBinaryTreeNode<T> RightChiled = null;
            T catchData;
            while (current != null)
            {
                if (ZeroComparerser(current.Data, Data) == true)
                {
                    LeftChiled = current.Left;
                    RightChiled = current.Right;
              

                    // 단말 노드일경우
                    if (LeftChiled == null && RightChiled == null)
                    {
                        if (current == Root)
                        { //  삭제 대상이 루트 일 경우
                            Root = null;
                            Console.WriteLine("루트 입니다 삭제 할게요");
                            return;
                        }
                        Console.WriteLine("1번쨰 케이스");
                        // 삭제 노드가 단말 노드일경우 부모노드의 왼쪽 또는 오른쪽 의 링크를 끈어줌
                        if (ParrentNode.Left == current)
                        {
                            ParrentNode.Left = null;
                        }
                        else if (ParrentNode.Right == current)
                        {
                            ParrentNode.Right = null;
                        }

                        return;
                    }
                    else if (LeftChiled == null || RightChiled == null)
                    { 
                        //case2 자식이 하나가 있는 사이 노드일때
                        // 자식이 하나만 있을떄 
                        


                        Console.WriteLine("2번쨰 케이스");
                        if (current == Root)
                        { //  삭제 대상이 루트 일 경우
                            if (Root.Left != null)
                            {
                                Root = Root.Left;
                            }
                            else if (Root.Right != null)
                            {
                                Root = Root.Right;
                            }
                            Console.WriteLine("루트 입니다 삭제 할게요");
                            return;
                        }
                        else if (ParrentNode.Left == current)
                        {

                            if (current.Left != null)
                            {
                                ParrentNode.Left = current.Left;
                            }
                            else if (current.Right != null)
                            {
                                ParrentNode.Left = current.Right;
                            }

                        }
                        else if (ParrentNode.Right == current)
                        {
                            if (current.Left != null)
                            {
                                ParrentNode.Right = current.Left;
                            }
                            else if (current.Right != null)
                            {
                                ParrentNode.Right = current.Right;
                            }
                        }

                        return;
                    }
                    else
                    {   //case 3
                        // 왼쪽의 최저점 구하기
                        // 오른쪽끝 확인

                        
                        // 루트 일떄 처리가 안되어 있음
                        Console.WriteLine("3번째 케이스");

                        var Left = LeftChiled;
    
                        var leftMaxCurrent = Left;
                            leftMaxCurrent = null;
        

                        while (Left != null)
                        { // 가장 큰  값 
                            // 이진 트리는 오른쪽 자식이 가장 큰 값을 가짐 
                            if (Left.Right == null)
                            {
                                leftMaxCurrent = Left;
                            }
                         
                            Left = Left.Right;
                        }

                        if (leftMaxCurrent != null)
                        {
                            Console.Write(leftMaxCurrent.Data + " 널 통과 ");
                            var parrNodeOfLeftChild = leftMaxCurrent.Left; 
                       
                            
                            current.Data = leftMaxCurrent.Data;


                            // leftMaxCurrent 좌측 최대값

                            if (ZeroComparerser(current.Left.Data, leftMaxCurrent.Data) == true)
                            {
                                current.Left = current.Left.Left;
                                Console.WriteLine("사양 트리");
                                // 사향 트리
                            }
                            else
                            {
                               
                                  // 좌측 부분 트리에서 가장 큰 노드의 왼쪽 자식이 있다면
                               var currentNode = current.Left;
                               while (currentNode != null)
                               {
                               
                                    if (ZeroComparerser(currentNode.Right.Data, leftMaxCurrent.Data) == true)
                                    {
                                        currentNode.Right = leftMaxCurrent.Left;
                                        return;

                                    }
                                    else
                                    {
                                        currentNode = currentNode.Right;
                                    }
                               }
                            }
              
                        }

                        Console.Write("성공적 종료 우왕");
                        return; 
                    }
                }


                ParrentNode = current;

                if (Comparerser(current.Data, Data) == true)
                {
                    current = current.Right;
                }
                else if (Comparerser(current.Data, Data) == false)
                {
                    current = current.Left;
                }
                
            }


        }

        /// <summary>

        /// 노드를 삭제합니다.

        /// 3가지의 경우를 고려해서 삭제.

        /// Case 1: 리프 노드인 경우

        /// Case 2: 자식이 하나인 경우

        /// Case 3: 자식이 둘인 경우

        /// </summary>

        /// <param name="node"> 삭제하고자 하는 노드 </param>

        /// <returns> 삭제한 후의 그자리에 들어갈 노드 </returns>

        public JeongBinaryTreeNode<T> DeleteNode(JeongBinaryTreeNode<T> node)

        {

            /// Case 1

            if (node.Left == null && node.Right == null)

            {
                return null;
            }

            /// Case 2-1

            else if (node.Left == null && node.Right != null)

            {
                return node.Right;
            }

            /// Case 2-2

            else if (node.Left != null && node.Right == null)

            {
                return node.Left;
            }

            /// Case 3

            else
            {

                JeongBinaryTreeNode<T> corruntNode = node.Right;

                /// 가장 왼쪽 자식의 부모노드를 저장할 변수

                JeongBinaryTreeNode<T> parentNode = null;



                /// 삭제하고자 하는 노드의 오른쪽 자식의 가장 왼쪽 자식까지 찾아간다.

                while (corruntNode.Left != null)

                {

                    parentNode = corruntNode;

                    corruntNode = corruntNode.Left;

                }



                /// 삭제한 노드에 가장 왼쪽 자식을 집어 넣는다.

                node.Data = corruntNode.Data;



                /// 오른쪽 자식에 왼쪽 자식이 없다면

                if (corruntNode == node.Right)

                {

                    /// 오른쪽 자식을 삭제한 노드에 집어 넣는다.

                    node.Right = corruntNode.Right;

                }

                else

                {

                    /// 이동한 노드의 오른쪽 자식이 부모노드의 왼쪽 자식이 된다. (왼쪽 자식은 당연히 없다)

                    parentNode.Left = corruntNode.Right;

                }



                return node;



            }

        }




        public void TreeClean()
        {
            Root = null;
        }




        /// <summary>
        /// 전위 순회 함수
        /// 전위 순회는 뿌리 ->왼쪽 -> 오른쪽 순서로 방문
        /// </summary>
        public void PreorderPrintTree()
        {
            JeongBinaryTreeNode<T> current = Root;
            JeongStack<JeongBinaryTreeNode<T>> BtreeStaks = new JeongStack<JeongBinaryTreeNode<T>>();
            JeongLinkedList<T> printList = new JeongLinkedList<T>();

            if (Root == null)
            {
                Console.Write("리턴 합니다 트리가 비었습니다");
                return;
            }



            BtreeStaks.PuSH(Root);
            //BtreeStaks.PuSH(Root);
            Console.WriteLine(BtreeStaks.IsEmpTy());
            int index = 0;
            while (!BtreeStaks.IsEmpTy())
            {
                var PopData = BtreeStaks.Pop;

                
                

                printList.Add(PopData.Data); // 방문 처리

                //스택은 FIFO 
                // 오른쪽 먼저 삽입 -> 왼쪽 삽입 
                if (PopData.Right != null)
                {
                    BtreeStaks.Push = PopData.Right;
                }

                if (PopData.Left != null)
                {
                    BtreeStaks.Push = PopData.Left;
                }
            }
            ConsolPrint(ref printList);
         
        }




        /// <summary>
        /// 중위 순회 
        /// </summary>
        public void InorderPrintTree()
        {
            JeongBinaryTreeNode<T> current = null;
            JeongStack<JeongBinaryTreeNode<T>> BtreeStaks = new JeongStack<JeongBinaryTreeNode<T>>();
            JeongLinkedList<T> printList = new JeongLinkedList<T>();
            
            BtreeStaks.PuSH(current);
            current = Root;
            //BtreeStaks.PuSH(Root);
            Console.WriteLine(BtreeStaks.IsEmpTy());
            

            while (!BtreeStaks.IsEmpTy())
            {
                // 매 반복시 왼쪾 트리 검색 만약 왼쪽 트리 원소가 있다면 스택에 저장
                while (current != null)
                {
                    BtreeStaks.Push = current;

                    current = current.Left;
                }
                current = BtreeStaks.Pop;

                if (current == null)
                {
                    Console.WriteLine("현재 널 발생");
                    break;
                }
               // break;
                printList.Add(current.Data);

                current = current.Right;
                Console.WriteLine("현재 널 발생2");
            }
            ConsolPrint(ref printList);
        }



        /// <summary>
        /// ㅎ후위 순회
        /// </summary>
        public void postorderPrintTree()
        {
            JeongBinaryTreeNode<T> current = null;
            JeongBinaryTreeNode<T> doneNode = null;
            JeongStack<JeongBinaryTreeNode<T>> BtreeStaks = new JeongStack<JeongBinaryTreeNode<T>>();
            JeongLinkedList<T> printList = new JeongLinkedList<T>();

            //BtreeStaks.PuSH(current);
            current = Root;
            //BtreeStaks.PuSH(Root);
            Console.WriteLine(BtreeStaks.IsEmpTy());

            string stackPath = "";
            int i = 0;
            while (true)
            {
                if (current != null && current != doneNode)
                {
                    // 매 반복시 왼쪾 트리 검색 만약 왼쪽 트리 원소가 있다면 스택에 저장
                    //stackPath += current.Data + " -> ";
                    BtreeStaks.Push = current;
                    while (current != null)
                    {


                        if (current.Right != null)
                        {
                            BtreeStaks.Push = current.Right;
                            //stackPath += current.Right.Data + " -> ";
                        }
                        if (current.Left != null)
                        {
                            BtreeStaks.Push = current.Left;
                            //stackPath += current.Left.Data + " -> ";
                        }


                        current = current.Left;
                    }
                }

                
                int sa = 1;
                //Console.WriteLine((i++) + " 회차 스택 뷰 \n");
                //treeStaks.StackView();
                if (!BtreeStaks.IsEmpTy())
                {
                   

                    current = BtreeStaks.Pop;  // 스택에서 노드 뽑기

                    // 왼쪽 노드가 널이 아니고 오른쪽 노드가 널인경우
                    if (current.Left != null && current.Right == null && current.Left != doneNode)
                    {
                        BtreeStaks.Push = current;
                      //  stackPath += current.Data + "|| -> ";
                        current = current.Left;
                    }

                    if (current.Right == null || current.Right == doneNode)
                    {
                        printList.Add(current.Data);
                        doneNode = current;
                    }
                   // Console.WriteLine("done Node :: " + doneNode.Data);
                }
                else
                {
                    break;
                }
                //Console.WriteLine(stackPath);
            }
            ConsolPrint(ref printList);
        }

        public void treetraval()
        {

        }
            
        
        public void ConsolPrint(ref JeongLinkedList<T> printList)
        {
            string TextData = "";
            for (int i = 0; i < printList._Count; i++)
            {
                if (i % 5 == 0)
                {
                    //Console.WriteLine("\n");
                    TextData += "\n";
                }
                if (i == printList._Count - 1)
                {
                    TextData += printList[i];
                }
                else
                {
                    TextData += printList[i] + " -> ";
                }


            }
            Console.WriteLine("결과 \n" + TextData);
        }
        /// <summary>
        /// 이진 탐색 트리의 탐색 함수
        /// 좌측 값 vs 우측 값
        /// 비교를 통해 
        /// 작으면 왼쪽
        /// 크면 오른쪽으로 탐색
        /// </summary>
        /// <param name="ParrentNode"></param>
        /// <param name="Data"></param>
        private void SearchBinaryTree(ref JeongBinaryTreeNode<T> ParrentNode, T Data)
        {
            JeongBinaryTreeNode<T> Current = Root;
            while (Current != null)
            {
                if (ZeroComparerser(Data, Current.Data) == true)
                {
                    Console.WriteLine("동일 데이터 있음 . ");
                    return;
                }

                ParrentNode = Current; // 현재 탐색 중인 노드를 임시 부모 로 설정 


                if (Comparerser(Data, Current.Data) == true)
                {
                    Current = Current.Left;
                }
                else
                {
                    Current = Current.Right;
                }
            }
        }

        /// <summary>
        /// 비교 함수
        /// 오른 쪽 이 왼쪽 변수보다 크거나 같으면  TRUE를 반환
        ///                         왼쪽 변수가 오른쪽 변수 보다 작으면 FALSE 를 반환
        /// </summary>
        /// <param name="value"> 좌 </param>
        /// <param name="value2"> 우</param>
        /// <returns></returns>
        private bool Comparerser(T value, T value2)
        {
            var result = Comparer<T>.Default.Compare(value, value2);
            if (result < 0) { return true; }
            else { return false; }
        }

        private bool ZeroComparerser(T value, T value2)
        {
            var result = Comparer<T>.Default.Compare(value, value2);
            if (result == 0) { return true; }
            else { return false; }
        }
    }
}
