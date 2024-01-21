// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. This 
// is a test hand, which can be created and edited in the editor for debugging.
// It restores its state on play start.  Make sure to save it before using it 
// so that you can restore it later.

// How to use:
// - Add cards to the test hand
// - Click "SaveHand" in the inspector
// - On play, this code will make copies of the base cards that you added
// - The copies will be "Type Mismatch" in the editor due to a Unity bug. They
// work as normal, and you can double click them to see their values.
// 
// - Click "RestoreHand" whenever you want to restore the saved state of the hand.

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "Debug/TestHand".
[CreateAssetMenu(fileName = "newTestHand", menuName = "Debug/TestHand", order = 1)]
public class TestHand : Hand
{
    private List<Card> originalHand = new List<Card>();

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
        // TODO: Make this update the hand during runtime
        cards = new List<Card>(originalHand);
    }


}
