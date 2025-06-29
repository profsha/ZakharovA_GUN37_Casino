namespace ZakharovA_GUN37_Casino.Games;

public abstract class CasinoGameBase
{
    public delegate void EventHandler();
    
    public event EventHandler? OnWin;
    public event EventHandler? OnLoose;
    public event EventHandler? OnDraw;

    public abstract void PlayGame();

    public CasinoGameBase(params int[] number)
    {
        FactoryMethod(number);
    }

    protected abstract void FactoryMethod(params int[] number);

    protected void OnWinInvoke()
    {
        OnWin?.Invoke();
    }

    protected void OnLooseInvoke()
    {
        OnLoose?.Invoke();
    }

    protected void OnDrawInvoke()
    {
        OnDraw?.Invoke();
    }
}