using Hardware;

namespace MachineACafé.Test.Utilities;

internal class SoftwareMachineBuilder
{
    private IBrewer? _brewer = null;
    private IChangeMachine _changeMachine = new ChangeMachineStub();

    public SoftwareMachine Build()
    {
        if (_brewer is null)
        {
            throw new InvalidOperationException("A brewer must be provided before building the software machine.");
        }

        return new SoftwareMachine(_brewer, _changeMachine);
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
}