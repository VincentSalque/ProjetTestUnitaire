namespace CoffeeMachine.core;

public class CoffeeMachine
{
    public void InsertCoin(ushort amount){
        CoffeeServedAmount = 1;
        CollectedAmountInCents = amount;
    }

    public ushort CoffeeServedAmount {get; private set;}
    public ushort CollectedAmountInCents { get; private set; }
}
