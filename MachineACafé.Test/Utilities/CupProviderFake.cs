using Hardware;

namespace MachineACafé.Test.Utilities;

public class CupProviderFake : ICupProvider
{
    private bool _isCupPresent;

    public CupProviderFake(bool tassePresente)
    {
        _isCupPresent = tassePresente;
    }

    public void ProvideStirrer()
    {
        throw new NotImplementedException();
    }

    public bool IsCupPresent()
    {
        return _isCupPresent;
    }

    public void ProvideCup()
    {
        _isCupPresent = true;
    }


}
