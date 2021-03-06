﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JeongLIbrary.Data_Structor
{
    public class JeongStack<T>
    {

        JeongStackNode<T> JStack = null;
        int count = 0;

        public int _Count
        {
            get
            {
                return count;
            }
        }
        public T Pop
        {
            get
            {
                return PoP();
            }
        }

        public T Push
        {
            set
            {
                PuSH(value);
            }
        }
        public T PoP()
        {
            try
            {
                if (count == 0)
                {
                    return default(T);
                }

                var ResultData = JStack.Data;
                count--;
                JStack = JStack.Next;
                return ResultData;

            }
            catch (Exception ex)
            {
                Console.WriteLine("오류 발견 ");
                
                return default(T);
            }
            
        }


        /// <summary>
        /// 스택의 입력 함수 
        /// </summary>
        /// <param name="Data"></param>
        public void PuSH(T Data)
        {
            JeongStackNode<T> TempNode = new JeongStackNode<T>();

            TempNode.Data = Data;

            TempNode.Next = JStack;
            JStack = TempNode;
            count++;
        }

        /// <summary>
        /// 스텍이 비었을경우 트루반환
        /// </summary>
        /// <returns></returns>
        public bool IsEmpTy()
        {
            if (count == 0)
            {
                //return true;
                return true;
            }
            else
            {
                // return false;S
                return false;
            }
        }

        public void StackView()
        {
            JeongStackNode<T> current = JStack;
            while (current !=null)
            {
                var data = current.Data;
                Console.WriteLine(data + " ->");
                current = current.Next;
                
            }
        }


        /// 스택은 정렬할 필요가 없다 어떤 데이터 던지 입력 된 순서의 거꾸로의 순서로
        /// 입력 되기 떄문이다..
        /// 출력은 입력의  역순 
        /// 


    }
}
