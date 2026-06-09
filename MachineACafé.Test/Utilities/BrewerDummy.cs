
using Hardware;
namespace MachineACafé.Test.Utilities;

internal class BrewerDummy : IBrewer
{
    public bool MakeACoffee()
    { 
        throw new Exception("Dummy"); 
    }

    public bool TryPullWater()
    {
        throw new Exception("Dummy");
    }   

    public bool PourMilk()
    {
        throw new Exception("Dummy");
    }

    public bool PourWater()
    {
        throw new Exception("Dummy");
    }

    public bool PourSugar()
    {
        throw new Exception("Dummy");
    }

    public bool PourChocolate()
    {
        throw new Exception("Dummy");
    }

}