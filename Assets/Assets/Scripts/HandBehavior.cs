// Code by Jaxon Lee
//
// Manages one player's hand, which holds monster and spell cards that can be
// played.

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class HandBehavior : MonoBehaviour
{
    public Hand hand;
    public GameObject cardObject;
    public Dictionary<Card, GameObject> visibleCards;

    private void Start()
    {
        visibleCards = new Dictionary<Card, GameObject>();

        // Add initial cards
        foreach (Card card in hand.cards)
        {
            CreateVisibleCard(card);
        }

        // Subscribe to hand changes
        hand.cardAdded += CreateVisibleCard;
        hand.cardRemoved += RemoveVisibleCard;
    }

    // Remove self from subscription on destruciton
    // This shouldn't come up, but if it does this will avoid an error.
    private void OnDestroy()
    {
        hand.cardAdded -= CreateVisibleCard;
        hand.cardRemoved -= RemoveVisibleCard;
    }

    // Create a new visible card and add it to the hand.
    private void CreateVisibleCard(Card card)
    {
        // Make a new card object and add it to the hand.
        GameObject newCardObject = Instantiate(cardObject);
        newCardObject.transform.SetParent(transform);

        // Set the new card's identity 
        CardBehavior newCardBehavior = newCardObject.GetComponent<CardBehavior>();
        newCardBehavior.cardIdentity = card;

        // Display the card's values
        CardDisplayer newCardDisplayer = newCardObject.GetComponent<CardDisplayer>();
        newCardDisplayer.DisplayValues(card);

        // Add card to map
        visibleCards.Add(card, newCardObject);
    }

    // Remove a visible vard based on its ID.
    private void RemoveVisibleCard(Card cardToRemove)
    {
        if (visibleCards.TryGetValue(cardToRemove, out GameObject visibleCard))
        {
            Destroy(visibleCard);
            visibleCards.Remove(cardToRemove);
        }
    }

    [Button]
    private void DrawOneCard()
    {
        hand.DrawCards(1);
    }

}
