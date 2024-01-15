// Code written by Jaxon Lee
// 
// Data for a player's mana, which is used as a resource for playing cards.

using System;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "ValueTracker/ManaTracker".
[CreateAssetMenu(fileName = "newManaTracker", menuName = "ValueTracker/ManaTracker", order = 8)]
public class PlayerMana : ScriptableObject
{
    public int mana;

    public bool hasEnoughMana(int manaAmount)
    {
        return manaAmount <= mana;
    }

    public void reduceMana(int amountToReduce)
    {
        mana -= amountToReduce;
    }
}
