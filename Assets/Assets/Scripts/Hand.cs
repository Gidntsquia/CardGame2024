// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. This 
// particular class can't be instantiated-- instead, do TestHand or PlayerHand.

using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hand : ScriptableObject
{
    [Serializable]
    public class UniqueCard
    {
        public Card card;
        public readonly int id;
        private static int uniqueIDCounter = 0;

        // Code adapted from ChatGPT
        private int GenerateUniqueID()
        {
            return uniqueIDCounter++;
        }

        public UniqueCard(Card card)
        {
            this.card = card;
            this.id = GenerateUniqueID();
        }
    }

    public List<UniqueCard> cards = new List<UniqueCard>();
    public event Action<Card, int> cardAdded;
    public event Action<int> cardRemoved;

    // Add a card to the hand and notify subscribers
    // Pass UniqueCard to the subscribers. 
    public void AddCard(Card cardToAdd)
    {
        UniqueCard newCard = new UniqueCard(cardToAdd);
        cards.Add(newCard);
        cardAdded?.Invoke(newCard.card, newCard.id);
    }

    // Removes a card from the hand and notify subscribers
    // Pass the id of the card that was removed.
    public void RemoveCard(int idOfCardToRemove)
    {
        UniqueCard cardToRemove = cards.Find(card => card.id == idOfCardToRemove);

        if (cardToRemove != null)
        {
            cards.Remove(cardToRemove);
            cardRemoved?.Invoke(idOfCardToRemove);
        }
    }


    // Runs on scene start
    // private void OnEnable()
    // {
    //     Debug.Log("Adding initial cards");
    //     // Notify subcribers of the intial state of the card list.
    //     if (cards.Count > 0)
    //     {
    //         foreach (UniqueCard uniqueCard in cards)
    //         {
    //             cardAdded?.Invoke(uniqueCard.card, uniqueCard.id);
    //         }
    //     }
    // }

}
