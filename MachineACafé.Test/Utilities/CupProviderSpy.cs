using Hardware;

namespace MachineACafé.Test.Utilities;

public class CupProviderSpy : ICupProvider
{
    private bool _isCupPresent;
    public ushort provideCupInvocations { get; private set; }
    public ushort isCupPresentInvocations { get; private set; }

    public CupProviderSpy(bool tassePresente)
    {
        _isCupPresent = tassePresente;
        provideCupInvocations = 0;
        isCupPresentInvocations = 0;
    }

    public void ProvideStirrer()
    {
        throw new NotImplementedException();
    }

    public bool IsCupPresent()
    {
        isCupPresentInvocations++;
        return _isCupPresent;
    }

    public void ProvideCup()
    {
        _isCupPresent = true;
        provideCupInvocations++;
    }


}
