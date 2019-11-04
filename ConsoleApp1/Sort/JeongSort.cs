using System;
using System.Collections.Generic;
using JeongLIbrary;

public class JeongSort
{

    public void QuickSort(ref int[] Data)
    {

        Stack<int> stk = new Stack<int>();

        if (Data.Length == 0)
        {
            Console.WriteLine("data empty");
            return;
        }
        int pivot = (Data[0] + Data[Data.Length - 1]) / 2;
        

        
        int LeftStart = 0;  //first
        int RightStart = Data.Length - 1; // last

        int Low ;
        int High;
     
            
       

        Console.WriteLine("ddddd + " + stk.EmpTy() );
        stk.Push(RightStart);
        stk.Push(LeftStart);

        while (!stk.EmpTy())
        {
            LeftStart = stk.Pop();
            RightStart = stk.Pop();

            if (RightStart - LeftStart -2   > 1) // 아직도 분할 할수 있는경우
            {
                pivot = Data[RightStart];
                Low = LeftStart ;
                High = RightStart;
            Console.WriteLine("분할여부 :: " + (RightStart - LeftStart) + "  불값" + (RightStart - LeftStart > 1));
            
                while (true)
                {
                    Console.WriteLine("L :: " + Low + "H :: " + High + "pivot :: " + pivot);

                    while (Data[Low] < pivot)
                    { 
                        // 왼쪽 영역 작으면 넘어감
                        // 피봇 보다 큰 값을 찿음

                        Low++;
                        if (Data.Length <= Low)
                        {
                            break;
                        }
                    }
                    while (Data[High] >= pivot) 
                    {
                        // 오른쪽 영역 크면 넘어감
                        // 피봇 보다 작은 값을 찾음
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
                    Swap(ref Data[Low], ref Data[High]);

                }

                Swap(ref Data[Low], ref Data[RightStart]);

                stk.Push(RightStart);
                stk.Push(Low + 1);
                stk.Push(Low - 1);
                stk.Push(LeftStart);

            }
        }
        InsertionSort(ref Data);



    }

    public void InsertionSort(ref int[] Data)
    {
        int i = 0;
        int j = 0;
        int ProcessingData = 0;
        int SwapData = 0;
        while (i < Data.Length)
        {
            ProcessingData = Data[i];
            for ( j = i - 1; j >= 0 && Data[j] > ProcessingData; j--)
            {
                Data[j + 1] =  Data[j]; // 레코드의 오른쪽으로 이동
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
        int SwapData = 0;
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

    public void Swap(ref int Data, ref int Data2)
    {
        int temp  = Data;
        Data = Data2;
        Data2 = temp;

    }


}