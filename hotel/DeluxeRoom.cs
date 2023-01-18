class DeluxeRoom : Room {

    private bool additionalBed;

    public DeluxeRoom(){

    }

    public DeluxeRoom (bool additionalBed) : base(roomNumber, bedConfiguration, dailyRate, isAvail) {
        this.additionalBed = additionalBed;
    }

    public double CalculateCharges () {
        return 1.0;
    }
}