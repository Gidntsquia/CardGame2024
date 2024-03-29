// Code written by Jaxon Lee
// 
// Data for one spell card, which can be played to instantly affect the field.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/SpellCard".
[CreateAssetMenu(fileName = "newSpellCard", menuName = "CardSystem/SpellCard", order = 2)]
public class SpellCard : Card
{
    // Use this to print out the values of this card.
    public override string ToString()
    {
        return $"Card Info:\n" +
               $"Mana Cost: {manaCost}\n" +
               $"Region: {region}\n" +
               $"Flavor Text: {flavorText}\n" +
               $"ID: {inGameID}\n";
    }

}
