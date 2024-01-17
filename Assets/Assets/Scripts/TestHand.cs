// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. This 
// is a test hand, which can be created and edited in the editor for debugging.
// Make sure to save it before using it so that you can restore it later.

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "Debug/TestHand".
[CreateAssetMenu(fileName = "newTestHand", menuName = "Debug/TestHand", order = 1)]
public class TestHand : Hand
{
    private List<Card> originalHand = new List<Card>();

    // Callback called whenever changes are made in the inspector
    //     private void OnValidate()
    //     {
    //         // Only run editor commands if this is the editor -- this allows builds
    //         // to compile.
    // #if UNITY_EDITOR

    //         // Regenerate cards list to each have a unique ID.
    //         List<UniqueCard> cardsWithIDs = new List<UniqueCard>();

    //         foreach (UniqueCard uniqueCard in cards)
    //         {
    //             UniqueCard cardWithID = new UniqueCard(uniqueCard.card);
    //             cardsWithIDs.Add(cardWithID);

    //         }

    //         cards = new List<UniqueCard>(cardsWithIDs);

    // #endif
    //     }

    private void OnEnable()
    {
        // Restore hand on play
        if (originalHand?.Count > 0)
        {
            RestoreHand();
        }

#if UNITY_EDITOR
        // Make each card unique.
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
        {
            List<Card> uniqueCards = new List<Card>();
            foreach (Card card in cards)
            {
                Card uniqueCard = Instantiate(card);
                uniqueCards.Add(uniqueCard);
                // Debug.Log(uniqueCard.inGameID);
            }

            cards = new List<Card>(uniqueCards);
        }
    }
#endif


    [Button]
    private void SaveHand()
    {
        originalHand = new List<Card>(cards);
    }


    [Button]
    private void RestoreHand()
    {
        cards = new List<Card>(originalHand);
    }


}
