using System;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {

            var t1 = LinqTasks.Task10();

            foreach (object o in t1)
            {
                Console.WriteLine(o);
            }
        }

    }
}
