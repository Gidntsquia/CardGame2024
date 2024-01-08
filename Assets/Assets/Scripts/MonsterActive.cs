// Code by Jaxon Lee
//
// Hold data for a monster that was summoned to the field. Tracks it's stats,
// including current health.

using UnityEngine;
using UnityEngine.UI;

public class MonsterActive : MonoBehaviour
{
    private int basePower;
    private int baseHealth;
    private Image image;

    public int power;
    public int health;
    public int powerBuffs;
    public int healthBuffs;
    public bool isDead = false;

    // Initialize values
    public void Initialize(int myBasePower, int myBaseHealth, Image myImage, int myPowerBuffs = 0, int myHealthBuffs = 0)
    {
        basePower = myBasePower;
        baseHealth = myBaseHealth;
        image = myImage;
        powerBuffs = myPowerBuffs;
        healthBuffs = myHealthBuffs;

        // Calculate current power and health
        power = basePower + powerBuffs;
        health = baseHealth + healthBuffs;
        isDead = false;
    }

    // Buff the monster
    public void giveBuff(int powerBuff, int healthBuff)
    {
        powerBuffs += powerBuff;
        healthBuffs += healthBuff;

        power += powerBuff;
        health += healthBuff;

    }

    // Reduce monster's health
    public void reduceHealth(int damageToTake)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            // TODO: replace this with an event
            isDead = true;
        }
    }


    // ToString method to print values
    public override string ToString()
    {
        return $"Monster Active Info:\n" +
               $"Base Power: {basePower}\n" +
               $"Base Health: {baseHealth}\n" +
               $"Image: {image}\n" +
               $"Power Buffs: {powerBuffs}\n" +
               $"Health Buffs: {healthBuffs}\n" +
               $"Current Power: {power}\n" +
               $"Current Health: {health}\n";
    }
}
