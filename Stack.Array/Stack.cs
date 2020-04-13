using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_Array
{
    public class Stack<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        int _size;
        public void Push(T item)
        {
            if(_size == _items.Length)
            {
                int _newlength = _size == 0 ? 4 : _size * 2;
                T[] newarray = new T[_newlength];
                _items.CopyTo(newarray, 0);
                _items = newarray;
            }
            _items[_size] = item;
            _size++;
        }
        public T Pop()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            T value = _items[--_size];
            return value;
        }
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            T value = _items[_size - 1];
            return value;
        }
        public int Count
        {
            get
            {
                return _size;
            }
        }
        public void Clear()
        {
            _size = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
