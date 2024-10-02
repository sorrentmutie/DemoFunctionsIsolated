using DemoDunctionsIsolated.Interfaces;

namespace DemoDunctionsIsolated.Services;

public class FakeClock : IClock
{
    public DateTime GetNow()
    {
        return new DateTime(2000,1,1);
    }
}

public class SystemClock: IClock
{
    public DateTime GetNow()
    {
        return DateTime.Now;
    }
}
