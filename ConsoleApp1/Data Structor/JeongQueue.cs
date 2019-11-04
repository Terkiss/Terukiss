using System;
using System.Collections.Generic;
using System.Text;

namespace JeongLIbrary.Data_Structor
{
    public class JeongQueue<T>
    {
        // 큐 는 선형 먼저 들간놈이 먼저 나온다




        private JeongQueueNode<T> head = null;
        private JeongQueueNode<T> Taile = null;
        private int _conunt = 0;

        public int Count
        {
            get
            {
                return _conunt;
            }
        
        }

        public T PoP()
        {
            if (_conunt >= 0)
            {
                var ReciveData = head.Data;
                head = head.Next;
                _conunt--;


                return ReciveData;

            }

            return default;
        }

        public void PuSH(T Data)
        {
            JeongQueueNode<T> TempQueue = new JeongQueueNode<T>();
            TempQueue.Data = Data;
            TempQueue.Next = null;

            if (Count == 0)
            {
                // 카운트가 0일경우 첫 번쨰 
                head = TempQueue;
                Taile = TempQueue;
            }
            else
            {
                // 카운트가 0이 아닐경우 이미 여러개 입력
                Taile.Next = TempQueue;
                Taile = TempQueue;
            }
            _conunt++;
        }
    }
}
