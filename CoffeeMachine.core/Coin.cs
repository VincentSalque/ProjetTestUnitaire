using System.Collections.Frozen;
using CoffeeMachine.core;

public class Coin
{
    private static readonly FrozenSet<ushort> validValues = Enum.GetValues<CoinCode>().Select(code => (ushort)code).ToFrozenSet();

    public ushort Value {get; private set;}

    public Coin(ushort value)
    {
        if(!validValues.Contains(value))
            throw new ArgumentOutOfRangeException(nameof(value));

        this.Value = value;
    }
}