// Code written by Jaxon Lee
// 
// Data for a deck, which holds up to 40 cards and the player customizes.

using System;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/Deck".
[CreateAssetMenu(fileName = "newDeck", menuName = "CardSystem/Deck", order = 2)]
public class Deck : ScriptableObject
{
    // Number of duplicates of a card that a deck can have
    public const int MAX_COUNT_OF_ONE_CARD = 4;
    public new string name;
    // Unique deck identifier
    public int deckCode;


    [Serializable]
    public class CardAndCount
    {
        public Card card;

        // Take extra care to make sure a deck can never have more than 
        // the max of a single card
        // Ensure count can not exceed the max in the editor
        [SerializeField]
        [Range(1, MAX_COUNT_OF_ONE_CARD)]
        private int _count;

        // Ensure no other code can increase a card's count beyond the max. 
        public int count
        {
            get { return _count; }
            set { _count = Mathf.Clamp(value, 1, MAX_COUNT_OF_ONE_CARD); }
        }
    }

    public CardAndCount[] cards;
}
