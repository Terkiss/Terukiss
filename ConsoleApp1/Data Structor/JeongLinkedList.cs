using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data_Structor
{
    public class JeongLinkedList<T>
    {



        public JeongLinkedList<T> Jlist;

        #region variable 
        public JeongListNode<T> Head = null;
        //private JeongListNode<T> Taile;


        private int count = 0;
        #endregion //variable


        public T this[int index]
        {
            get
            {
                int i = 0;
                var curr = Head;

                while (i < _Count)
                {
                    try
                    {
                        if (index == i)
                        {
                            //Console.WriteLine("인출" + curr.Data);
                            return curr.Data;
                        }
                        curr = curr.Next;
                        i++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("예외 오류 밠행");
                        return default(T);
                        // throw;
                    }

                }
                return default(T);
            }
            set
            {
                try
                {
                    int i = 0;
                    var curr = Head;
                    while (i < _Count)
                    {
                        if (i == index)
                        {
                            curr.Data = value;
                            return;
                        }
                        curr = curr.Next;

                        i++;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("예외 오류 ");

                }
            }
        }
        public int _Count
        {
            get { return count; }
        }
        public JeongLinkedList()
        {
            Jlist = this;
        }

        #region 기반함수군
        public void Add(T value)
        {

            var node = new JeongListNode<T>();
            JeongListNode<T> current;
            node.list = this;
            node.Data = value;


            if (Head == null)
            {
                Head = node;
                count++;
            }
            else
            {
                current = Head;
                int cc = 0;
                while (current.Next != null)
                {
                    current = current.Next;
                    System.Console.WriteLine(count);

                }
                current.Next = node;
                node.Next = null;
                count++;
            }
        }

        public int Find(T value)
        {
            int i = 0;
            var curr = Head;
            while (curr != null)
            {
                if (curr.Data.Equals(value) == true)
                {
                    System.Console.WriteLine("찻앗음" + i + " " + curr.Data);
                    return i;
                }

                i++;
                curr = curr.Next;
            }
            return -1;
        }
        public int Find(JeongLinkedList<T> list, T value)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (list[i].Equals(value) == true)
                {
                    System.Console.WriteLine("찻앗음" + i + " " + list[i]);
                    return i;
                }
            }
            return -1;
        }
        public void RemoveAt(int Index)
        {
            var curr = Head;
            var prev = Head;
            int i = 0;

            while (curr != null)
            {

                if (i == Index)
                {
                    var temp = curr.Next;
                    prev.Next = temp;
                    count--;
                    // Console.WriteLine("temp :::" + temp.Data + "   prev:::" + prev.Data);
                    return;
                }
                prev = curr;
                curr = curr.Next;
                i++;
            }
        }

        public void Clean()
        {
            Head= null;
            
            count = 0;
            return;
        }

        #endregion //기반함수군 

        #region 정렬 함수 
        public void QuickSort()
        {

            Stack<int> stk = new Stack<int>();

            if (_Count == 0)
            {
                Console.WriteLine("data empty");
                return;
            }
            T pivot = Jlist[_Count / 2];



            int LeftStart = 0;  //first
            int RightStart = _Count - 1; // last

            int Low;
            int High;




            Console.WriteLine("ddddd + " + stk.EmpTy());
            stk.Push(RightStart);
            stk.Push(LeftStart);

            while (!stk.EmpTy())
            {
                LeftStart = stk.Pop();
                RightStart = stk.Pop();

                if (RightStart - LeftStart - 2 > 1) // 아직도 분할 할수 있는경우
                {
                    pivot = Jlist[RightStart];
                    Low = LeftStart;
                    High = RightStart;
                    Console.WriteLine("분할여부 :: " + (RightStart - LeftStart) + "  불값" + (RightStart - LeftStart > 1));

                    while (true)
                    {
                        Console.WriteLine("L :: " + Low + "H :: " + High + "pivot :: " + pivot);
                      
                        while (Comparerser(pivot, Jlist[Low]))
                        {

                            Low++;
                            if (_Count <= Low)
                            {
                                break;
                            }
                        }
                       
                        while (Comparerser(Jlist[High], pivot))
                        {
                            High--;
                            if (High < 0)
                            {
                                break;
                            }
                        }
                        if (Low >= High)
                        {
                            break;
                        }
                        T LowValue = Jlist[Low];
                        T HighValue = Jlist[High];

                        Jlist[Low] = HighValue;
                        Jlist[High] = LowValue;
                        
                    }

                    T RightStartValue = Jlist[RightStart];
                    Jlist[RightStart] = Jlist[Low];
                    Jlist[Low] = RightStartValue;

                    stk.Push(RightStart);
                    stk.Push(Low + 1);
                    stk.Push(Low - 1);
                    stk.Push(LeftStart);

                }
            }
            InsertionSort();



        }


        public void InsertionSort()
        {
            int i = 0;
            int j = 0;
            T ProcessingData;

            while (i < _Count)
            {
                ProcessingData = Jlist[i];
                if (i == 99)
                {
                    for (j = i - 1; j >= 0 && Comparerser(Jlist[j], ProcessingData); j--)
                    {
                        Console.WriteLine("{0} 과 {1} 의 비교 는 :: {2}", Jlist[j], ProcessingData, Comparerser(Jlist[j], ProcessingData));
                    }
                    Console.WriteLine("j 값 {0} ", j);
                }
                for (j = i - 1; j >= 0 && Comparerser(Jlist[j], ProcessingData); j--)
                {
                    //Console.WriteLine("{0} 과 {1} 의 비교 는 :: {2}", Jlist[j], ProcessingData, Comparerser(Jlist[j], ProcessingData));
                    Jlist[j + 1] = Jlist[j]; // 레코드의 오른쪽으로 이동
                }


                Jlist[j + 1] = ProcessingData;
                i++;

            }
            // 3 2 5 1

        }

        public void InsertionSort2()
        {
            int i = 0;
            var curr = Head;
            T[] TempData = new T[_Count];
            while (curr != null)
            {
                TempData[i] = curr.Data;
                i++;
                curr = curr.Next;
            }
            InsertionSort(ref TempData);
            for (int i2 = 0; i2 < _Count; i2++)
            {
                Console.WriteLine("인덱스 :: {0}  원소 출력 {1}\n", i2, TempData[i2]);
            }
            Clean();
            for (int j = 0; j < TempData.Length; j++)
            {
                Add(TempData[j]);
            }
        }


        public void InsertionSort(ref T[] Data)
        {
            int i = 0;
            int j = 0;
            T ProcessingData;

            while (i < Data.Length)
            {
         
                ProcessingData = Data[i];
                //Console.WriteLine(ProcessingData + "   " + Comparerser(Data[j], ProcessingData));
                for (j = i - 1; j >= 0 && Comparerser(Data[j], ProcessingData); j--)
                {

                    Data[j + 1] = Data[j]; // 레코드의 오른쪽으로 이동
                }

                Data[j + 1] = ProcessingData;
                i++;

            }
            // 3 2 5 1

        }

        public void InsertionSort(ref string[] Data)
        {
            int i = 0;
            int j = 0;
            string ProcessingData = "";
           
            while (i < Data.Length)
            {
                ProcessingData = Data[i];
                for (j = i - 1; j >= 0 && Data[j].CompareTo(ProcessingData) > 0; j--)
                {
                    
                    Data[j + 1] = Data[j]; // 레코드의 오른쪽으로 이동
                }

                Data[j + 1] = ProcessingData;
                i++;

            }
            // 3 2 5 1

        }



        /// <summary>
        /// 비교 함수
        /// 왼쪽이 오른쪽 변수보다 크거나 같으면  TRUE를 반환
        ///                         왼쪽 변수가 오른쪽 변수 보다 작으면 FALSE 를 반환
        /// </summary>
        /// <param name="value"> 좌 </param>
        /// <param name="value2"> 우</param>
        /// <returns></returns>
        private bool Comparerser(T value, T value2)
        {
            var result = Comparer<T>.Default.Compare(value, value2);
            if (result >= 0) { return true; }
            else { return false; }
        }

        #endregion // 정렬 함수 끗


    }



}
