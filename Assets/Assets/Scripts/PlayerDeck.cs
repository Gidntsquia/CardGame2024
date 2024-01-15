// Code by Jaxon Lee
//
// Data for an in-game deck. It can be shuffled and drawn from.

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerDeck", menuName = "CardSystem/PlayerDeck", order = 6)]
public class PlayerDeck : ScriptableObject
{
    public BaseDeck baseDeck;
    public List<Card> deck;
    // public Hand hand;


    // Start is called before the first frame update
    // private void Start()
    // {
    //     deck = new List<Card>();
    //     foreach (Deck.CardAndCount cardAndCount in baseDeck.cards)
    //     {
    //         // Add all the cards to the deck
    //         Card card = cardAndCount.card;
    //         int cardCount = cardAndCount.count;
    //         for (int i = 0; i < cardCount; i++)
    //         {
    //             deck.Add(card);
    //         }
    //     }

    //     ShuffleDeck();
    // }

    private void OnEnable()
    {
        deck = new List<Card>();
        foreach (BaseDeck.CardAndCount cardAndCount in baseDeck.cards)
        {
            // Add all the cards to the deck
            Card card = cardAndCount.card;
            int cardCount = cardAndCount.count;
            for (int i = 0; i < cardCount; i++)
            {
                deck.Add(card);
            }
        }

        // Randomize the order
        ShuffleDeck();
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
    public void ShuffleDeck()
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
