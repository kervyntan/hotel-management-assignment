// StandardRoom inherits Room
// Can access fields and methods
class StandardRoom : Room {
    private bool requireWifi;
    private bool requireBreakfast;

    public StandardRoom () {

    }

    public StandardRoom (bool requireWifi, bool requireBreakfast) : base(roomNumber, bedConfiguration, dailyRate, isAvail) {
        this.requireWifi = requireWifi;
        this.requireBreakfast = requireBreakfast;
    }

    public double CalculateCharges () {
        return 1.0;
    }


}