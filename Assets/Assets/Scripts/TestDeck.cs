// Code by Jaxon Lee
//
// Data for an in-game deck. It can be shuffled and drawn from.
// This deck does not randomize on start and restores its state on play start. 
// Make sure to save it before using it so that you can restore it later.

// How to use:
// - Add cards to the test deck
// - Click "SaveDeck" in the inspector
// - On play, this code will make copies of the base cards that you added
// - The copies will be "Type Mismatch" in the editor due to a Unity bug. They
// work as normal, and you can double click them to see their values.
// 
// - Click "RestoreDeck" whenever you want to restore the saved state of the deck.

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "Debug/TestDeck".
[CreateAssetMenu(fileName = "newTestDeck", menuName = "Debug/TestDeck", order = 2)]
public class TestDeck : InGameDeck
{
    private List<Card> originalDeck = new List<Card>();

    [Button]
    private void SaveDeck()
    {
        originalDeck = new List<Card>(deck);
    }

    [Button]
    private void RestoreDeck()
    {
        deck = new List<Card>(originalDeck);
    }


    // Callback called on play start.
    private void OnEnable()
    {
        // Restore deck on play
        if (originalDeck?.Count > 0)
        {
            RestoreDeck();
        }

        // Only run editor commands if this is the editor -- this allows builds
        // to compile.
#if UNITY_EDITOR
        // Make each card unique.
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
        {
            List<Card> myDeck = new List<Card>();
            foreach (Card card in deck)
            {
                // Add all the cards to the deck
                Card uniqueCard = Instantiate(card);
                myDeck.Add(uniqueCard);
            }

            deck = new List<Card>(myDeck);
        }
#endif

    }
}
