// Code written by Jaxon Lee
// 
// Data for one spell card, which can be played to instantly affect the field.

using UnityEngine;
using UnityEngine.UI;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/SpellCard".
[CreateAssetMenu(fileName = "newSpellCard", menuName = "CardSystem/SpellCard", order = 1)]
public class SpellCard : Card
{
    public override string ToString()
    {
        return $"Card Info:\n" +
               $"Mana Cost: {manaCost}\n" +
               $"Region: {region}\n" +
               $"Flavor Text: {flavorText}\n";
    }

}
