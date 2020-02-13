using System;
using System.Timers;


namespace Library
{
    class Program
    {
        private static Program _instance;
        public Program Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        static void Main(string[] args)
        {
       
            _instance = new Program();

            //_instance.NeuralNetworkTest();

            //_instance.StructureTest();
            //_instance.TestFunc();
            String ID = "ade345";
            String PW = "45545525@";
            bool isLogin = false;
            bool completSetup = false;
            int eventTime = -1;

            while (true)
            {
                if (isLogin == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("피시방 이벤토 관리기");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("관리자 아이디 ::: ");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    string idValue = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;


                    Console.Write("관리자 패스워드 ::: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    string pwValue = Console.ReadLine();

                    if (idValue.Equals(ID) && pwValue.Equals(PW))
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("피시방 이벤토 관리기");

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

        static int hour, minte;
        static int endHour;
        static int endminit;

        static int Seconds = 0;

        private void engine()
        {
            Timer timer = new Timer();
            timer.Interval = 60 * 1000;
            timer.Elapsed += new ElapsedEventHandler(viewview);
            timer.Start();
        }
        // 쓰레드풀의 작업쓰레드가 지정된 시간 간격으로
        // 아래 이벤트 핸들러 실행
        static void viewview(object sender, ElapsedEventArgs e)
        {
            string currentHour = DateTime.Now.ToString("hh");
            string currentMint = DateTime.Now.ToString("mm");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("현재 시간은 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currentHour);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 시 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currentMint);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 분 입니다\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("피시방 적립 누적 엔드 시간은");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(endHour);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 시");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(minte);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 분 입니다 \n");


            int invailedHour = endHour - int.Parse(currentHour);
            int invailedMinite;
            if (int.Parse(currentMint) <= endminit)
            {
                // 현재 시간이 엔드 시간보다 작을 경우
                invailedMinite = (endminit - int.Parse(currentMint));
            }
            else
            {
                // 현재 시간이 엔드 시간보다 클경우
                invailedMinite = (60 + endminit) - int.Parse(currentMint);
                invailedHour--;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(invailedHour);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 시간  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(invailedMinite);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 분 남았습니다. \n");


            Console.WriteLine("모니터링 기반 프로그램 전부 이상무");


        }
        private void runKeyBordLcok()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 키보드 락 모듈과 직결 중 . \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 키보드 락 모듈과 직결 중 .. \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 키보드 락 모듈과 직결 중 ... \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" 키보드 락 모듈과 프로토콜 연결 성공 \n");
            Console.ForegroundColor = ConsoleColor.Red;


        }

        private void timeChecker(int time)
        {
            Timer timer = new Timer();
            timer.Interval = time;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        // 쓰레드풀의 작업쓰레드가 지정된 시간 간격으로
        // 아래 이벤트 핸들러 실행
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Seconds == 60)
            {   
                // 시간이 60초 일경우 케이스
                Seconds = 0;
                int imsi = endminit;
                imsi--;
                if (imsi <= 0)
                {
                    endHour--;
                    endminit += 60;
                }

            }
            else
            { // 시간이 60 초 미만일 경우 케이스
                Seconds += 10;
            }
            Console.WriteLine("10초가 지났어요");
        }

    }




}
