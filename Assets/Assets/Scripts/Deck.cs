// Code written by Jaxon Lee
// 
// Data for a deck, which holds up to 40 cards and the player customizes.

using System;
using System.Collections.Generic;
using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/Deck".
[CreateAssetMenu(fileName = "newDeck", menuName = "CardSystem/Deck", order = 2)]
public class Deck : ScriptableObject
{
    // Number of duplicates a deck can have
    private const int _MAX_COUNT_OF_ONE_CARD = 4;

    // Do this so that other codes can access the max num duplicates,
    // but can't edit it.
    public static int MAX_COUNT_OF_ONE_CARD
    {
        get { return _MAX_COUNT_OF_ONE_CARD; }
        set { }
    }

    public new string name;
    // Unique deck identifier
    public int deckCode;


    [Serializable]
    public class CardAndCount
    {

        public Card card;

        // Take extra care to make sure a deck can never have more than 
        // the max of a single card
        // Ensure count is can not exceed the max in the editor
        [SerializeField]
        [Range(1, _MAX_COUNT_OF_ONE_CARD)]
        private int _count;

        // Ensure no other code can increase a card's count beyond the max. 
        public int count
        {
            get { return _count; }
            set { _count = Mathf.Clamp(value, 1, _MAX_COUNT_OF_ONE_CARD); }
        }
    }

    public CardAndCount[] cards;

    // Prevent duplicates
    // private void OnValidate()
    // {
    //     HashSet<Card> uniqueCards = new HashSet<Card>();
    //     List<CardAndCount> uniqueCardAndCountList = new List<CardAndCount>();

    //     foreach (CardAndCount cardAndCount in cards)
    //     {
    //         if (!uniqueCards.Contains(cardAndCount.card))
    //         {
    //             uniqueCards.Add(cardAndCount.card);
    //             uniqueCardAndCountList.Add(cardAndCount);
    //         }
    //     }

    //     cards = uniqueCardAndCountList.ToArray();
    // }
}
