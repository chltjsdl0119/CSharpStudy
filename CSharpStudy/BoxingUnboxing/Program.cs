using System;

namespace BoxingUnboxing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            object obj1 = new object();
            Object obj2 = new Object();

            obj1 = 1;

            // long long1 = (int)obj1;

            Console.WriteLine(Compare(1, 1));
        }

        // static bool Compare(int a, int b) // true 출력, 객체 메모리의 데이터를 읽어와서 비교한 것.
        // {
        //     return a == b;
        // }
        static bool Compare(object a, object b) // false 출력, 객체 메모리 영역이 같은지 검사한 것.
        {
            return a == b;
        }
    }
}