using ZakharovA_GUN37_Casino.Utils;

namespace ZakharovA_GUN37_Casino.Extensions;

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = StaticRandom.Random.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}