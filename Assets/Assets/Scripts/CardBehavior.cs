// Code created by Jaxon Lee
//
// Handles dragging and summoning a card.

using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public Card cardIdentity;
    public PlayerMana manaTracker;
    private Transform originalParent;
    private const string LANE_TAG = "Lane";
    private LaneBehavior currLane = null;

    private void Start()
    {
        originalParent = transform.parent;
        // TODO: Figure out what to do if it's a spell card.
        // TODO: Make CardDragger and MonsterBehavior the authorities on their values
    }


    private void OnMouseDown()
    {
        // Allow card to freely move (by removing it from its parent's layout group)
        transform.SetParent(null);
    }


    private void OnMouseDrag()
    {
        // Follow mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }


    private void OnMouseUp()
    {
        // Summon monster or spell if they're in a lane.
        switch (cardIdentity)
        {
            case MonsterCard monsterCard:
                if (currLane != null && manaTracker.HasEnoughMana(monsterCard.manaCost))
                {
                    print($"Play monster to {currLane.name}");

                    // Play the card
                    currLane.SummonMonster(monsterCard, LaneBehavior.Player.Hero);
                    Destroy(gameObject);

                    // Apply ability
                    // monsterCard.cardAbility?.OnPlay();

                    // Use up mana
                    manaTracker.ReduceMana(monsterCard.manaCost);

                }
                else
                {
                    transform.SetParent(originalParent);
                }
                break;

            case SpellCard spellCard:
                // Only play spell if it's over a lane. This is the PvZ: Heroes 
                // approach
                if (currLane != null && manaTracker.HasEnoughMana(spellCard.manaCost))
                {
                    print($"Play spell to {currLane.name}");
                    // TODO: Add some sort of animation

                    // Play the card
                    Destroy(gameObject);

                    // Use up mana
                    manaTracker.ReduceMana(spellCard.manaCost);
                }
                else
                {
                    transform.SetParent(originalParent);
                }

                break;
        }
    }



    // This callback is triggered whenver the card collides with another 
    // collider2D.
    // TODO: Maybe reduce card hitbox while being dragged?
    private void OnCollisionEnter2D(Collision2D other)
    {
        // If card hitbox is over lane, save the lane's information
        if (other.transform.tag == LANE_TAG)
        {
            currLane = other.transform.GetComponent<LaneBehavior>();
            print($"I'm on {other.transform.name}");
        }
    }

    // This callback is triggered whenver the card stops colliding with another 
    // collider2D.
    private void OnCollisionExit2D(Collision2D other)
    {
        // Remove saved lane information if we just left it.
        if (currLane == other.transform.GetComponent<LaneBehavior>())
        {
            currLane = null;
        }
    }
}
