using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// 이클래스는 메이플 피시방 관리 프로그램의 진입점 입니다.
    /// 
    /// </summary>
    public  class EventManager
    {
        // 싱글톤
        private EventManager instance = new EventManager();
        
        public EventTimer timer;

        protected EventManager()
        {
           timer = new EventTimer();
        }

        public EventManager _INSTANCE
        {
            get
            {
                return instance;
            }
        }

        public virtual void Run() { }

        protected void Jprint(ConsoleColor a, string str)
        {
            Console.ForegroundColor = a;
            Console.Write(str);
        }
    }
}
