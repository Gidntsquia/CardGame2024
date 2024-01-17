// Code by Jaxon Lee
//
// Data for an in-game deck. It can be shuffled and drawn from.
// This deck does not randomize on start and restores its state on play start. 
// DO NOT EDIT THE TEST DECK DURING RUNTIME.

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "Debug/TestDeck".
[CreateAssetMenu(fileName = "newTestDeck", menuName = "Debug/TestDeck", order = 2)]
public class TestDeck : InGameDeck
{
    private List<Card> originalDeck = new List<Card>();

    // Save original test deck whenever any editor change is made (or the scene
    // is loaded)
    //     private void OnValidate()
    //     {
    //         // Only run editor commands if this is the editor -- this allows builds
    //         // to compile.
    // #if UNITY_EDITOR
    //         // Don't save deck during runtime.
    //         if (!UnityEditor.EditorApplication.isPlaying)
    //         {
    //             originalDeck = new List<Card>(deck);
    //         }

    // #endif
    //     }

    //     // Restore original test deck
    //     // This runs on scene start (for some reason--nothing we better we can do).
    //     private void OnDisable()
    //     {
    //         // Debug.Log($"Restoring test deck: {name}");
    //         deck = new List<Card>(originalDeck);
    //     }

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
