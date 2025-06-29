using ZakharovA_GUN37_Casino.Enums;
using ZakharovA_GUN37_Casino.Extensions;
using ZakharovA_GUN37_Casino.Structs;

namespace ZakharovA_GUN37_Casino.Games;

public class Blackjack(int countCards) : CasinoGameBase(countCards)
{
    private readonly List<Card> _cards = [];
    private readonly Queue<Card> _deck = new();
    
    public override void PlayGame()
    {
        Shuffle();
        var player = new List<Card>();
        var casino = new List<Card>();
        
        Console.WriteLine("Player receives cards");
        DealCards(2, player);
        Console.WriteLine("Casino receives cards");
        DealCards(2, casino);

        while (true)
        {
            if (ViewResult(SumCards(player), SumCards(casino)))
            {
                break;
            }
            DealCards(1, player);
            DealCards(1, casino);
            
        }
    }

    private void DealCards(int number, List<Card> hand)
    {
        Console.WriteLine("Dealing cards");
        for (var i = 0; i < number; i++)
        {
            var card = _deck.Dequeue();
            Console.WriteLine("Card {0} {1}", card.Suit, card.Size);
            hand.Add(card);
        }
    }

    private int SumCards(IEnumerable<Card> cards)
    {
        return cards.Sum(card => card.Size switch
        {
            Sizes.Jack or Sizes.Queen or Sizes.King => 10,
            Sizes.Ace => 11,
            _ => (int)card.Size
        });
    }

    private bool ViewResult(int player, int casino)
    {
        if (player == casino && player < 21)
        {
            return false;
        }

        if (player <= 21 && (casino > 21 || casino < player))
        {
            Console.WriteLine("Player wins");
            OnWinInvoke();
        } else if (casino <= 21 && (player > 21 || player < casino))
        {
            Console.WriteLine("Casino wins");
            OnLooseInvoke();
        } else if (player >= 21 && casino >= 21)
        {
            Console.WriteLine("It's a draw!!");
            OnDrawInvoke();
        }

        return true;
    }

    private void Shuffle()
    {
        _cards.Shuffle();
        _deck.Clear();
        foreach (var card in _cards)
        {
            _deck.Enqueue(card);
        }
    }

    protected override void FactoryMethod(params int[] param)
    {
        if (param.Length != 1)
        {
            throw new ArgumentException("Invalid number of parameters");
        }
        var countCards = param[0];
        var startSize = Sizes.Two;
        if (countCards != 56)
        {
            startSize = Sizes.Six;
        }

        var sizes = Enum.GetValues<Sizes>().Where(x => x > startSize).ToList();

        foreach (var suit in Enum.GetValues<Suits>())
        {
            foreach (var size in sizes)
            {
                _cards.Add(new Card(size, suit));
            }
        }
    }
}