using System;
using System.Collections.Generic;
using System.Text;

namespace JeongLibrary.Data_Structor
{
    public class JeongStruct<T>
    {

        public JeongStruct()
        {

        }

        /// <summary>
        /// 비교 함수
        /// 왼쪽이 오른쪽 변수보다 크거나 같으면  TRUE를 반환
        ///                         왼쪽 변수가 오른쪽 변수 보다 작으면 FALSE 를 반환
        /// </summary>
        /// <param name="value"> 좌 </param>
        /// <param name="value2"> 우</param>
        /// <returns></returns>
        protected bool Comparerser(T value, T value2)
        {
            var result = Comparer<T>.Default.Compare(value, value2);
            if (result >= 0) { return true; }
            else { return false; }
        }

        protected bool ZeroComparerser(T value, T value2)
        {
            var result = Comparer<T>.Default.Compare(value, value2);
            if (result == 0) { return true; }
            else { return false; }
        }
    }
}

