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
        coffeeMachine.InsertCoin(40);

        //THEN MakeACoffee() is called on the hardware
        Assert.Equal(1, coffeeMachine.CoffeeServedAmount);


        //AND CollectStoredMoney() is called on the hardware
        Assert.Equal(40, coffeeMachine.CollectedAmountInCents);
    }

    [Fact(DisplayName = "Insère plus d'argent que nécessaire pour faire un café")]
    public void MakeACoffeeWithTooMuchMoney()
    {
        //GIVEN a coffee machine
        var coffeeMachine = new core.CoffeeMachine();

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(41);

        //THEN MakeACoffee() is called on the hardware
        Assert.Equal(1, coffeeMachine.CoffeeServedAmount);

        //AND DropCashback(1) is called on the hardware
        Assert.Equal(1, coffeeMachine.CashbackAmountInCents);

        //AND CollectStoredMoney() is called on the hardware
        Assert.Equal(40, coffeeMachine.CollectedAmountInCents);
    }
}
