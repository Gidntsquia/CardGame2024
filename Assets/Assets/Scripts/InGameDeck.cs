// Code by Jaxon Lee
//
// Data for an in-game deck. It can be shuffled and drawn from.
// This class can not be instantiated--instead, use PlayerDeck or TestDeck

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public abstract class InGameDeck : ScriptableObject
{
    public List<Card> deck;

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


    // Shuffle the deck. Allow this function to be called in the editor.
    [Button]
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
