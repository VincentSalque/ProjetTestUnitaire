using Hardware;

namespace MachineACafé.Test.Utilities;

internal class ChangeMachineFake : IChangeMachine
{
    private Action<CoinCode>? _callback = null;
    public void RegisterMoneyInsertedCallback(Action<CoinCode> callback)
    {
        if (_callback != null) throw new NotSupportedException("A callback has already been registered.");
        _callback = callback;
    }

    public void FlushStoredMoney()
    {
    }

    public void CollectStoredMoney()
    {
    }

    public bool DropCashback(CoinCode coinCode)
    {
        return false;
    }

    public void SimulerInsertionPièce(CoinCode fiftyCents)
    {
        if (_callback is null) throw new InvalidOperationException("No callback has been registered to handle money insertion.");
        _callback(fiftyCents);
    }
}