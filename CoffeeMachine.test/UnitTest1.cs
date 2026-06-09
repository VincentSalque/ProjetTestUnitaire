using CoffeeMachine;

namespace CoffeeMachine.test;

public class UnitTest1
{
    [Fact(DisplayName = "Essaye de faire un café")]
    public void MakeACoffeeWithEnoughMoney()
    {
        //GIVEN a coffee machine
        var changeMachine = new ChangeMachineSpy();
        var brewer = new BrewerSpy();

        var coffeeMachine = new core.CoffeeMachine(brewer, changeMachine);

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(core.CoffeeMachine.CoffeePrice);

        //THEN MakeACoffee() is called on the hardware
        Assert.Equal(1, brewer.MakeACoffeeInvocationCount);

        //AND CollectStoredMoney() is called on the hardware
        Assert.Equal(1, changeMachine.CollectStoredMoneyCount);
    }

    [Fact(DisplayName = "Insère plus d'argent que nécessaire pour faire un café")]
    public void MakeACoffeeWithTooMuchMoney()
    {
        //GIVEN a coffee machine
        var changeMachine = new ChangeMachineSpy();
        var brewer = new BrewerSpy();

        var coffeeMachine = new core.CoffeeMachine(brewer, changeMachine);

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(core.CoffeeMachine.CoffeePrice+1);

        //THEN MakeACoffee() is called on the hardware
        Assert.Equal(1, brewer.MakeACoffeeInvocationCount);

        //AND CollectStoredMoney() is called on the hardware
        Assert.Equal(1, changeMachine.CollectStoredMoneyCount);
    }

    [Fact(DisplayName = "Insère moins d'argent que nécessaire pour faire un café")]
    public void MakeACoffeeWithoutEnoughMoney()
    {
        //GIVEN a coffee machine
        var changeMachine = new ChangeMachineSpy();
        var brewer = new BrewerSpy();

        var coffeeMachine = new core.CoffeeMachine(brewer, changeMachine);

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(core.CoffeeMachine.CoffeePrice-1);

        //THEN MakeACoffee() is NOT called on the hardware
        Assert.Equal(0, brewer.MakeACoffeeInvocationCount);

        //AND FlushStoredMoney() is called on the hardware
        Assert.Equal(1, changeMachine.FlushStoredMoneyCount);
    }
}
