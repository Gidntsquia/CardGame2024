// Code written by Jaxon Lee
// 
// Data for a player's health.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "PlayerHealth".
[CreateAssetMenu(fileName = "newPlayerHealth", menuName = "PlayerHealth", order = 1)]
public class PlayerHealth : ScriptableObject
{
    // Change this value to change players' max health.
    public static int maxHealth = 20;
    public int health = maxHealth;

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Debug.Log($"Player with {name} health died!");
            // TODO: Trigger a death event here
        }
    }

    // Reset health to max on scene load (i.e. when the game starts).
    private void OnEnable()
    {
        health = maxHealth;
    }
}
