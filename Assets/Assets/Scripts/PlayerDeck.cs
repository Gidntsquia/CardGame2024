using System.Collections.Generic;
using UnityEngine;


public class PlayerDeck : MonoBehaviour
{
    public Deck baseDeck;
    public List<Card> deck;


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

        Shuffle();
    }



    // Get the top card off the deck.
    // The deck is like a stack, so I'm using stack terminology here.
    public Card Pop()
    {
        Card topCard = null;
        if (deck.Count > 0)
        {
            topCard = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
        }
        return topCard;
    }

    public void AddCardToDeck()
    {

    }


    // Shuffle the deck
    public void Shuffle()
    {
        ShuffleList(deck);
    }

    // Code by Smooth-P
    // https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/
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
