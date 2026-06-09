using Hardware;

namespace MachineACafé;

public class SoftwareMachine
{
    public SoftwareMachine(IBrewer brewer, IChangeMachine changeMachine)
    {
        changeMachine.FlushStoredMoney();
        changeMachine.CollectStoredMoney();
    }

    public void Insérer(ushort montantEnCentimes)
    {
        if (montantEnCentimes < prixCaféEnCents)
        {
            // Remboursement
            return;
        }
        SommeInséréeEnCentimes += montantEnCentimes;
        NombreCafésServis++;
    }
    public const ushort prixCaféEnCents = 40;

    public ushort NombreCafésServis { get; private set; }


    public ushort SommeInséréeEnCentimes { get; private set; }
}