using CoffeeMachine.core;

public class ChangeMachineSpy : IChangeMachine
{
    private readonly IChangeMachine captive;
    public ChangeMachineSpy(){captive = new ChangeMachineStub();}
    public ChangeMachineSpy(IChangeMachine changeMachine){captive = changeMachine;}

    public ushort CollectStoredMoneyCount {get; private set;}
    public ushort FlushStoredMoneyCount {get; private set;}

    public void CollectStoredMoney()
    {
        CollectStoredMoneyCount++;
        captive.CollectStoredMoney();
    }

    public bool DropCashback(CoinCode coinCode)
    {
        return captive.DropCashback(coinCode);
    }

    public void FlushStoredMoney()
    {
        FlushStoredMoneyCount++;
        captive.FlushStoredMoney();
    }

    public void RegisterMoneyInsertedCallback(Action<CoinCode> callback)
    {
        captive.RegisterMoneyInsertedCallback(callback);
    }
}