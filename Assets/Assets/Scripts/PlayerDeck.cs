using System.Collections.Generic;
using UnityEngine;


public class PlayerDeck : MonoBehaviour
{
    public Deck baseDeck;
    public List<Card> deck;
    public Transform hand;


    // Start is called before the first frame update
    void Start()
    {
        deck = new List<Card>();
        foreach (Deck.CardAndCount cardAndCount in baseDeck.cards)
        {
            // Add all the cards to the deck
            Card card = cardAndCount.card;
            int cardCount = cardAndCount.count;
            for (int i = 0; i < cardCount; i++)
            {
                deck.Add(card);
            }
        }

        shuffle();
    }



    // Get the top card off the deck.
    // The deck is like a stack, so I'm using stack terminology here.
    public Card pop()
    {
        Card topCard = null;
        if (deck.Count > 0)
        {
            topCard = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
        }
        return topCard;
    }

    public void addCardToDeck()
    {

    }


    // Shuffle the deck
    public void shuffle()
    {
        ShuffleList(deck);

    }

    private void ShuffleList<T>(List<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
