using System;
using JeongLIbrary.Data_Structor;
namespace ProcessingTest
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
            _instance.TestFunc();
            

        }

        private void TestFunc()
        {
            var test = new jeongDataBuild<int>();
            var list = test.GenList();
            var jjstack = test.GenStack();
            var jquequ = test.GenQueue();
            var jtree = test.GenBinaryTree();
            Console.WriteLine("1. 삽입\n 2.삭제 \n 3.보기 \n 4. 정렬 \n 5. 랜덤 데이터 생성 \n S1. 스텍 테스트 ");
            while (true)
            {
                string Select;
                Select = Console.ReadLine();

                if (Select.Equals("1") == true)
                {
                    Console.WriteLine("삽입 선택\n 입력 할 값은 : ");
                    string Value;
                    Value = Console.ReadLine();
                    list.Add(int.Parse(Value));
                    Console.WriteLine("값이 잘 입력 되었씁니다. \n");

                    Console.WriteLine("1.삽입\n 2.삭제 \n 3.보기 \n 4.정렬\n 5. 랜덤 데이터 생성");


                }
                else if (Select.Equals("2") == true)
                {
                    Console.WriteLine("삭제 선택\n 삭제할 인덱스 : ");
                    string Value = Console.ReadLine();
                    list.RemoveAt(int.Parse(Value));
                    Console.WriteLine("삭제 완료");
                }
                else if (Select.Equals("3") == true)
                {
                    Console.WriteLine("뷰 선택\n 현재 리스트 의 상태는 ");
                    for (int i = 0; i < list._Count; i++)
                    {
                        Console.WriteLine("인덱스 :: {0}  원소 출력 {1}\n", i, list[i]);

                    }

                    Console.WriteLine("1.삽입\n 2.삭제 \n 3.보기 \n 4.정렬");
                }
                else if (Select.Equals("4") == true)
                {
                    Console.WriteLine("정렬 선택\n 선택 정렬");
                    //list.InsertionSort2();
                    list.QuickSort();
                }
                else if (Select.Equals("5") == true)
                {
                    Random random = new Random();
                    for (int i = 0; i < 100; i++)
                    {
                        list.Add(random.Next(0, 1000));
                    }
                }
                else if (Select.Equals("exit") == true || Select.Equals("Exit") == true)
                {
                    break;
                }
                else if (Select.Equals("S1") == true)
                {
                    Console.WriteLine("삽입 선택\n 입력 할 값은 : ");
                    string Value;
                    Value = Console.ReadLine();
                    jjstack.PuSH(int.Parse(Value));

                    Console.WriteLine("입력 완료 현재 카운트 값은 ? :: {0}", jjstack._Count);

                }
                else if (Select.Equals("SView") == true)
                {
                    int[] Temp = new int[jjstack._Count];
                    for (int i = 0; i < Temp.Length; i++)
                    {
                        Temp[i] = jjstack.PoP();
                        Console.WriteLine("Stack[{0}] = {1}", i, Temp[i]);
                    }
                }
                else if (Select.Equals("srand") == true)
                {
                    Random random = new Random();
                    for (int i = 0; i < 100; i++)
                    {
                        var data = random.Next(0, 1000);
                        jjstack.PuSH(data);
                        Console.WriteLine("Stack[{0}] = {1}", i, data);
                    }
                }
                else if (Select.Equals("q1") == true)
                {
                    Console.WriteLine("삽입 선택\n 입력 할 값은 : ");
                    string Value;
                    Value = Console.ReadLine();
                    jquequ.PuSH(int.Parse(Value));

                    Console.WriteLine("입력 완료 현재 카운트 값은 ? :: {0}", jjstack._Count);

                }
                else if (Select.Equals("q2") == true)
                {
                    int[] Temp = new int[jquequ.Count];
                    for (int i = 0; i < Temp.Length; i++)
                    {
                        Temp[i] = jquequ.PoP();
                        Console.WriteLine("Stack[{0}] = {1}", i, Temp[i]);
                    }
                }
                else if (Select.Equals("q3") == true)
                {
                    Random random = new Random();
                    for (int i = 0; i < 100; i++)
                    {
                        var data = random.Next(0, 1000);
                        jquequ.PuSH(data);
                        Console.WriteLine("Stack[{0}] = {1}", i, data);
                    }
                }
                else if (Select.Equals("t1") == true)
                {
                    // 수동 입력
                    Console.WriteLine("삽입 선택\n 입력 할 값은 : ");
                    //string Value;
                    //Value = Console.ReadLine();
                    //jtree.AddNode(int.Parse(Value));

                    jtree.AddNode(8);
                    jtree.AddNode(9);
                    jtree.AddNode(5);
                    jtree.AddNode(6);
                    jtree.AddNode(4);
                    jtree.AddNode(2);
                    jtree.AddNode(1);
                    jtree.AddNode(7);

                    Console.WriteLine("입력 완료 현재 카운트 값은 ? :: ");

                }
                else if (Select.Equals("t2") == true)
                {
                    //랜덤 입력
                    Console.WriteLine("랜덤 삽입");

                    Random random = new Random();

                    for (int i = 0; i < 10; i++)
                    {
                        var data = random.Next(0, 100);
                        jtree.AddNode(data);
                    }

                }
                else if (Select.Equals("tview") == true)
                {
                    Console.WriteLine("화면 출력");
                    jtree.InorderPrintTree();

                }
                else if (Select.Equals("ttval") == true)
                {
                    jtree.PreorderPrintTree();
                }
                else if (Select.Equals("tp") == true)
                {
                    jtree.postorderPrintTree();
                }
                else if (Select.Equals("trm") == true)
                {
                    jtree.RemoveNode(4);
                }
            }

        }
    }

    //private void StructureTest()
    //{
    //    var test = new jeongDataBuild<int>();
    //    var list = test.GenList();
    //    for (int i = 0; i < list._Count; i++)
    //    {
    //        Console.WriteLine(i + "삽입 전  원소 출력 2 {0}", list[i]);
    //    }
    //    list.Add(10);
    //    list.Add(9);
    //    list.Add(8);
    //    list.Add(7);
    //    list.Add(6);
    //    list.Add(5);
    //    list.Add(4);
    //    //for (int i = 0; i < list._Count; i++)
    //    //{
    //    //    Console.WriteLine("원소 출력 {0}", list[i]);
    //    //}

    //    //Console.WriteLine("저장 갯수 출력 {0}", list._Count);
    //    ////list[0] = 1;
    //    ////list[1] = 3;
    //    ////list[2] = 5;
    //    //for (int i = 0; i < list._Count; i++)
    //    //{
    //    //    Console.WriteLine("삽입 테스트 원소 출력 2 {0}", list[i]);
    //    //}


    //    //Console.WriteLine("삭제 테스트");

    //    //Console.WriteLine("검색 테스트 {0}", list.Find(24));

    //    //list.RemoveAt(list.Find(24));
    //    //list.RemoveAt(list.Find(11));
    //    //list.RemoveAt(list.Find(13));
    //    //for (int i = 0; i < list._Count; i++)
    //    //{
    //    //    Console.WriteLine("삭제 테스트 원소 출력 2 {0}", list[i]);
    //    //}
    //    list.Add(3);
    //    list.Add(2);
    //    list.Add(1);
    //   // list.Add(0);

    //    for (int i = 0; i < list._Count; i++)
    //    {
    //        Console.WriteLine(i + "정렬 전  원소 출력 2 {0}", list[i]);
    //    }

    //    list.InsertionSort();
    //    Console.WriteLine("정렬 테스트"+list._Count);
    //    for (int i = 0; i < list._Count; i++)
    //    {
    //        Console.WriteLine(i+"정렬 후 원소 출력 2 {0}", list[i]);
    //    }

    //    list.Clean();


    //}


    //private void NeuralNetworkTest()
    //{
    //    Console.WriteLine("인공 신경망!");

    //    AI.NuRONetwork.NeuralNetwork neuralNetwork = new AI.NuRONetwork.NeuralNetwork();

    //    for (int i = 0; i < 9; i++)
    //    {
    //        float F;
    //        F = neuralNetwork.feedForward(i);
    //        Console.WriteLine("입력값  :: {0} , 출력값 :: {1}", i, F);
    //    }


    //}
    //    private void SortTest()
    //    {
    //        int[] NonSortData = new int[10];
    //        Random rand = new Random();

    //        for (int i = 0; i < NonSortData.Length; i++)
    //        {
    //            int _RandData = rand.Next(0, 1000);
    //            NonSortData[i] = _RandData;
    //        }
    //        Console.WriteLine("정렬전");
    //        for (int i = 0; i < NonSortData.Length; i++)
    //        {
    //            //Console.WriteLine(" i = " + i + " Data = " + NonSortData[i]);
    //            Console.WriteLine(" i = {0} Data = {1}", i, NonSortData[i]);
    //        }

    //        JeongSort sorts = new JeongSort();
    //        sorts.QuickSort(ref NonSortData);


    //        Console.WriteLine("정렬후");
    //        for (int i = 0; i < NonSortData.Length; i++)
    //        {
    //            //Console.WriteLine(" i = " + i + " Data = " + NonSortData[i]);
    //            Console.WriteLine(" i = {0} Data = {1}", i, NonSortData[i]);
    //        }
    //        Console.WriteLine("Hello World!");

    //        Stack<int> da = new Stack<int>();
    //        Console.WriteLine("ddddd + " + da.EmpTy());
    //        da.Push(1);
    //        Console.WriteLine("ddddd + " + da.EmpTy());

    //    }
    //}




}
