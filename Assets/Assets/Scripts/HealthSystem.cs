// Code written by Jaxon Lee
// 
// Data for a player's health.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/Deck".
[CreateAssetMenu(fileName = "newHealthSystem", menuName = "HealthSystem", order = 1)]
public class HealthSystem : ScriptableObject
{
    public static int maxHealth = 20;
    public int health = maxHealth;

    public void takeDamage(int damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Debug.Log($"Player with {name} health died!");
            // TODO: Trigger a death event here
        }
    }

    private void OnEnable()
    {
        health = maxHealth;
    }
}
