// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. This 
// particular class can't be instantiated--instead, do TestHand or PlayerHand.

using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public abstract class Hand : ScriptableObject
{
    public InGameDeck deck;

    // [Serializable]
    // public class UniqueCard
    // {
    //     public Card card;
    //     public readonly int id;
    //     private static int uniqueIDCounter = 0;

    //     // Code adapted from ChatGPT
    //     private int GenerateUniqueID()
    //     {
    //         return uniqueIDCounter++;
    //     }

    //     public UniqueCard(Card card)
    //     {
    //         this.card = card;
    //         this.id = GenerateUniqueID();
    //     }
    // }

    [Expandable]
    public List<Card> cards = new List<Card>();
    public event Action<Card> cardAdded;
    public event Action<Card> cardRemoved;

    // Add a card to the hand and notify subscribers
    // Pass UniqueCard to the subscribers. 
    public void AddCard(Card cardToAdd)
    {
        if (cardToAdd != null)
        {
            cards.Add(cardToAdd);
            cardAdded?.Invoke(cardToAdd);
        }
    }


    // Removes a card from the hand and notify subscribers
    // Pass the id of the card that was removed.
    public void RemoveCard(Card cardToRemove)
    {
        if (cardToRemove != null)
        {
            cards.Remove(cardToRemove);
            cardRemoved?.Invoke(cardToRemove);
        }
    }


    // Add cards to the hand from the deck.
    public void DrawCards(int numCardsToDraw)
    {
        // Ensure we don't overdraw
        // TODO: maybe add deck out lose condition?
        int numCardsInDeck = deck.deck.Count;
        if (numCardsToDraw > numCardsInDeck)
        {
            numCardsToDraw = numCardsInDeck;
            Debug.Log("Deck doesn't have enough cards... hand will draw however many it can.");
        }

        // Draw cards to hand
        for (int i = 0; i < numCardsToDraw; i++)
        {
            AddCard(deck.Pop());

        }
    }


    // Add inspector button for drawing a card.
    [Button]
    private void DrawOneCard()
    {
        DrawCards(1);
    }

}
