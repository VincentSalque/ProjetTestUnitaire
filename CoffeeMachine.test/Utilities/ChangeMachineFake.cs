using CoffeeMachine.hardware;

namespace CoffeeMachine.test;

public class ChangeMachineFake : IChangeMachine
{
    private Action<CoinCode>? callback;

    public void RegisterMoneyInsertedCallback(Action<CoinCode> callback)
    {
        if (this.callback != null) throw new NotSupportedException();
        this.callback = callback;
    }

    public void FlushStoredMoney()
    {
    }

    public void CollectStoredMoney()
    {
    }

    public bool DropCashback(CoinCode coinCode)
    {
        throw new NotImplementedException();
    }

    public void FakeInsertCoin(CoinCode code)
    {
        this.callback?.Invoke(code);
    }
}