using System;

namespace XUnitAndFluentAssertionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = new Hello("John", "Doe");
            Console.WriteLine(hello.HelloMan());
            Console.ReadLine();
        }
    }
}
