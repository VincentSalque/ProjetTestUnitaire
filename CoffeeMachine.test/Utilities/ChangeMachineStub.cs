using CoffeeMachine.hardware;

public class ChangeMachineStub : IChangeMachine
{
    public void CollectStoredMoney()
    {
    }

    public bool DropCashback(CoinCode coinCode)
    {
        return false;
    }

    public void FlushStoredMoney()
    {
    }

    public void RegisterMoneyInsertedCallback(Action<CoinCode> callback)
    {
    }
}