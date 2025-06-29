using ZakharovA_GUN37_Casino.Structs;

namespace ZakharovA_GUN37_Casino.Games;

public class Dices(int count, int min, int max): CasinoGameBase(count, min, max)
{
    private readonly List<Dice> _dices = [];

    public override void PlayGame()
    {
        Console.WriteLine("Player rolling dices");
        var playerResult = RollDices();
        Console.WriteLine("Casino rolling dices");
        var casinoResult = RollDices();

        if (playerResult == casinoResult)
        {
            Console.WriteLine("It's a draw!!");
            OnDrawInvoke();
        } else if (playerResult > casinoResult)
        {
            Console.WriteLine("Player wins!");
            OnWinInvoke();
        } else if (playerResult < casinoResult)
        {
            Console.WriteLine("Casino wins!");
            OnLooseInvoke();
        }
    }

    private int RollDices()
    {
        var sum = 0;
        Console.WriteLine("Result:");
        foreach (var value in _dices.Select(dice => dice.Number))
        {
            Console.Write($"{value} ");
            sum += value;
        }
        Console.WriteLine();
        Console.WriteLine("Sum: {0}", sum);
        return sum;
    }

    protected override void FactoryMethod(params int[] param)
    {
        if (param.Length != 3)
        {
            throw new ArgumentException("Invalid number of parameters");
        }
        
        var countDices = param[0];
        var min = param[1];
        var max = param[2];

        for (int i = 0; i < countDices; i++)
        {
            _dices.Add(new Dice(min, max));
        }
    }
}