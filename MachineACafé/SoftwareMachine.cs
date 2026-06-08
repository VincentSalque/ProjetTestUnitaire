namespace MachineACafé;

public class SoftwareMachine
{
    public void InsérerPièce(ushort montantEnCents)
    {
        if (montantEnCents < 40)
        {
            return;
        }
        NombreCafésServis ++;
        SommeEncaisséeEnCentimes += montantEnCents;
        //ArgentRembourséEnCentimes += (ushort)(montantEnCents - 40);
    }

    public ushort NombreCafésServis { get; private set; }
    public ushort SommeEncaisséeEnCentimes { get; private set; }

    public ushort ArgentRembourséEnCentimes { get; private set; }
}