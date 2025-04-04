class Running : Activity
{
    private double distance; // in km

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / minutes) * 60;
    public override double GetPace() => minutes / distance;
}
