// Code by Jaxon Lee
//
// Hold data for a monster that was summoned to the field. Tracks it's stats,
// including current health.

using UnityEngine;
using UnityEngine.UI;

public class MonsterBehavior : MonoBehaviour
{
    private int basePower;
    private int baseHealth;
    private Image image;
    public string monsterName;

    public int power;
    public int health;
    public int powerBuffs;
    public int healthBuffs;
    public bool isDead = false;

    // Initialize values
    public void Initialize(MonsterCard monsterCardData, int myPowerBuffs = 0, int myHealthBuffs = 0)
    {
        basePower = monsterCardData.power;
        baseHealth = monsterCardData.health;
        image = monsterCardData.image;
        powerBuffs = myPowerBuffs;
        healthBuffs = myHealthBuffs;

        monsterName = monsterCardData.name;

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
            print($"{name} is dead");
        }
    }

    // Deal damage to the frontmost enemy, otherwise deal damage to the 
    // opponent's face.
    public void attack(MonsterBehavior enemyFront, MonsterBehavior enemyBack,
                        PlayerHealth enemyHealthSystem)
    {
        if (enemyFront != null)
        {
            enemyFront.reduceHealth(power);
        }
        else if (enemyBack != null)
        {
            enemyFront.reduceHealth(power);
        }
        else
        {
            enemyHealthSystem.takeDamage(power);
        }
    }



    // Use this to print out the values of this card.
    public override string ToString()
    {
        return $"Monster Active Info:\n" +
               $"Base Power: {basePower}, " +
               $"Base Health: {baseHealth}, " +
               $"Image: {image}, " +
               $"Power Buffs: {powerBuffs}, " +
               $"Health Buffs: {healthBuffs}, " +
               $"Current Power: {power}, " +
               $"Current Health: {health}";
    }
}
