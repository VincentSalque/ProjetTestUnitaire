using System.Runtime.CompilerServices;
using Hardware;
using MachineACafé.Test.Utilities;

namespace MachineACafé.Test;

//TODO : Mocks automatisés.

public class SoftwareMachineTest
{
    [Fact]
    public void AucuneAction()
    {
        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineSpy();
        var brewer = new BrewerSpy();

        _ = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachine)
            .AyantUnBrewer(brewer)
            .Build();

        // ALORS aucune invocation du Brewer ou de la ChangeMachine n'est effectuée
        Assert.True(changeMachine.Untouched);
        Assert.True(brewer.Untouched);
    }

    [Fact]
    public void CasNominal()
    {
        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);

        var brewer = new BrewerSpy(new BrewerStub());
        _ = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachineSpy)
            .AyantUnBrewer(brewer)
            .Build();

        // QUAND on insère une somme supérieure ou égale au prix d'un café
        changeMachine.SimulerInsertionPièce(CoinCode.FiftyCents);

        // ALORS MakeACoffee est appelé une fois sur le hardware
        Assert.Equal(1, brewer.MakeACoffeeInvocations);

        // ET CollectStoredMoney est appelé une fois sur le hardware
        Assert.Equal(1, changeMachineSpy.CollectStoredMoneyInvocations);

        // ET FlushStoredMoney n'est pas appelé
        Assert.Equal(0, changeMachineSpy.FlushStoredMoneyInvocations);
    }

    [Fact]
    public void CasBrewerDéfaillant()
    {
        // ETANT DONNE une machine à café ayant un brewer défaillant
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);

        _ = new SoftwareMachineBuilder()
            .AyantUnBrewer(new BrewerDummy())
            .AyantUneChangeMachine(changeMachineSpy)
            .Build();

        // QUAND on insère une somme supérieure ou égale au prix d'un café
        changeMachine.SimulerInsertionPièce(CoinCode.FiftyCents);

        // ALORS FlushStoredMoney est appelé une fois
        Assert.Equal(1, changeMachineSpy.FlushStoredMoneyInvocations);

        // ET CollectStoredMoney n'est pas appelé
        Assert.Equal(0, changeMachineSpy.CollectStoredMoneyInvocations);
    }

    [Fact]
    public void PasAssezArgent()
    {
        // ETANT DONNE une machine à café
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);

        var brewer = new BrewerSpy();
        _ = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachineSpy)
            .AyantUnBrewer(brewer)
            .Build();

        // QUAND on insère moins que le prix d'un café
        changeMachine.SimulerInsertionPièce(CoinCode.TwentyCents);

        // ALORS MakeACoffee n'est pas appelé
        Assert.Equal(0, brewer.MakeACoffeeInvocations);

        // ET CollectStoredMoney n'est pas appelé
        Assert.Equal(0, changeMachineSpy.CollectStoredMoneyInvocations);

        // ET FlushStoredMoney est appelé une fois
        Assert.Equal(1, changeMachineSpy.FlushStoredMoneyInvocations);
    }

//===================================== TRAVAIL ELEVES =====================================
  
    [Fact (DisplayName = "Quand on paye mais sans tasse")]
    public void PayeSansTasse()
    {
        //ETANT DONNE une machine a café
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);
        var brewer = new BrewerSpy(new BrewerStub());

        var cupProvider = new CupProviderFake(false);
        _ = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachineSpy)
            .AyantUnBrewer(brewer)
            .AyantUnCupProvider(cupProvider)
            .Build();

        //QUAND argent suffisant
        changeMachine.SimulerInsertionPièce(CoinCode.FiftyCents); 
        //ET aucune tasse detectée
        _ = cupProvider.IsCupPresent();

        //ALORS (servir un gobelet)
        Assert.True(cupProvider.IsCupPresent());
        //ET (couler un café)
        Assert.Equal(1, brewer.MakeACoffeeInvocations);
    }

    [Fact (DisplayName = "Quand on paye avec une tasse")]
    public void PayeAvecTasse()
    {
        //ETANT DONNE une machine a café
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);
        var brewer = new BrewerSpy(new BrewerStub());

        var cupProvider = new CupProviderFake(true);
        _ = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachineSpy)
            .AyantUnBrewer(brewer)
            .AyantUnCupProvider(cupProvider)
            .Build();

        //QUAND une tasse est detectée
        _ = cupProvider.IsCupPresent();

        //ALORS servir un café
        Assert.Equal(1, brewer.MakeACoffeeInvocations);
    }

    [Fact (DisplayName = "Quand a une tasse et qu'on ne veut pas un gobelet")]
    public void TassePasDeGobelet()
    {
        //ETANT DONNE une machine a café
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);
        var brewer = new BrewerSpy(new BrewerStub());

        var cupProviderSpy = new CupProviderSpy(true);
        _ = new SoftwareMachineBuilder()
            .AyantUneChangeMachine(changeMachineSpy)
            .AyantUnBrewer(brewer)
            .AyantUnCupProvider(cupProviderSpy)
            .Build();

        //QUAND une tasse est detectée
        _ = cupProviderSpy.IsCupPresent();

        //ALORS ne pas servir un gobelet
        Assert.Equal(0, cupProviderSpy.ProvideCupCall);
        Assert.Equal(1, cupProviderSpy.IsCupPresentCall);
    }
/*

    [Fact (DisplayName = "Quand on paye sans tasse MAIS qu'il n'y en a plus")]
    public void PayeSansTassePlusDeGobelet()
    {  
        //ETANT DONNE une machine a café 

        //QUAND aucune tasse detectée
        //ET aucun gobelet restant dans machine a café

        //ALORS
    }

    [Fact (DisplayName = "Quand on met pas assez d'argent et que on a pas de gobelet")]
    public void PasAssezArgentPasDeGobelet()
    {   
        //ETANT DONNE une machine a café

        //QUAND argent insufisant 
        //ET pas de tasse detectée

        //ALORS (donner un gobelet)
        //ET (Rendre la monnaie)
    }

    Plus tard pour le complexe [Fact (DisplayName = "Quand on met pas assez d'argent et que l'on a une tasse")]



// ORDRE : Appuyez bouton -> InsererPiece -> Voir gobelet -> Servir café 
//                                        -> Rendre monnaie
//*/
}