// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. This 
// is a test hand, which can be created and edited in the editor for debugging.
// It will reset to whatever it was originally saved on play stop.

using System.Collections.Generic;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/TestHand".
[CreateAssetMenu(fileName = "newTestHand", menuName = "CardSystem/TestHand", order = 5)]
public class TestHand : Hand
{
    private List<UniqueCard> originalHand;

    // Save original test hand whenever any editor change is made (or the scene
    // is loaded)
    private void OnValidate()
    {
        // Regenerate cards list to each have a unique ID.
        List<UniqueCard> cardsWithIDs = new List<UniqueCard>();

        // Debug.Log("Here are the cards in the deck: ");
        foreach (UniqueCard uniqueCard in cards)
        {
            UniqueCard cardWithID = new UniqueCard(uniqueCard.card);
            cardsWithIDs.Add(cardWithID);
            // Debug.Log($"ID: {cardWithID.id}, Card: {cardWithID.card}");

        }

        cards = new List<UniqueCard>(cardsWithIDs);
        originalHand = new List<UniqueCard>(cardsWithIDs);
    }

    // Restore original test hand
    // This runs on scene start (for some reason--nothing we better we can do).
    private void OnDisable()
    {
        Debug.Log($"Restoring test hand: {name}");
        cards = new List<UniqueCard>(originalHand);
    }

}
