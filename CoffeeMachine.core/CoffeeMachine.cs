namespace CoffeeMachine.core;

public class CoffeeMachine
{
    public void InsertCoin(ushort amount){
        CoffeeServedAmount = 1;
    }

    public ushort CoffeeServedAmount {get; private set;}
}
