using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class A
{
    public int name;
    
    public void SayHi()
    {
        Console.WriteLine("A");
    }
}
public class B : A
{
    new public int name; // 여기서 new 키워드는 기반 타입의 멤버를 숨기고, 자식의 것을 쓰겠다는 것.
    
    new public void SayHi()
    {
        Console.WriteLine("B");
    }
}

public class Tester
{
    public void Test()
    {
        A a = new A();
        B b = new B();
        
        a.SayHi(); // -> A 출력
        b.SayHi(); // -> B 출력

        a = b;
        a.SayHi(); // -> A 출력
        ((B)a).SayHi(); // -> B 출력
    }
}

namespace Collections
{
    internal class MyDynamicArray<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}