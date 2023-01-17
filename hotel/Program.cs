// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("The current time is: " + DateTime.Now);

using System;
using System.IO;

namespace MainProgram {
    class Program {
        static void Main (string[] args) {
            // using(var reader = new StreamReader("./Guests.csv")) {
            //     List<string> listA = new List<string>();
            //     List<string> listB = new List<string>();
            //     while (!reader.EndOfStream) {
            //         var line = reader.ReadLine();
            //         var values = line.Split(";");

            //         listA.Add(values[0]);
            //         listB.Add(values[1]);
            //     }
            //     Console.WriteLine(listA);
            Membership memberAmelia = new Membership("Gold", 280);
            DateTime startDateAmelia = new DateTime(2022, 11, 15, 00, 00, 00);
            DateTime endDateAmelia = new DateTime(2022, 11, 20, 00, 00, 00);
            Stay stayAmelia = new Stay(startDateAmelia, endDateAmelia);
            Guest Amelia = new Guest("Amelia", "S1234567A", stayAmelia, memberAmelia);
                Console.WriteLine("Hello");
            // namespace.classname 
                Printer.HelloWorld obj = new Printer.HelloWorld();

                obj.printThis();
            // }
        }
    }
}
