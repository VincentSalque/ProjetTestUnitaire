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
        SommeEncaisséeEnCentimes += 40;
    }

    public ushort NombreCafésServis { get; private set; }
    public ushort SommeEncaisséeEnCentimes { get; private set; }
}