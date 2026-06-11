using CoffeeMachine.software;
using CoffeeMachine.hardware;

namespace CoffeeMachine.test;

public class CoffeeMachineFunctionnalTests
{
    [Fact(DisplayName = "Insère plus d'argent que nécessaire pour faire un café")]
    public void MakeACoffeeWithTooMuchMoney()
    {
        //GIVEN a coffee machine
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);
        var brewerSpy = new BrewerSpy(new BrewerStub());

        var coffeeMachine = new software.CoffeeMachine(brewerSpy, changeMachineSpy);

        //WHEN notice is given that coins were inserted
        changeMachine.FakeInsertCoin(CoinCode.FiftyCents);

        //THEN MakeACoffee() is called on the hardware
        Assert.Equal(1, brewerSpy.MakeACoffeeInvocationCount);

        //AND CollectStoredMoney() is called on the hardware
        Assert.Equal(1, changeMachineSpy.CollectStoredMoneyCount);
    }

    [Fact(DisplayName = "Insère moins d'argent que nécessaire pour faire un café")]
    public void MakeACoffeeWithoutEnoughMoney()
    {
        //GIVEN a coffee machine
        var changeMachine = new ChangeMachineFake();
        var changeMachineSpy = new ChangeMachineSpy(changeMachine);
        var brewerSpy = new BrewerSpy(new BrewerStub());

        var coffeeMachine = new software.CoffeeMachine(brewerSpy, changeMachineSpy);

        //WHEN notice is given that coins were inserted
        changeMachine.FakeInsertCoin(CoinCode.TwentyCents);

        //THEN MakeACoffee() is NOT called on the hardware
        Assert.Equal(0, brewerSpy.MakeACoffeeInvocationCount);

        //AND FlushStoredMoney() is called on the hardware
        Assert.Equal(1, changeMachineSpy.FlushStoredMoneyCount);
    }
}