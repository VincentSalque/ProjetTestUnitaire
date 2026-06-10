using Hardware;

namespace MachineACafé.Test.Utilities;

internal class SoftwareMachineBuilder
{
    private IBrewer _brewer = new BrewerStub();
    private IChangeMachine _changeMachine = new ChangeMachineStub();
    private ICupProvider _cupProvider = new CupProviderFake(true);

    public SoftwareMachine Build()
    {
        return new SoftwareMachine(_brewer, _changeMachine, _cupProvider);
    }

    public SoftwareMachineBuilder AyantUnBrewer(IBrewer brewer)
    {
        _brewer = brewer;
        return this;
    }

    public SoftwareMachineBuilder AyantUneChangeMachine(IChangeMachine changeMachine)
    {
        _changeMachine = changeMachine;
        return this;
    }

    public SoftwareMachineBuilder AyantUnCupProvider(ICupProvider cupProvider)
    {
        _cupProvider = cupProvider;
        return this;
    }
}