using System.Collections.Generic;
using System.Collections;
using System;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MyDynamicArray

            MyDynamicArray myDynamicArray = new MyDynamicArray();
            myDynamicArray.Add(3);
            myDynamicArray.Add(4);
            myDynamicArray.Add(5);
            myDynamicArray.Add(6);

            IEnumerator e1 = myDynamicArray.GetEnumerator();

            while (e1.MoveNext())
            {
                Console.WriteLine(e1.Current);
            }

            #endregion

            #region MyDynamicArrayOfT

            MyDynamicArray<int> intDArray = new MyDynamicArray<int>();
            intDArray.Add(1);
            intDArray.Add(2);
            intDArray.Add(3);
            intDArray.Add(4);

            Console.WriteLine(intDArray[0]); // 인덱서 프로퍼티를 구현해야 인덱스 접근이 가능하다.

            IEnumerator<int> intDArrayEnum = intDArray.GetEnumerator();

            while (intDArrayEnum.MoveNext())
            {
                Console.WriteLine(intDArrayEnum.Current);
            }

            intDArrayEnum.Reset();
            intDArrayEnum.Dispose();

            // IDisposable 객체의 Dispose() 함수의 호출을 보장하는 구문.
            using (IEnumerator<int> intDArrayEnum2 = intDArray.GetEnumerator())
            {
                while (intDArrayEnum.MoveNext())
                {
                    Console.WriteLine(intDArrayEnum.Current);
                }

                intDArrayEnum.Reset();
            }

            // foreach 문
            // IEnumerable을 순회하는 구문
            foreach (int item in intDArray)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region ArrayList

            // non-generic 동적 배열
            ArrayList arrayList = new ArrayList();

            arrayList.Add(3);
            arrayList.Add("Carl");
            arrayList.Contains(3); // false 출력. 위의 Add(3) 함수 호출로 할당된 객체와 다른 객체이기 때문이다.

            #endregion

            #region List

            // generic 동적 배열
            List<int> list = new List<int>();

            list.Add(1);
            list.Remove(3);
            list.IndexOf(3);
            list.Contains(3);
            list.Find(x => x > 1);
            list.Insert(0, 2);

            #endregion

            #region HashSet

            HashSet<int> visited = new HashSet<int>();
            visited.Add(3); // 중복을 허용하지 않는 자료구조기에, 3이 이미 존재한다면 false를 반환.

            #endregion

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
        }
    }
}