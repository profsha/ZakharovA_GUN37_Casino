using ZakharovA_GUN37_Casino.Enums;

namespace ZakharovA_GUN37_Casino.Structs;

public readonly struct Card(Sizes size, Suits suit)
{
    public Sizes Size { get; } = size;

    public Suits Suit { get; } = suit;
}