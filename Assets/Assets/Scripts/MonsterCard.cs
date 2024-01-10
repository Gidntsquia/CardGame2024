// Code written by Jaxon Lee
// 
// Data for one monster card, which can be summoned in a lane, attack, and die
// once it's health goes to 0.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/MonsterCard".
[CreateAssetMenu(fileName = "newMonsterCard", menuName = "CardSystem/MonsterCard", order = 1)]
public class MonsterCard : Card
{
    public int power = 1;
    public int health = 1;

    public override string ToString()
    {
        return $"Card Info:\n" +
               $"Mana Cost: {manaCost}\n" +
               $"Power: {power}\n" +
               $"Health: {health}\n" +
               $"Region: {region}\n" +
               $"Flavor Text: {flavorText}\n";
    }

}
