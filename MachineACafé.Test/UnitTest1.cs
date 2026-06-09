using MachineBuilder;
using Hardware;
 
namespace MachineACafé.Test;

public class UnitTest1
{
    [Fact(DisplayName = "Quand la bonne somme est insérée 2 fois, deux cafés sont servis.")]
    public void Cas2Cafés()
    {
    
        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme suffisante pour le prix d'un café, deux fois
        machineACafé.InsérerPièce(SoftwareMachine.prixCaféEnCents);
        machineACafé.InsérerPièce(SoftwareMachine.prixCaféEnCents);

        // ALORS MakeACoffee est appelé deux fois sur le hardware
        Assert.Equal(2, machineACafé.NombreCafésServis);

        // ET il est demandé au hardware de collecter les fonds
        Assert.Equal(SoftwareMachine.prixCaféEnCents * 2, machineACafé.SommeEncaisséeEnCentimes);
    }

    [Fact(DisplayName = "Quand la bonne somme est insérée, un café est servi.")]
    public void CasNominal()
    {
    
        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme suffisante pour le prix d'un café
        machineACafé.InsérerPièce(SoftwareMachine.prixCaféEnCents);

        // ALORS MakeACoffee est appelé sur le hardware
        Assert.Equal(1, machineACafé.NombreCafésServis);

        // ET il est demandé au hardware de collecter les fonds
        Assert.Equal(SoftwareMachine.prixCaféEnCents, machineACafé.SommeEncaisséeEnCentimes);
    }

    [Fact(DisplayName = "Quand aucune somme n'est insérée, aucun café n'est servi.")]
    public void CasRien()
    {
        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // ALORS MakeACoffee n'est pas appelé sur le hardware
        Assert.Equal(0, machineACafé.NombreCafésServis);
    }

    // Les vrais tests fait par nous...
    
    [Fact(DisplayName = "Quand une somme insuffisante est insérée, aucun café n'est servi.")]
    public void CasSommeInsuffisante()
    {

        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme insuffisante pour le prix d'un café
        machineACafé.InsérerPièce((ushort)(SoftwareMachine.prixCaféEnCents - 10));

        // ALORS MakeACoffee n'est pas appelé sur le hardware 
        Assert.Equal(0, machineACafé.NombreCafésServis);

        // ET il n'est pas demandé au hardware de collecter les fonds
        Assert.Equal(0, machineACafé.SommeEncaisséeEnCentimes);
    }

    [Fact(DisplayName = "Quand un client donne une somme insuffisante la machine le rembourse, l'argent est rendu.")]
    public void CasRemboursementSommeInsuffisante()
    {
    
        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme insuffisante pour le prix d'un café
        machineACafé.InsérerPièce((ushort)(SoftwareMachine.prixCaféEnCents - 1));

        // ALORS MakeACoffee n'est pas appelé sur le hardware
        Assert.Equal(0, machineACafé.NombreCafésServis);

        // ET CollectStoredMoney n'est pas appelé sur le hardware
        Assert.Equal(0, machineACafé.SommeEncaisséeEnCentimes);

        //ET il est demandé au hardware de rembourser le client
        //Assert.Equal(SoftwareMachine.prixCaféEnCents - 10, machineACafé.ArgentRembourséEnCentimes);
    }

    [Fact(DisplayName = "Quand un client donne une somme suffisante, il recoit un café ET la machine ne rembourse pas rembourse.")]
    public void CasRemboursementSommeSuperieure()
    {
       
        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme suffisante pour le prix d'un café
        machineACafé.InsérerPièce((ushort)(SoftwareMachine.prixCaféEnCents + 1));

        // ALORS  MakeACoffee est appelé sur le hardware
        Assert.Equal(1, machineACafé.NombreCafésServis);

        // ET CollectStoredMoney est appelé sur le hardware
        Assert.Equal(SoftwareMachine.prixCaféEnCents + 1, machineACafé.SommeEncaisséeEnCentimes);

        //ET il est demandé au hardware de rembourser le client de la somme en trop
        //Assert.Equal(1, machineACafé.ArgentRembourséEnCentimes);
    }

    [Fact(DisplayName = "Quand le hardware est défaillant, la machine ne sert pas de café et rembourse le client.")]
    public void CasBrewerDeffaillant()
    {
       
        // ETANT DONNE une machine a café
        var machineACafé = new SoftwareMachine();

        // QUAND le hardware signale une somme suffisante pour le prix d'un café
        machineACafé.InsérerPièce((ushort)(SoftwareMachine.prixCaféEnCents + 1));

        // ALORS  MakeACoffee est appelé sur le hardware
        Assert.Equal(1, machineACafé.NombreCafésServis);

        // ET CollectStoredMoney est appelé sur le hardware
        Assert.Equal(SoftwareMachine.prixCaféEnCents + 1, machineACafé.SommeEncaisséeEnCentimes);

        //ET il est demandé au hardware de rembourser le client de la somme en trop
        //Assert.Equal(1, machineACafé.ArgentRembourséEnCentimes);
    }

}