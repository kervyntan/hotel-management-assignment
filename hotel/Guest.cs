using System;

class Guest {
        private string name;
        private string passportNum;
        private Stay hotelStay;
        private Membership member;
        private bool isCheckedIn;

        public Guest() {

        }
        public Guest (string name, string passportNum, Stay hotelStay, Membership member) {
            this.name = name;
            this.passportNum = passportNum;
            this.hotelStay = hotelStay;
            this.member = member;
        }

        public string getName () {
            return this.name;
        }

        public string getPassportNum () {
            return this.passportNum;
        }

        public Stay getHotelStay () {
            return this.hotelStay;
        }

        public Membership getMembership () {
            return this.member;
        }


}
