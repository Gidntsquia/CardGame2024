// Code written by Jaxon Lee
// 
// Data for a monster, which has stats, can attack, and can die.

using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/Monster".
[CreateAssetMenu(fileName = "newMonster", menuName = "CardSystem/Monster", order = 3)]
public class Monster : ScriptableObject
{
    public int basePower;
    public int baseHealth;
    public Image image;

    public string monsterName;
    public int power;
    public int health;
    public int powerBuffs;
    public int healthBuffs;
    public bool isDead = false;

    public event Action PowerChanged;
    public event Action HealthChanged;
    public event Action OnDeath;
    public event Action<Monster, Monster, PlayerHealth> AttackRequested;


    // Buff the monster
    public void GiveBuff(int powerBuff, int healthBuff)
    {
        powerBuffs += powerBuff;
        healthBuffs += healthBuff;

        power += powerBuff;
        health += healthBuff;

        PowerChanged?.Invoke();
        HealthChanged?.Invoke();

    }

    // Reduce monster's health
    public void ReduceHealth(int damageToTake)
    {
        health -= damageToTake;
        HealthChanged?.Invoke();
        if (health <= 0)
        {
            // OnDeath?.Invoke();
            isDead = true;
            Debug.Log($"{name} is dead");
        }
    }

    public void Attack(Monster frontTarget, Monster backTarget, PlayerHealth faceTarget)
    {
        AttackRequested?.Invoke(frontTarget, backTarget, faceTarget);
    }

    [Button]
    public void Kill()
    {
        OnDeath.Invoke();
        Debug.Log($"Kill {name}");
    }

    // Use this to print out the values of this monster.
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
