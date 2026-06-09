using CoffeeMachine;

namespace CoffeeMachine.test;

public class UnitTest1
{
    [Fact(DisplayName = "Essaye de faire un café")]
    public void MakeACoffeeWithEnoughMoney()
    {
        //GIVEN a coffee machine
        var coffeeMachine = new core.CoffeeMachine();

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(core.CoffeeMachine.CoffeePrice);

        //THEN MakeACoffee() is called on the hardware
        Assert.Equal(1, coffeeMachine.CoffeeServedAmount);


        //AND CollectStoredMoney() is called on the hardware
        Assert.Equal(core.CoffeeMachine.CoffeePrice, coffeeMachine.CollectedMoneyInCents);
    }

    [Fact(DisplayName = "Insère plus d'argent que nécessaire pour faire un café")]
    public void MakeACoffeeWithTooMuchMoney()
    {
        //GIVEN a coffee machine
        var coffeeMachine = new core.CoffeeMachine();

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(core.CoffeeMachine.CoffeePrice+1);

        //THEN MakeACoffee() is called on the hardware
        Assert.Equal(1, coffeeMachine.CoffeeServedAmount);

        //AND DropCashback(1) is called on the hardware
        Assert.Equal(1, coffeeMachine.CashbackAmountInCents);

        //AND CollectStoredMoney() is called on the hardware
        Assert.Equal(core.CoffeeMachine.CoffeePrice, coffeeMachine.CollectedMoneyInCents);
    }

    [Fact(DisplayName = "Insère moins d'argent que nécessaire pour faire un café")]
    public void MakeACoffeeWithoutEnoughMoney()
    {
        //GIVEN a coffee machine
        var coffeeMachine = new core.CoffeeMachine();

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(core.CoffeeMachine.CoffeePrice-1);

        //THEN MakeACoffee() is NOT called on the hardware
        Assert.Equal(0, coffeeMachine.CoffeeServedAmount);

        //AND FlushStoredMoney() is called on the hardware
        Assert.Equal(core.CoffeeMachine.CoffeePrice-1, coffeeMachine.FlushedMoneyInCents);
    }

    [Fact(DisplayName = "Insère l'argent nécessaire pour faire deux cafés")]
    public void MakeTwoCoffeesWithEnoughMoney()
    {
        //GIVEN a coffee machine
        var coffeeMachine = new core.CoffeeMachine();

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(core.CoffeeMachine.CoffeePrice * 2);

        //THEN MakeACoffee() is called twice on the hardware
        Assert.Equal(2, coffeeMachine.CoffeeServedAmount);

        //AND CollectStoreMoney() is called on the hardware
        Assert.Equal(core.CoffeeMachine.CoffeePrice * 2, coffeeMachine.CollectedMoneyInCents);
    }
}
