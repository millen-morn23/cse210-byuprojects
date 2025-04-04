class Swimming : Activity
{
    private int laps;
    private const double lapDistance = 50.0 / 1000; // 50 meters per lap in km

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * lapDistance;
    public override double GetSpeed() => (GetDistance() / minutes) * 60;
    public override double GetPace() => minutes / GetDistance();
}
