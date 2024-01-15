// Code by Jaxon Lee
//
// Data for an in-game deck. It can be shuffled and drawn from.
// This deck does not randomize on start and restores its state on play start. 

using System.Collections.Generic;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "Debug/TestDeck".
[CreateAssetMenu(fileName = "newTestDeck", menuName = "Debug/TestDeck", order = 2)]
public class TestDeck : InGameDeck
{
    private List<Card> originalDeck;

    // Save original test deck whenever any editor change is made (or the scene
    // is loaded)
    private void OnValidate()
    {
        // Only run editor commands if this is the editor -- this allows builds
        // to compile.
#if UNITY_EDITOR
        // Don't save deck during runtime.
        if (!UnityEditor.EditorApplication.isPlaying)
        {
            originalDeck = new List<Card>(deck);
        }

#endif
    }

    // Restore original test deck
    // This runs on scene start (for some reason--nothing we better we can do).
    private void OnDisable()
    {
        // Debug.Log($"Restoring test deck: {name}");
        deck = new List<Card>(originalDeck);
    }
}
