using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class MyDynamicArray : IEnumerable
    {
        public int Length => _length; // 아래 get접근자와 동일한 기능을 한다.
        // public int Length
        // {
        //     get
        //     {
        //         return _length;
        //     }
        // }
        public int Capacity => _items.Length; // items의 전체 길이
        
        private object[] _items;
        private int _length; // _items의 아이템 개수

        
        // 삽입 알고리즘
        public void Add(object item)
        {
            if (_length == _items.Length) // 배열 공간이 부족할 시, 더 큰 배열을 만들고 아이템 복제.
            {
                object[] tmpItems = new object[_length * 2];
                Array.Copy(_items, 0, tmpItems, 0, _length);
                _items = tmpItems;
            }
            _items[_length++] = item;
        }

        // 탐색 알고리즘
        public int IndexOf(object item)
        {
            // Comparer.Default : 해당 타입의 default 비교 연산자를 가지고 비교해서 결과를 반환하는 기능을 가진 객체.
            Comparer comparer = Comparer.Default; // object 타입은 Comparer를 통해서 비교를 한다.
            for (int i = 0; i < _length; i++)
            {
                if (comparer.Compare(_items[i], item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
        
        // 삭제 알고리즘
        public bool Remove(object item)
        {
            int index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }
            
            for (int i = index; i < _length - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _length--;
            return true;
        }

        public IEnumerator GetEnumerator() // MoveNext()를 써서 그 다음 yield로 넘길 수 있는 기능을 가진 객체를 반환하는 함수,
        {                                  // 아래 struct Enum과 같은 기능.
            yield return 1;
            yield return 2;
            yield return 3;
            
            // for (int i = 0; i < _length; i++)
            // {
            //     yield return _items[i];
            // }
        }

        // struct Enum : IEnumerable
        // {
        //     public object Current => _current;
        //     
        //     private object _current;
        //     private int _step = -1;
        //
        //     public bool MoveNext()
        //     {
        //         if (_step < 0)
        //         {
        //             _step++;
        //         }
        //
        //         switch (_step)
        //         {
        //             case 0:
        //             {
        //                 _current = 1;
        //                 _step++;
        //                 return true;
        //             }                   
        //             case 1:
        //             {
        //                 _current = 2;
        //                 _step++;
        //                 return true;
        //             }
        //             case 2:
        //             {
        //                 _current = 3;
        //                 _step++;
        //                 return true;
        //             }
        //             default:
        //                 return false;
        //         }
        //     }
        }
    }
}