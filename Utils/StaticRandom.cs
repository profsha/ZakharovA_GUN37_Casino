namespace ZakharovA_GUN37_Casino.Utils;

public static class StaticRandom
{
    private static Random? _local;
    
    public static Random Random
    {
        get { return _local ??= new Random(DateTime.Now.Millisecond); }
    }
}