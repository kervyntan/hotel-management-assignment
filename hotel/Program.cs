// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("The current time is: " + DateTime.Now);

using System;
using System.IO;
using System.Collections.Generic;

namespace MainProgram {
    class Program {
        private List<Guest> GuestsList;

        public Program () {
            this.GuestsList = new List<Guest>();
        }

        public void listGuests (List<Guest> GuestsList) {
            // string result = Console.ReadLine();
            // if (Int16.parse(result) > GuestsList.Count || Int16.parse(result) < 0) {
            //     Console.WriteLine("Error, please choose another guest");
            // } 
            Console.WriteLine("Name " + "Passport Number " + "Check-in " + "Check-out " + "Member " + "Points ");
            foreach(Guest g in GuestsList) {
                Console.Write(g.getName() + " ");
                Console.Write(g.getPassportNum() + " ");
                // Convert dates to DD/MM/YY format
                Console.Write(g.getHotelStay().getCheckInDate().ToString("dd/MM/yyyy") + " ");
                Console.Write(g.getHotelStay().getCheckOutDate().ToString("dd/MM/yyyy") + " ");
                Console.Write(g.getMembership().getStatus() + " ");
                Console.Write(g.getMembership().getPoints() + " ");
                Console.WriteLine();
            }
        }

        public void registerGuest () {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter passport number: ");
            string passportNum = Console.ReadLine();
            Membership member = new Membership("Ordinary", 0);
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            Stay stay = new Stay(startDate, endDate);
            Guest newGuest = new Guest(name, passportNum, stay, member);
        }
        static void Main (string[] args) {

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

            // List<Guest> GuestsList = new List<Guest>();\
            Program programObj = new Program();
            programObj.GuestsList.Add(Amelia);
            programObj.GuestsList.Add(Bob);
            programObj.GuestsList.Add(Cody);
            programObj.GuestsList.Add(Daniel);
            programObj.GuestsList.Add(Edda);
            programObj.GuestsList.Add(Felix);

            // Program programObj = new Program();

            programObj.listGuests(programObj.GuestsList);
        }
    }
}
