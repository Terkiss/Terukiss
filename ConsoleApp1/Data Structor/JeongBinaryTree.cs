using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data_Structor
{
    public class JeongBinaryTree<T>
    {
        private JeongBinaryTreeNode<T> Root = null;
        private int count = 0;
        private int length = 0;
        private int depth = 0;




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

        public void postorderPrintTree()
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
                    Console.WriteLine("동일한 데이터가 트리안에 있습니다. ");
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
