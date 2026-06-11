using CoffeeMachine.hardware;

namespace CoffeeMachine.software;

public class CoffeeMachine
{
    public const ushort CoffeePrice = 40;

    private IBrewer brewer;
    private IChangeMachine changeMachine;

    public CoffeeMachine(IBrewer brewer, IChangeMachine changeMachine)
    {
        this.brewer = brewer;
        this.changeMachine = changeMachine;
        this.changeMachine.RegisterMoneyInsertedCallback(coin => InsertCoin(new Coin((ushort) coin)));
    }

    public void InsertCoin(Coin coin){
        if(coin.Value >= CoffeePrice)
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
