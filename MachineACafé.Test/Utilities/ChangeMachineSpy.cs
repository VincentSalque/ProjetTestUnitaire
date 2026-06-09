using Hardware;
namespace Utilities;

internal class MachineACaféSpy : IChangeMachine 
{

    public ushort flushStoredMoneyCalled { get; private set; }
    public ushort collectStoredMoneyCalled { get; private set; }
    private IChangeMachine _spy;


    //Constructeur qui prend en paramètre une instance de IChangeMachine à laquelle il délègue les appels
    public MachineACaféSpy(IChangeMachine spy)
    {
        _spy = spy;
    }

    public void RegisterMoneyInsertedCallback(Action<CoinCode> callback)
    {
        _spy.RegisterMoneyInsertedCallback(callback);
    }

    public void FlushStoredMoney()
    {
        flushStoredMoneyCalled++;
        _spy.FlushStoredMoney();
    }
    
    public void CollectStoredMoney()
    {
        collectStoredMoneyCalled++;
        _spy.CollectStoredMoney();
    }

    public bool DropCashback(CoinCode coinCode)
    {
        return _spy.DropCashback(coinCode);
    }
}