namespace CoffeeMachine.core;

public class CoffeeMachine
{
    public void InsertCoin(ushort amount){
        CoffeeServedAmount = 1;
        CollectedAmountInCents = amount;
        CashbackAmountInCents = 1;
    }

    public ushort CoffeeServedAmount {get; private set;}
    public ushort CollectedAmountInCents { get; private set; }
    public ushort CashbackAmountInCents { get; private set; }
}
