// Code written by Jaxon Lee
// 
// Data for a player's hand, which holds cards that the player can play. Resets
// at the beginning of the game to ensure no carry over from old games.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/PlayerHand".
[CreateAssetMenu(fileName = "newPlayerHand", menuName = "CardSystem/PlayerHand", order = 5)]
public class PlayerHand : Hand
{
    // Reset at the beginning of the game.
    private void OnEnable()
    {
        cards.Clear();
    }

}
