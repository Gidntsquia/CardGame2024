// Code written by Jaxon Lee
// 
// Data for one monster card, which can be summoned to a lane and save buffs.

using NaughtyAttributes;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/MonsterCard".
[CreateAssetMenu(fileName = "newMonsterCard", menuName = "CardSystem/MonsterCard", order = 1)]
public class MonsterCard : Card
{
    public int power = 1;
    public int health = 1;

    // TODO: Better way to instantiate a blank scriptable object?
    public Monster baseMonsterSO;
    public Monster myMonster;

    public new void OnEnable()
    {
        base.OnEnable();
        myMonster = Instantiate(baseMonsterSO);
        myMonster.name = this.name;
        myMonster.abilities = this.cardAbilities;
        myMonster.basePower = this.power;
        myMonster.baseHealth = this.health;
        myMonster.power = this.power;
        myMonster.health = this.health;
        myMonster.image = this.image;
        myMonster.powerBuffs = 0;
        myMonster.healthBuffs = 0;
        myMonster.isDead = false;
        myMonster.monsterCardIdentity = this;

    }

    [Button]
    public void PrintName()
    {
        Debug.Log(myMonster.name);
    }


    public override string ToString()
    {
        return $"Card Info:\n" +
               $"Mana Cost: {manaCost}\n" +
               $"Power: {power}\n" +
               $"Health: {health}\n" +
               $"Region: {region}\n" +
               $"Flavor Text: {flavorText}\n" +
               $"ID: {inGameID}\n";
    }

}
