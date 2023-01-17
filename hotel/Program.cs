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

            Membership memberBob = new Membership("Ordinary", 50);
            DateTime startDateBob = new DateTime(2022, 12, 25, 00, 00, 00);
            DateTime endDateBob = new DateTime(2022, 12, 31, 00, 00, 00);
            Stay stayBob = new Stay(startDateBob, endDateBob);

            Membership memberCody = new Membership("Silver", 190);
            DateTime startDateCody = new DateTime(2023, 12, 26, 00, 00, 00);
            DateTime endDateCody = new DateTime(2022, 12, 31, 00, 00, 00);
            Stay stayCody = new Stay(startDateCody, endDateCody);

            Membership memberDaniel = new Membership("Silver", 120);
            DateTime startDateDaniel = new DateTime(2023, 01, 17, 00, 00, 00);
            DateTime endDateDaniel = new DateTime(2023, 01, 20, 00, 00, 00);
            Stay stayDaniel = new Stay(startDateDaniel, endDateDaniel);

            Membership memberEdda = new Membership("Gold", 10);
            DateTime startDateEdda = new DateTime(2023, 01, 16, 00, 00, 00);
            DateTime endDateEdda = new DateTime(2023, 01, 22, 00, 00, 00);
            Stay stayEdda = new Stay(startDateEdda, endDateEdda);

            Membership memberFelix = new Membership("Gold", 220);
            DateTime startDateFelix = new DateTime(2023, 01, 17, 00, 00, 00);
            DateTime endDateFelix = new DateTime(2023, 01, 25, 00, 00, 00);
            Stay stayFelix = new Stay(startDateFelix, endDateFelix);

            Guest Amelia = new Guest("Amelia", "S1234567A", stayAmelia, memberAmelia);
            Guest Bob = new Guest("Bob", "G1234567A", stayBob, memberBob);
            Guest Cody = new Guest("Cody", "G2345678A", stayCody, memberCody);
            Guest Daniel = new Guest("Daniel", "S1122334B", stayDaniel, memberDaniel);
            Guest Edda = new Guest("Edda", "S3456789A", stayEdda, memberEdda);
            Guest Felix = new Guest("Felix", "A2233445C", stayFelix, memberFelix);
                Console.WriteLine("Hello");
            // namespace.classname 
                Printer.HelloWorld obj = new Printer.HelloWorld();

                obj.printThis();
            // }
        }
    }
}
