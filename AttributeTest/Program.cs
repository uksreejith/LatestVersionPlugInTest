using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");
            Console.ReadKey();
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class DoSomethingAttribute : Attribute
    {
        public string Name { get; set; }
    }

    [DoSomething]
    public class TestClass
    {
        public int Value { get; set; }
    }
}
