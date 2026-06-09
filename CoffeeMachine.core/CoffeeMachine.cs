namespace CoffeeMachine.core;

public class CoffeeMachine
{
    public const ushort CoffeePrice = 40;

    private IBrewer brewer;
    private IChangeMachine changeMachine;

    public CoffeeMachine(IBrewer brewer, IChangeMachine changeMachine)
    {
        this.brewer = brewer;
        this.changeMachine = changeMachine;
    }

    public void InsertCoin(ushort amount){
        if(amount >= CoffeePrice)
        {
            try
            {
                brewer.MakeACoffee();
                changeMachine.CollectStoredMoney();
            }
            catch
            {
                changeMachine.FlushStoredMoney();
            }
        } else
        {
            changeMachine.FlushStoredMoney();
        }
    }
}
