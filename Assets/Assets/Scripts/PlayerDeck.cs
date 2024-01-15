// Code by Jaxon Lee
//
// Data for an in-game deck. It can be shuffled and drawn from.
// This deck randomizes itself based on the base deck.

using System.Collections.Generic;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/PlayerDeck".
[CreateAssetMenu(fileName = "newPlayerDeck", menuName = "CardSystem/PlayerDeck", order = 6)]
public class PlayerDeck : InGameDeck
{
    public BaseDeck baseDeck;

    // Randomize deck
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
}
