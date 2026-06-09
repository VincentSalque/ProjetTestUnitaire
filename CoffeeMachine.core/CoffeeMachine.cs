namespace CoffeeMachine.core;

public class CoffeeMachine
{
    public const ushort CoffeePrice = 40;

    public void InsertCoin(ushort amount){
        if(amount >= CoffeePrice)
        {
            CoffeeServedAmount = (ushort)(amount / CoffeePrice);
            CollectedMoneyInCents = (ushort)(CoffeeServedAmount * CoffeePrice);
            CashbackAmountInCents = (ushort)(amount - (CoffeeServedAmount * CoffeePrice));
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
