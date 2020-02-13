using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class MyEvent : EventManager
    {

        String ID = "ade345";
        String PW = "45545525@";
        bool isLogin = false;
        bool completSetup = false;
        int eventTime = -1;

        public override void Run()
        {

            while (true)
            {
                if (isLogin == false)
                {

                    Jprint(ConsoleColor.Red, "피시방 이벤토 관리기");
                    Jprint(ConsoleColor.Green, "관리자 아이디 ::: ");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    string idValue = Console.ReadLine();


                    Jprint(ConsoleColor.Green, "관리자 패스워드 ::: ");
                 
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    string pwValue = Console.ReadLine();

                    if (idValue.Equals(ID) && pwValue.Equals(PW))
                    {
                        Console.Clear();

                        Jprint(ConsoleColor.Red, "피시방 이벤토 관리기");
                      

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("관리자 아이디 ::: ");

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(ID + "\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("관리자 패스워드 ::: ");

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("********\n");


                        isLogin = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("환영합니다 ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(ID);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" 관리자님 ! \n");


                    }
                }
                else
                {
                    // 로그인이 된 상태
                    //_instance.timeChecker();
                    if (completSetup == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("진행 하실 이벤트 시간을 설정 해 주십쇼 \n");
                        string eventtimer = Console.ReadLine();

                        for (int i = 1; i <= 10; i++)
                        {
                            if (eventtimer.Equals(Convert.ToString(i)))
                            {
                                eventTime = int.Parse(eventtimer) * 3600 * 1000;
                            }
                        }

                        if (eventTime != -1)
                        {
                            _instance.timeChecker(10000);
                            _instance.runKeyBordLcok();

                            completSetup = true;

                            var imsi = DateTime.Now.ToString("hh");
                            hour = int.Parse(imsi);

                            endHour = int.Parse(eventtimer) + hour;
                            endminit = int.Parse(DateTime.Now.ToString("mm"));

                            _instance.engine();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("메이플 피시방 이벤트는 평일 5시시간 주말 10시간의 적립 제약이 있습니다.");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                    }
                    else
                    {
                        Console.ReadLine();
                    }


                }
            }

        }
    }
}
