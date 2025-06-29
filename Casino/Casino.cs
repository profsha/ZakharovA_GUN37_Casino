using ZakharovA_GUN37_Casino.Games;
using ZakharovA_GUN37_Casino.Services.SaveLoadService;

namespace ZakharovA_GUN37_Casino.Casino;

public class Casino: IGame
{
    private readonly ISaveLoadService<string> _saveLoadService;
    private readonly Blackjack _blackjack = new(56);
    private readonly Dices _dices = new(6, 1, 6);
    private int _currentBet;
    private int _currentBank;

    public Casino(ISaveLoadService<string> saveLoadService)
    {
        _saveLoadService = saveLoadService;
        _blackjack.OnWin += OnWin;
        _blackjack.OnDraw += ShowBank;
        _blackjack.OnLoose += OnLoose;
        _dices.OnWin += OnWin;
        _dices.OnDraw += ShowBank;
        _dices.OnLoose += OnLoose;
    }

    private void OnWin()
    {
        if (int.MaxValue - _currentBet < _currentBank)
        {
            Console.WriteLine("You wasted half of your bank money in casino’s bar");
            _currentBank = int.MaxValue / 2;
            return;
        }
        _currentBank += _currentBet;
        ShowBank();
    }

    private void OnLoose()
    {
        _currentBank -= _currentBet;
        ShowBank();
    }

    private void ShowBank()
    {
        Console.WriteLine($"Current bank: {_currentBank}");
    }

    private void PlaceBet()
    {
        Console.WriteLine("Place bet");
        var isBetComplete = false;
        while (!isBetComplete)
        {
            if (int.TryParse(Console.ReadLine(), out var input))
            {
                if (input <= _currentBank)
                {
                    _currentBet = input;
                    isBetComplete = true;
                }
                else
                {
                    Console.WriteLine("You don't have enough bank to pay!");
                }
            }
        }
    }
    
    public void StartGame()
    {
        Console.WriteLine("Hello to casino!!");
        Console.WriteLine("What is your name?");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            name = "defaultName";
        }
        var data = _saveLoadService.LoadData(name);
        if (!int.TryParse(data, out _currentBank))
        {
            _currentBank = 1000;
        }

        ShowBank();
        var isExit = false;
        while (!isExit)
        {
            if (_currentBank == 0)
            {
                Console.WriteLine("No money? Kicked!");
                break;
            }
            Console.WriteLine("How do you want to play?");
            Console.WriteLine("1. Blackjack");
            Console.WriteLine("2. Dices");
            Console.WriteLine("3. Exit");
            if (int.TryParse(Console.ReadLine(), out var input))
            {
                switch (input)
                {
                    case 1:
                        PlaceBet();
                        _blackjack.PlayGame();
                        break;
                    case 2:
                        PlaceBet();
                        _dices.PlayGame();
                        break;
                    case 3:
                        isExit = true;
                        break;
                }
            }
        }
        _saveLoadService.SaveData($"{_currentBank}", name);
        Console.WriteLine("Thank you for playing! Goodbye!");
    }
}