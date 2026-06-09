namespace CoffeeMachine.core;

public class CoffeeMachine
{
    private ushort coffeePrice = 40;

    public void InsertCoin(ushort amount){
        CoffeeServedAmount = 1;
        CollectedAmountInCents = coffeePrice;
        CashbackAmountInCents = (ushort)(amount - coffeePrice);
    }

    public ushort CoffeeServedAmount {get; private set;}
    public ushort CollectedAmountInCents { get; private set; }
    public ushort CashbackAmountInCents { get; private set; }
}
