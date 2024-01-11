// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. This 
// particular class can't be instantiated-- instead, do TestHand or PlayerHand.

using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hand : ScriptableObject
{
    public class UniqueCard
    {
        public Card card;
        public int id;
        private List<int> randomList;

        private int GetUniqueRandomID()
        {
            return 0;
        }

    }
    public List<Card> cards = new List<Card>();
    public event Action<Card> cardAdded;
    public event Action<Card> cardRemoved;

    // Add a card to the hand and notify subscribers
    public void AddCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);
        cardAdded.Invoke(cardToAdd);
    }

    // Removesa card from the hand and notify subscribers
    public void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
        cardRemoved.Invoke(cardToRemove);
    }

}
