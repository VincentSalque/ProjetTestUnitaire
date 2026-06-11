using System.Runtime;
using CoffeeMachine.hardware;

public class BrewerSpy : IBrewer
{
    private readonly IBrewer captive;
    public BrewerSpy(){captive = new BrewerStub();}
    public BrewerSpy(IBrewer brewer){captive = brewer;}

    public ushort MakeACoffeeInvocationCount {get; private set;}    

    public bool MakeACoffee()
    {
        MakeACoffeeInvocationCount++;
        return captive.MakeACoffee();
    }

    public bool PourChocolate()
    {
        return captive.PourChocolate();
    }

    public bool PourMilk()
    {
        return captive.PourMilk();
    }

    public bool PourSugar()
    {
        return captive.PourSugar();
    }

    public bool PourWater()
    {
        return captive.PourWater();
    }

    public bool TryPullWater()
    {
        return captive.TryPullWater();
    }
}