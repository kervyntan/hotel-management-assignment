class Room {
    private int roomNumber;
    private string bedConfiguration;
    private double dailyRate;
    private bool isAvail;
    
    public Room () {

    }
    public Room (int roomNumber, string bedConfiguration, double dailyRate, bool isAvail) {
        this.roomNumber = roomNumber;
        this.bedConfiguration = bedConfiguration;
        this.dailyRate = dailyRate;
        this.isAvail = isAvail;
    }

    public double CalculateCharges () {
        return 1.0;
    } 

}