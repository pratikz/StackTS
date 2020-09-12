using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_TS
{
    class Program
    {
        //Thread safe stack
        static void Main(string[] args)
        {            
            StackTS<int>.Push(1);
            StackTS<int>.Push(2);
            StackTS<int>.Push(3);
            Console.WriteLine(StackTS<int>.Peek());
            StackTS<int>.Pop();
            Console.WriteLine(StackTS<int>.Peek());
            Console.ReadKey();
        }

        public static class StackTS<T>
        {
            private static Stack<T> _stack = new Stack<T>();

            private static object _check = new object();
          
           public static void Push(T val)
            {
                lock (_check)
                {
                    _stack.Push(val);
                }
            }
            public static void Pop()
            {
                lock(_check)
                {
                     _stack.Pop();
                }
            }
            public static T Peek()
            {
                lock(_check)
                {
                    return _stack.Peek();
                }
            }
            
        }
    }
}
