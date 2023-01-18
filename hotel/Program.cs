﻿// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("The current time is: " + DateTime.Now);

using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace MainProgram {
    class Program {
        public List<Guest> GuestsList;

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

            this.GuestsList.Add(newGuest);

            // Guest to be added
            var records = new List<DataModel>(); 
            records.Add(new DataModel() {
                Name = newGuest.getName(),
                PassportNumber = newGuest.getPassportNum(),
                MembershipStatus = newGuest.getMembership().getStatus(),
                MembershipPoints = newGuest.getMembership().getPoints()
            });
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = false,
            };
            // Writing to the csv
            using (var stream = File.Open("./Guests.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config)) {
                csv.WriteRecords(records);
            }

            Console.WriteLine("Guest Added!");
        }
        static void Main (string[] args) {
            // Read from the csv
            // Then print 
            Program programObj = new Program();
            using (var readerGuest = new StreamReader("./Guests.csv"))
            using (var readerStays = new StreamReader("./Stays.csv"))
            using (var csvGuest = new CsvReader(readerGuest, CultureInfo.InvariantCulture))
            {
                using (var csvStays = new CsvReader(readerStays, CultureInfo.InvariantCulture)) {
                    var recordsGuest = csvGuest.GetRecords<DataModel>().ToList();
                    var recordsStays = csvStays.GetRecords<StayDataModel>().ToList();
                    for (int i = 0; i < recordsGuest.Count; i++) {
                        // Console.WriteLine(records[i].MembershipStatus);
                        // Console.WriteLine(recordsGuest[i].MembershipPoints);
                        // Console.WriteLine(recordsStays[i].CheckinDate);
                        Membership member = new Membership(recordsGuest[i].MembershipStatus, recordsGuest[i].MembershipPoints);
                        string passportNum = recordsGuest[i].PassportNumber;
                        string start = recordsStays[i].CheckinDate;
                        string end = recordsStays[i].CheckoutDate;
                        DateTime startDate = DateTime.ParseExact(start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime endDate = DateTime.ParseExact(end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Stay stay = new Stay(startDate, endDate);

                        Guest guest = new Guest(recordsGuest[i].Name, passportNum, stay, member);
                        programObj.GuestsList.Add(guest);

                    } 
                }
            }

            programObj.listGuests(programObj.GuestsList);
            // programObj.registerGuest();
        }
    }

    class DataModel {
        public string Name { get; set; }
        public string PassportNumber {get; set;}
        public string MembershipStatus {get; set;}
        public int MembershipPoints {get; set;}
    }

    class StayDataModel {
        public string? Name {get; set;}
        public string? PassportNumber {get; set;}
        public bool? IsCheckedOut {get; set;} 
        public string? CheckinDate {get; set;}
        public string? CheckoutDate {get; set;}
        public int? RoomNumber {get; set;} 
        public bool? Wifi {get; set;}
        public bool? Breakfast {get; set;} 
        public bool? ExtraBed {get; set;}
    }
}
