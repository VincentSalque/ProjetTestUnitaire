using Hardware;

namespace MachineACafé.Test.Utilities;

public class CupProviderSpy : ICupProvider
{
    private bool _isCupPresent;
    private int _provideCupCall;
    private int _isCupPresentCall;

    public CupProviderSpy(bool tassePresente)
    {
        _isCupPresent = tassePresente;
        _provideCupCall = 0;
        _isCupPresentCall = 0;
    }

    public void ProvideStirrer()
    {
        throw new NotImplementedException();
    }

    public bool IsCupPresent()
    {
        _isCupPresentCall++;
        return _isCupPresent;
    }

    public void ProvideCup()
    {
        _isCupPresent = true;
        _provideCupCall++;
    }


}
