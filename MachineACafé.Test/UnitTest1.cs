namespace MachineACafé.Test;

public class UnitTest1
{
    [Fact(DisplayName = "Quand la bonne somme est insérée 2 fois, deux cafés sont servis.")]
    public void Cas2Cafés()
    {
        const ushort prixCaféEnCents = 40;

        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme suffisante pour le prix d'un café, deux fois
        machineACafé.InsérerPièce(prixCaféEnCents);
        machineACafé.InsérerPièce(prixCaféEnCents);

        // ALORS le hardware est sollicité pour faire couler deux cafés
        Assert.Equal(2, machineACafé.NombreCafésServis);

        // ET il est demandé au hardware de collecter les fonds
        Assert.Equal(prixCaféEnCents * 2, machineACafé.SommeEncaisséeEnCentimes);
    }

    [Fact(DisplayName = "Quand la bonne somme est insérée, un café est servi.")]
    public void CasNominal()
    {
        const ushort prixCaféEnCents = 40;

        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme suffisante pour le prix d'un café
        machineACafé.InsérerPièce(prixCaféEnCents);

        // ALORS le hardware est sollicité pour faire couler un café
        Assert.Equal(1, machineACafé.NombreCafésServis);

        // ET il est demandé au hardware de collecter les fonds
        Assert.Equal(prixCaféEnCents, machineACafé.SommeEncaisséeEnCentimes);
    }

    [Fact(DisplayName = "Quand aucune somme n'est insérée, aucun café n'est servi.")]
    public void CasRien()
    {
        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // ALORS aucun café n'est servi
        Assert.Equal(0, machineACafé.NombreCafésServis);
    }

    // Les vrais tests fait par nous...
    
    [Fact(DisplayName = "Quand une somme insuffisante est insérée, aucun café n'est servi.")]
    public void CasSommeInsuffisante()
    {
        const ushort prixCaféEnCents = 40;

        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme insuffisante pour le prix d'un café
        machineACafé.InsérerPièce((ushort)(prixCaféEnCents - 10));

        // ALORS aucun café n'est servi
        Assert.Equal(0, machineACafé.NombreCafésServis);

        // ET il n'est pas demandé au hardware de collecter les fonds
        Assert.Equal(0, machineACafé.SommeEncaisséeEnCentimes);
    }

    [Fact(DisplayName = "Quand un client donne une somme insuffisante la machine le rembourse, l'argent est rendu.")]
    public void CasRemboursementSommeInsuffisante()
    {
        const ushort prixCaféEnCents = 40;

        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme insuffisante pour le prix d'un café
        machineACafé.InsérerPièce((ushort)(prixCaféEnCents - 1));

        // ALORS aucun café n'est servi
        Assert.Equal(0, machineACafé.NombreCafésServis);

        // ET il n'est pas demandé au hardware de collecter les fonds
        Assert.Equal(0, machineACafé.SommeEncaisséeEnCentimes);

       /* //ET il est demandé au hardware de rembourser le client
        Assert.Equal(prixCaféEnCents - 10, machineACafé.ArgentRembourséEnCentimes);*/
    }
}