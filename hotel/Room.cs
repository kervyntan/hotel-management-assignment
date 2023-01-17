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

    public int getRoomNumber () {
        return this.roomNumber;
    }

    public string getBedConfiguration () {
        return this.bedConfiguration;
    }

    public double getDailyRate () {
        return this.dailyRate;
    }

    public bool getIsAvail () {
        return this.isAvail;
    }
    
    public double CalculateCharges () {
        return 1.0;
    } 

}