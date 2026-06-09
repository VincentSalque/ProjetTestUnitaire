namespace CoffeeMachine.core;

public class CoffeeMachine
{
    private ushort coffeePrice = 40;

    public void InsertCoin(ushort amount){
        if(amount >= coffeePrice)
        {
            CoffeeServedAmount = (ushort)(amount / coffeePrice);
            CollectedMoneyInCents = (ushort)(CoffeeServedAmount * coffeePrice);
            CashbackAmountInCents = (ushort)(amount - (CoffeeServedAmount * coffeePrice));
        }
        else
        {
            FlushedMoneyInCents = amount;
        }
    }

    public ushort CoffeeServedAmount {get; private set;}
    public ushort CollectedMoneyInCents { get; private set; }
    public ushort CashbackAmountInCents { get; private set; }
    public ushort FlushedMoneyInCents { get; private set; }
}
