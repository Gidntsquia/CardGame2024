// Code by Jaxon Lee
//
// Manages one player's hand, which holds monster and spell cards that can be
// played.

using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour
{
    public Hand hand;
    public GameObject cardObject;
    public Dictionary<int, GameObject> visibleCards;

    private void Start()
    {
        visibleCards = new Dictionary<int, GameObject>();

        // Add initial cards
        foreach (Hand.UniqueCard uniqueCard in hand.cards)
        {
            CreateVisibleCard(uniqueCard.card, uniqueCard.id);
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
    private void CreateVisibleCard(Card card, int id)
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
        visibleCards.Add(id, newCardObject);
    }

    // Remove a visible vard based on its ID.
    private void RemoveVisibleCard(int idToRemove)
    {
        if (visibleCards.TryGetValue(idToRemove, out GameObject visibleCard))
        {
            Destroy(visibleCard);
            visibleCards.Remove(idToRemove);
        }
    }

}
