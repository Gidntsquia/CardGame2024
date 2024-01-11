// Code by Jaxon Lee
//
// Manages one player's hand, which holds monster and spell cards that can be
// played.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandBehavior : MonoBehaviour
{
    public Hand hand;
    public GameObject cardObject;
    public List<GameObject> visibleCards;
    // private List<Card> localCardsTracker;
    public int handSize;
    public PlayerDeck gameDeck;

    private void Start()
    {
        visibleCards = new List<GameObject>();
    }

    // public void updateHand()
    // {
    //     if (localCardsTracker.Count < hand.cards.Count)
    //     {
    //         // Only create the cards we just added.
    //         Card[] newAdditions = hand.cards.Except(localCardsTracker).ToArray();
    //         foreach (Card newCard in newAdditions)
    //         {
    //             createVisibleCard(newCard);
    //         }
    //     }
    // }

    private void CreateVisibleCard(Card card)
    {
        // Make a new card object and add it to the hand.
        GameObject newCardObject = Instantiate(cardObject);
        newCardObject.transform.SetParent(transform);
        visibleCards.Add(newCardObject);

        // Set the new card's identity 
        CardBehavior newCardBehavior = newCardObject.GetComponent<CardBehavior>();
        newCardBehavior.cardIdentity = card;

        // Display the card's values
        CardDisplayer newCardDisplayer = newCardObject.GetComponent<CardDisplayer>();
        newCardDisplayer.DisplayValues(card);
    }

    private void RemoveVisibleCard(Card card)
    {
        foreach (GameObject visibleCard in visibleCards)
        {
            // if (visibleCard)
        }
    }

    // public void draw(int numCardsToDraw)
    // {
    //     for (int i = 0; i < numCardsToDraw; i++)
    //     {
    //         // Get the top card of the deck
    //         Card newCard = gameDeck.pop();

    //         // Make a new card object and add it to the hand.
    //         GameObject newCardObject = Instantiate(cardObject);
    //         newCardObject.transform.SetParent(transform);

    //         // Set the new card's identity 
    //         CardBehavior newCardBehavior = newCardObject.GetComponent<CardBehavior>();
    //         newCardBehavior.cardIdentity = newCard;

    //         // Display the card's values
    //         CardDisplayer newCardDisplayer = newCardObject.GetComponent<CardDisplayer>();
    //         newCardDisplayer.displayValues(newCard);

    //         // Update hand size
    //         // TODO: Need to reduce this when cards are played.
    //         handSize += 1;
    //     }
    // }


}
