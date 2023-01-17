// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("The current time is: " + DateTime.Now);

using System;

namespace MainProgram {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine("Hello");
            // namespace.classname 
            Printer.HelloWorld obj = new Printer.HelloWorld();

            obj.printThis();
        }
    }
}
