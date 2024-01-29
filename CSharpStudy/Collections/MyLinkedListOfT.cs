using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Prev;

        public Node(T value) => Value = value; // 생성자. 노드를 만들 때 value 세팅.
    }
    internal class MyLinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public Node<T> First => _first;
        public Node<T> Last => _last;

        private Node<T> _first, _last, _tmp;
        
        public void AddFirst(T value)
        {
            _tmp = new Node<T>(value);

            if (_first != null)
            {
                _tmp.Next = _tmp;
                _first.Prev = _tmp;
            }
            else
            {
                _last = _tmp;
            }

            _first = _tmp;
        }

        public void AddLast(T value)
        {
            _tmp = new Node<T>(value);
            
            if (_last != null)
            {
                _last.Next = _tmp;
                _tmp.Prev = _last;
            }
            else
            {
                _first = _tmp;
            }

            _last = _tmp;
        }

        public void AddBefore(Node<T> node, T value)
        {
            _tmp = new Node<T>(value);

            if (node.Prev != null)
            {
                node.Prev.Next = _tmp;
                _tmp.Prev = node.Prev;
            }
            else
            {
                _first = _tmp;
            }

            node.Prev = _tmp;
            _tmp.Next = node;
        }

        public void AddAfter(Node<T> node, T value)
        {
            _tmp = new Node<T>(value);

            if (node.Next != null)
            {
                node.Next.Prev = _tmp;
                _tmp.Next = node.Next;
            }
            else
            {
                _last = _tmp;
            }

            node.Next = _tmp;
            _tmp.Prev = node;
        }

        public Node<T> Find(T target)
        {
            _tmp = _first;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, target) == 0)
                    return _tmp;
                
                _tmp = _tmp.Next;
            }

            return null;
        }
        
        public Node<T> FindLast(T target)
        {
            _tmp = _last;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, target) == 0)
                    return _tmp;
                
                _tmp = _tmp.Prev;
            }

            return null;
        }

        public Node<T> Find(Predicate<T> match)
        {
            _tmp = _first;
            while (_tmp != null)
            {
                if (match.Invoke(_tmp.Value))
                    return _tmp;
                
                _tmp = _tmp.Next;
            }

            return null;
        }
        
        // 마지막부터 시작해서 순회
        public Node<T> FindLast(Predicate<T> match)
        {
            _tmp = _last;
            while (_tmp != null)
            {
                if (match.Invoke(_tmp.Value))
                    return _tmp;
                
                _tmp = _tmp.Prev;
            }

            return null;
        }

        public bool Remove(Node<T> node)
        {
            if (node == null)
                return false;
            
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else // 삭제하려는 노드가 first일 경우 (이전 노드가 없으므로.)
            {
                _first = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else // 삭제하려는 노드가 last일 경우 (다음 노드가 없으므로.)
            {
                _last = node.Prev;
            }

            return true;
        }

        public bool Remove(T value)
        {
            return Remove(Find(value));
        }
        public bool Removelast(T value)
        {
            return Remove(FindLast(value));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
        
        public struct Enumerator : IEnumerator<T>
        {
            public T Current => _currentNode.Value;
            object IEnumerator.Current => _currentNode.Value;

            private MyLinkedList<T> _linkedList;
            private Node<T> _currentNode;
            
            public Enumerator(MyLinkedList<T> linkedList)
            {
                _linkedList = linkedList;
                _currentNode = null;
            }

            public void Dispose()
            {
                // TODO 관리되는 리소스를 여기에 릴리스
            }

            public bool MoveNext()
            {
                if (_currentNode == null)
                {
                    _currentNode = _linkedList._first;
                }
                else
                {
                    _currentNode = _currentNode.Next;
                }

                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = null;
            }


        }
    }
}
