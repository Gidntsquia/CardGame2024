// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. This 
// particular class can't be instantiated-- instead, do TestHand or PlayerHand.

using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hand : ScriptableObject
{
    public List<Card> cards = new List<Card>();
    public event Action handChanged;

    // Add a card to the hand and notify subscribers
    public void addCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);
        handChanged.Invoke();
    }

    // Removesa card from the hand and notify subscribers
    public void removeCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
        handChanged.Invoke();
    }

}
