// See https://aka.ms/new-console-template for more information
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
            // Initialise the list of guests
            this.GuestsList = new List<Guest>();
        }

            static void Main (string[] args) {
            // Read from the csv
            // Then print 

            //
            Program programObj = new Program();
            using (var readerGuest = new StreamReader("./Guests.csv"))
            using (var readerStays = new StreamReader("./Stays.csv"))
            using (var csvGuest = new CsvReader(readerGuest, CultureInfo.InvariantCulture))
            {
                using (var csvStays = new CsvReader(readerStays, CultureInfo.InvariantCulture)) {
                    var recordsGuest = csvGuest.GetRecords<DataModel>().ToList();
                    var recordsStays = csvStays.GetRecords<StayDataModel>().ToList();
                    for (int i = 0; i < recordsGuest.Count; i++) {

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
            // Prompt user for choice
            string val = programObj.menuPrompt();
            switch(val) {
                case "0":
                    break;
                case "1":
                    programObj.listGuests(programObj.GuestsList);
                    break;
                case "2":
                    programObj.listRooms();
                    break;
                case "3":
                    programObj.registerGuest();
                    break;
                case "4":
                    programObj.checkInGuest(programObj.GuestsList);
                    break;
                case "5":
                    programObj.getStayDetails(programObj.GuestsList);
                    break;
                case "6":
                    programObj.extendStay(programObj.GuestsList);
                    break;
                
                // If user types in wrong input
                default:
                    Console.WriteLine("Please pick a correct option");
                    // val = programObj.menuPrompt();
                    break;
            }
            // Need to update room availability based on the existing 
            // rooms taken up by the existing guests,
            // store them in an object/list
            // programObj.listGuests(programObj.GuestsList);
            // programObj.getStayDetails(programObj.GuestsList);
            // programObj.registerGuest();
            // programObj.extendStay(programObj.GuestsList);
            // programObj.listRooms();
            // programObj.checkInGuest(programObj.GuestsList);
        }
        public string menuPrompt () {
            Console.WriteLine("MENU");
            Console.WriteLine("=====");
            Console.WriteLine("1. List all guests");
            Console.WriteLine("2. List all available rooms");
            Console.WriteLine("3. Register Guest");
            Console.WriteLine("4. Check-in Guest");
            Console.WriteLine("5. Display stay details of a guest");
            Console.WriteLine("6. Extend stay by number of days");
            Console.WriteLine("0. Exit");
            string choice = Console.ReadLine();
            return choice;
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

        public void listRooms () {
            using (var reader = new StreamReader("./Rooms.csv"))
            using (var csvRooms= new CsvReader(reader, CultureInfo.InvariantCulture)) {
                var record = new RoomsModel();
                var records = csvRooms.EnumerateRecords(record);
                int index = 0; 
                Console.WriteLine("RoomType " + "RoomNumber " + "BedConfiguration " + "DailyRate ");
                foreach (var r in records)
                {   
                    Console.Write(index + ". ");
                    Console.Write(r.RoomType + " ");
                    Console.Write(r.RoomNumber + " ");
                    Console.Write(r.BedConfiguration + " ");
                    Console.Write(r.DailyRate + " ");
                    Console.WriteLine();
                    index++;
                }
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

        public void checkInGuest (List<Guest> GuestsList) {
            for (int i = 0; i < GuestsList.Count; i++) {
                Console.WriteLine("" + i + ". " + GuestsList[i].getName());
            }

            Console.WriteLine("Select a guest's index: ");
            string chosenGuest = Console.ReadLine();

            Console.WriteLine("Enter check in date: eg. 31/12/2022");
            string strStartDate = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(strStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Enter check out date: eg. 31/12/2022");
            string strEndDate = Console.ReadLine();
            DateTime endDate = DateTime.ParseExact(strEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Created stay object
            Stay stay = new Stay(startDate, endDate);

            this.listRooms();
            Console.WriteLine("");
            Console.WriteLine("Please pick a room: eg. Standard / Deluxe");
            string roomType = Console.ReadLine();

            bool wifi = false;
            bool breakfast = false;
            bool additionalBed = false;
            if (roomType == "Standard") {
                Console.WriteLine("Require Wifi?: ");
                string isWifi = Console.ReadLine();
            
                if (isWifi != "no" || isWifi != "n") {
                    wifi = true;
                } 

                Console.WriteLine("Require Breakfast?: ");
                string isBreakfast = Console.ReadLine();

                if (isBreakfast != "no" || isBreakfast != "n") {
                    breakfast = true;
                }

                StandardRoom standardRoom = new StandardRoom(wifi, breakfast);

            } else if (roomType == "Deluxe") {
                Console.WriteLine("Additional Bed?: ");
                string isAdditionalBed = Console.ReadLine();

                if (isAdditionalBed != "no" || isAdditionalBed != "n") {
                    additionalBed = true;
                }

                DeluxeRoom deluxeRoom = new DeluxeRoom(additionalBed);
            }




        }

        public void getStayDetails (List<Guest> GuestsList) {
            for (int i = 0; i < GuestsList.Count; i++) {
                Console.WriteLine("" + i + ". " + GuestsList[i].getName());
            }

            Console.WriteLine("Enter a guest's index: ");
            string chosenGuest = Console.ReadLine();
            if (Int16.Parse(chosenGuest) >= 0 && Int16.Parse(chosenGuest) <= GuestsList.Count - 1) {
                Console.WriteLine("Stay Details: ");
                Console.WriteLine("Check-in Date: " + GuestsList[Int16.Parse(chosenGuest)].getHotelStay().getCheckInDate().ToString("dd/MM/yyyy"));
                Console.WriteLine("Check-out Date: " + GuestsList[Int16.Parse(chosenGuest)].getHotelStay().getCheckOutDate().ToString("dd/MM/yyyy"));
            } else {
                Console.WriteLine("Please pick a correct index: ");
                chosenGuest = Console.ReadLine();
            }
        }

        public void extendStay (List<Guest> GuestsList) {
            // Need to update the csv also for the Stays.csv

            using (var reader = new StreamReader("./Stays.csv")) 
            using (var csvStays = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                var records = csvStays.GetRecords<Guest>().ToList();
                for (int i = 0; i < GuestsList.Count; i++) {
                    Console.WriteLine("" + i + ". " + GuestsList[i].getName());
                }

                Console.WriteLine("Enter a guest's index: ");
                string chosenStaff = Console.ReadLine();
                if (Int16.Parse(chosenStaff) >= 0 && Int16.Parse(chosenStaff) <= GuestsList.Count - 1) {
                    if (GuestsList[Int16.Parse(chosenStaff)].getHotelStay().getCheckInDate() != null) {
                        Console.WriteLine("How many days would you like to extend by? :");
                        string daysToExtend = Console.ReadLine();
                        DateTime currentCheckOutDate = GuestsList[Int16.Parse(chosenStaff)].getHotelStay().getCheckOutDate();
                        GuestsList[Int16.Parse(chosenStaff)].getHotelStay().setCheckOutDate(currentCheckOutDate.AddDays(Int16.Parse(daysToExtend)));

                            // using (var stream = File.Open("./Guests.csv", FileMode.Append))
                            // using (var writer = new StreamWriter(stream))
                            // using (var csv = new CsvWriter(writer, config)) {
                            //     csv.WriteRecords(records);
                            // }
                        Console.WriteLine("Check out extended. Have a nice day!");
                    } else {
                        Console.WriteLine("Guest selected has not checked in. Please select any Guest. ");
                        chosenStaff = Console.ReadLine();
                    }
                    Console.WriteLine("Stay Details: ");
                    Console.WriteLine("Check-in Date: " + GuestsList[Int16.Parse(chosenStaff)].getHotelStay().getCheckInDate().ToString("dd/MM/yyyy"));
                    Console.WriteLine("Check-out Date: " + GuestsList[Int16.Parse(chosenStaff)].getHotelStay().getCheckOutDate().ToString("dd/MM/yyyy"));
                } else {
                    Console.WriteLine("Please pick a correct index: ");
                    chosenStaff = Console.ReadLine();
                }
            }
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

    class RoomsModel {
        public string RoomType {get; set;}
        public int RoomNumber {get; set;}
        public string BedConfiguration {get; set;}
        public int DailyRate {get; set;}
    }
}
