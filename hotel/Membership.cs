class Membership {
    private string status;
    private int points;

    public Membership () {

    }

    public Membership (string status, int points) {
        this.status = status;
        this.points = points;
    }

    public void EarnPoints (double points) {

    }

    public bool RedeemPoints (int points) {
        return true;
    }

    public string getStatus () {
        return this.status;
    }

    public int getPoints () {
        return this.points;
    }

}