using Hardware;

namespace MachineACafé;

public class SoftwareMachine
{
    private readonly IBrewer _brewer;
    private readonly IChangeMachine _changeMachine;

    private readonly ICupProvider _cupProvider;

    public SoftwareMachine(IBrewer brewer, IChangeMachine changeMachine, ICupProvider cupProvider)
    {
        _brewer = brewer;
        _changeMachine = changeMachine;
        _changeMachine.RegisterMoneyInsertedCallback(coin => Insérer(new Coin((ushort) coin)));
        _cupProvider = cupProvider;
    }

    private void Insérer(Coin somme)
    {
        if (somme.ValueInCents < 40)
        {
            _changeMachine.FlushStoredMoney();
            return;
        }

        try
        {
            while (!_cupProvider.IsCupPresent())
            {
                _cupProvider.ProvideCup();
            }
            _brewer.MakeACoffee();
            _changeMachine.CollectStoredMoney();
        }
        catch
        {
            _changeMachine.FlushStoredMoney();
        }
    }
}