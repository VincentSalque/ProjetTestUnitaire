using CoffeeMachine.core;

public class BrewerDummy : IBrewer
{
    public bool MakeACoffee()
    {
        throw new Exception("Defective");
    }

    public bool PourChocolate()
    {
        throw new Exception("Defective");
    }

    public bool PourMilk()
    {
        throw new Exception("Defective");
    }

    public bool PourSugar()
    {
        throw new Exception("Defective");
    }

    public bool PourWater()
    {
        throw new Exception("Defective");
    }

    public bool TryPullWater()
    {
        throw new Exception("Defective");
    }
}