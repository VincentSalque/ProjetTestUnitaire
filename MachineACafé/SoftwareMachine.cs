using Hardware;
namespace MachineACafé;

public class SoftwareMachine
{
    public void InsérerPièce(ushort montantEnCents)
    {
        if (montantEnCents < prixCaféEnCents)
        {
            return;
        }
        NombreCafésServis ++;
        SommeEncaisséeEnCentimes += montantEnCents;
        //ArgentRembourséEnCentimes += (ushort)(montantEnCents - prixCaféEnCents);
    }
    public const ushort prixCaféEnCents = 40;
    public ushort NombreCafésServis { get; private set; }
    public ushort SommeEncaisséeEnCentimes { get; private set; }

    public ushort ArgentRembourséEnCentimes { get; private set; }
}