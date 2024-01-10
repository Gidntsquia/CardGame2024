// Code by Jaxon Lee
//
// Manages one player's hand, which holds monster and spell cards that can be
// played.

using UnityEngine;

public class Hand : MonoBehaviour
{
    public int handSize;
    public PlayerDeck gameDeck;
    public GameObject cardObject;

    public void draw(int numCardsToDraw)
    {
        for (int i = 0; i < numCardsToDraw; i++)
        {
            // Get the top card of the deck
            Card newCard = gameDeck.pop();

            // Make a new card object and add it to the hand.
            GameObject newCardObject = Instantiate(cardObject);
            newCardObject.transform.SetParent(transform);

            // Display the card's values
            CardDisplayer newCardDisplayer = newCardObject.GetComponent<CardDisplayer>();
            newCardDisplayer.cardIdentity = newCard;
            newCardDisplayer.displayValues();

            // Update hand size
            handSize += 1;
        }
    }

    private void Start()
    {
        draw(5);
    }

}
