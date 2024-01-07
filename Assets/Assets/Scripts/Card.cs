// Code written by Jaxon Lee
// 
// Data for one card, which fills out a deck and can be played.

using UnityEngine;
using UnityEngine.UI;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/Card".
[CreateAssetMenu(fileName = "newCard", menuName = "CardSystem/Card", order = 1)]
public class Card : ScriptableObject
{
    public int manaCost = 1;
    public int power = 1;
    public int health = 1;
    // TODO: Add this
    // public CardAbility cardAbility;
    public enum Region
    {
        RazorShells,
        TitanFins,
        HiddenHoard,
        TinyDivision,
        TacticalTentacles
    }

    public Region region;

    [TextArea]
    public string flavorText = "";
    public Image image;

    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    public Rarity rarity = Rarity.Common;
}
