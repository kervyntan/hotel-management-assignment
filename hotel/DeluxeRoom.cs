class DeluxeRoom : Room {

    private bool additionalBed;

    public DeluxeRoom(){

    }

    public DeluxeRoom (bool additionalBed) {
        this.additionalBed = additionalBed;
    }

    public double CalculateCharges () {
        return 1.0;
    }
}