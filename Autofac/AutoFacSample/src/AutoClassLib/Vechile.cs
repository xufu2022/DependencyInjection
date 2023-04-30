namespace AutoClassLib;

public interface IVehicle
{
    void Go();
}

public class Truck : IVehicle
{
    private IDriver driver;

    public Truck(IDriver driver)
    {
        if (driver == null)
        {
            throw new ArgumentNullException(paramName: nameof(driver));
        }
        this.driver = driver;
    }

    public void Go()
    {
        driver.Drive();
    }
}

public interface IDriver
{
    void Drive();
}

public class CrazyDriver : IDriver
{
    public void Drive()
    {
        Console.WriteLine("Going too fast and crashing into a tree");
    }
}

public class SaneDriver : IDriver
{
    public void Drive()
    {
        Console.WriteLine("Driving safely to destination");
    }
}