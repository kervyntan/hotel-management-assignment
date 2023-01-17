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


}
