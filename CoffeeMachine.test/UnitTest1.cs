using CoffeeMachine;

namespace CoffeeMachine.test;

public class UnitTest1
{
    [Fact(DisplayName = "Essaye de faire un café")]
    public void MakeACoffee()
    {
        //GIVEN a coffee machine
        var coffeeMachine = new core.CoffeeMachine();

        //WHEN notice is given that coins were inserted
        coffeeMachine.InsertCoin(40);

        //THEN verify that coffee order is issued
        Assert.Equal(1, coffeeMachine.CoffeeServedAmount);
    }
}
