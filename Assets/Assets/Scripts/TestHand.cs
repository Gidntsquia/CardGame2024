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
    private List<Card> originalHand;

    // Save original test hand whenever any editor change is made (or the scene
    // is loaded)
    private void OnValidate()
    {
        // Debug.Log($"Saving test hand: {name}");
        originalHand = new List<Card>(cards);
    }

    // Restore original test hand
    private void OnDisable()
    {
        Debug.Log($"Restoring test hand: {name}");
        cards = new List<Card>(originalHand);
    }

}
