// Code by Jaxon Lee
//
// Hold data for a monster that was summoned to the field. Tracks it's stats,
// including current health.

using NaughtyAttributes;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [Expandable]
    public Monster monsterIdentity;

    // Initialize values
    // public void Initialize(MonsterCard monsterCardData, int myPowerBuffs = 0, int myHealthBuffs = 0)
    // {
    //     basePower = monsterCardData.power;
    //     baseHealth = monsterCardData.health;
    //     image = monsterCardData.image;
    //     powerBuffs = myPowerBuffs;
    //     healthBuffs = myHealthBuffs;

    //     monsterName = monsterCardData.name;

    //     // Calculate current power and health
    //     power = basePower + powerBuffs;
    //     health = baseHealth + healthBuffs;
    //     isDead = false;
    // }

    // // Buff the monster
    // public void giveBuff(int powerBuff, int healthBuff)
    // {
    //     powerBuffs += powerBuff;
    //     healthBuffs += healthBuff;

    //     power += powerBuff;
    //     health += healthBuff;

    // }

    // Reduce monster's health
    // public void reduceHealth(int damageToTake)
    // {
    //     health -= damageToTake;
    //     if (health <= 0)
    //     {
    //         // TODO: replace this with an event
    //         isDead = true;
    //         print($"{name} is dead");
    //     }
    // }
    public void Initialize(Monster monsterIdentity)
    {
        this.monsterIdentity = monsterIdentity;

        monsterIdentity.AttackRequested += Attack;
    }

    // Deal damage to the frontmost enemy, otherwise deal damage to the 
    // opponent's face.
    public void Attack(Monster enemyFront, Monster enemyBack,
                        PlayerHealth enemyHealthSystem)
    {
        if (enemyFront != null)
        {
            enemyFront.ReduceHealth(monsterIdentity.power);
        }
        else if (enemyBack != null)
        {
            enemyFront.ReduceHealth(monsterIdentity.power);
        }
        else
        {
            enemyHealthSystem.TakeDamage(monsterIdentity.power);
        }
    }



    // Use this to print out the values of this card.
    public override string ToString()
    {
        return monsterIdentity.ToString();
    }

    // Callback called when this component is destroyed.
    private void OnDestroy()
    {
        // Clean up event subscriptions on destruction
        monsterIdentity.AttackRequested -= Attack;
    }
}
