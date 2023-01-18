using System;

class Stay {
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private List<Room> roomList;

        public Stay() {

        }
        public Stay(DateTime checkInDate, DateTime checkOutDate) {
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
        }

        public void AddRoom (Room room) {

        }

        public DateTime getCheckInDate () {
            return this.checkInDate;
        }

        public DateTime getCheckOutDate () {
            return this.checkOutDate;
        }

        public void setCheckOutDate (DateTime checkOutDate) {
            this.checkOutDate = checkOutDate;
        }
        
        public double CalculateTotal () {
            return 1.0;
        }

}