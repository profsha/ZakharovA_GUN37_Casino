using ZakharovA_GUN37_Casino.Exceptions;

namespace ZakharovA_GUN37_Casino.Structs;

public readonly struct Dice
{
    private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
    private readonly int _min;
    private readonly int _max;
    public int Number => _random.Next(_min, _max + 1);

    public Dice(int min, int max)
    {
        if (min > max)
        {
            (min, max) = (max, min);
        }

        if (min < 1 || max < 1 || min > int.MaxValue || max > int.MaxValue)
        {
            throw new WrongDiceNumberException();
        }
        _min = min;
        _max = max;
    }
}