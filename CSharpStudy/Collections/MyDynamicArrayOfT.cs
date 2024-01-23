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
                         // (new 키워드를 쓰지 않아도 자동으로 숨겨준다. 명시하기 위해 작성)
    
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
        where T : IComparable<T>
    {
        private static int DEFAULT_SIZE = 1;
        
        public int Count => _count;
        public int Capacity => _items.Length;

        private T[] _items = new T[DEFAULT_SIZE];
        private int _count;

        // 삽입 알고리즘
        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                T[] tmpItems = new T[_count * 2];
                Array.Copy(_items, 0, tmpItems, 0, _count);
                _items = tmpItems;
            }

            _items[_count++] = item;
        }
        
        // 탐색 알고리즘
        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Comparer<T>.Default.Compare(_items[i], item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        // 삭제 알고리즘
        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            for (int i = index; i < _count; i++)
            {
                _items[i] = _items[i + 1];
            }

            _count--;
            return true;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            public bool MoveNext()
            {
                _index++;
                return _index < _data._count;
            }

            public void Reset()
            {
                _index = -1;
            }

            public T Current => _data._items[_index];

            object IEnumerator.Current => _data._items[_index];

            private MyDynamicArray<T> _data;
            private int _index;
            public Enumerator(MyDynamicArray<T> data)
            {
                _data = data;
                _index = -1; // MoveNext()를 먼저 호출하기 때문에 -1로 초기화;
            }

            public void Dispose() // 관리되지 않는 힙 영역(Unmanagerd Heap Memory) 에 올라간 데이터는 직접 해제를 해줘야 한다.
                                  // 관리되는 힙 영역(Managed Heap Memory)에 올라간 데이터는 GC가 관리해준다.
            {
                throw new NotImplementedException();
            }
        }
    }
}