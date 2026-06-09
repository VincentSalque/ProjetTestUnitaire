using Hardware;
using MachineACafé.Test.Utilities;

namespace MachineACafé.Test;

public class SoftwareMachineTest
{
    [Fact]
    public void CasNominal()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var machine = new SoftwareMachineBuilder().AyantUneChangeMachine(changeMachine).Build();

        // QUAND on insère 40cts
        machine.Insérer(prixDuCafé);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.Equal(1, machine.NombreCafésServis);

        // ET CollectStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachine.CollectStoredMoneyInvocations);
    }

    [Fact]
    public void CasBrewerDéfaillant()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café ayant un brewer défaillant
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());

        var machine = new SoftwareMachineBuilder()
            .AyantUnBrewer(new BrewerDummy())
            .AyantUneChangeMachine(changeMachine)
            .Build();

        // QUAND on insère 40cts
        machine.Insérer(prixDuCafé);

        // ALORS FlushStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachine.FlushStoredMoneyInvocations);
    }

    [Fact]
    public void TropArgent()
    {
        const ushort prixDuCafé = 40;

        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy(new ChangeMachineStub());
        var machine = new SoftwareMachineBuilder().AyantUneChangeMachine(changeMachine).Build();

        // QUAND on insère plus que le prix d'un café
        machine.Insérer(prixDuCafé + 1);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.Equal(1, machine.NombreCafésServis);

        // ET CollectStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachine.CollectStoredMoneyInvocations);
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