// Code written by Jaxon Lee
// 
// Data for a player's mana, which is used as a resource for playing cards.

using NaughtyAttributes;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "ValueTracker/ManaTracker".
[CreateAssetMenu(fileName = "newManaTracker", menuName = "ValueTracker/PlayerMana", order = 2)]
public class PlayerMana : ScriptableObject
{
    public int maxTurnMana = 5;
    public int currMana;

    private void OnEnable()
    {
        // TODO: uncomment this when ready to play for real.
        // maxTurnMana = 1;

        // Reset mana on start.
        currMana = maxTurnMana;
    }

    public bool HasEnoughMana(int manaAmount)
    {
        return manaAmount <= currMana;
    }

    public void ReduceMana(int amountToReduce)
    {
        currMana -= amountToReduce;
    }

    // Increases the turn mana by 1 and resets the current mana.
    [Button]
    public void ProgressToNextTurn()
    {
        maxTurnMana += 1;
        currMana = maxTurnMana;
    }

    // Resets mana back to what the player had at the beginning of the turn.
    // This is for debugging.
    [Button]
    public void ResetMana()
    {
        currMana = maxTurnMana;
    }
}
