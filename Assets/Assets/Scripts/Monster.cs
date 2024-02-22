// Code written by Jaxon Lee
// 
// Data for a monster, which has stats, can attack, and can die.

using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using static Lane;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/Monster".
[CreateAssetMenu(fileName = "newMonster", menuName = "CardSystem/Monster", order = 3)]
public class Monster : ScriptableObject
{
    public MonsterCard monsterCardIdentity;
    public List<CardAbility> abilities;
    public int basePower;
    public int baseHealth;
    public Image image;

    public string monsterName;
    public int power;
    public int health;
    public int powerBuffs;
    public int healthBuffs;
    public bool isDead = false;
    public Lane currLane;
    public PlaySpot currPlaySpot;

    // // The hand corresponding to the player who controls this monster.
    // public Hand hand;

    public event Action PowerChanged;
    public event Action HealthChanged;
    public event Action DeathRequested;
    public event Action BounceRequested;
    public event Action<Lane> AttackRequested;


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


    // Reset all buffs on monster
    public void ResetBuffs()
    {
        powerBuffs = 0;
        healthBuffs = 0;

        power = basePower;
        health = baseHealth;

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

    public void Attack(Lane laneToAttack)
    {
        AttackRequested?.Invoke(laneToAttack);
    }

    [Button]
    public void Kill()
    {
        Debug.Log($"Kill {name}");

        // Apply OnDeath abilities
        abilities?.ForEach(ability => ability.OnDeath());

        DeathRequested?.Invoke();

    }

    [Button]
    public void Bounce()
    {
        BounceRequested?.Invoke();
    }

    // Use this to print out the values of this monster.
    public override string ToString()
    {
        return $"Monster Info:\n" +
               $"Base Power: {basePower}, " +
               $"Base Health: {baseHealth}, " +
               $"Image: {image}, " +
               $"Power Buffs: {powerBuffs}, " +
               $"Health Buffs: {healthBuffs}, " +
               $"Current Power: {power}, " +
               $"Current Health: {health}";
    }
}
