// Code created by Jaxon Lee
//
// Handles dragging and summoning a card.

using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public Card cardIdentity;
    public PlayerMana manaTracker;
    private Transform parent;
    private const string LANE_TAG = "Lane";
    private LaneBehavior currLane = null;

    private void Start()
    {
        parent = transform.parent;
        // TODO: Figure out what to do if it's a spell card.
        // TODO: Make CardDragger and MonsterBehavior the authorities on their values
    }

    // Allow card to freely move (by removing it from its parent's layout group)
    private void OnMouseDown()
    {
        transform.SetParent(null);
    }

    // Follow mouse
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    // Summon monster if it's on a lane
    // TODO: Extend this summoning system to spells + add "summon" zones
    private void OnMouseUp()
    {
        if (currLane != null)
        {
            print("Play?");
            if (cardIdentity is MonsterCard && manaTracker.HasEnoughMana(cardIdentity.manaCost))
            {
                print("Yes!");
                // Play the card
                currLane.SummonMonster((MonsterCard)cardIdentity, LaneBehavior.Player.Hero);
                Destroy(gameObject);

                // Use up mana
                manaTracker.ReduceMana(cardIdentity.manaCost);
            }
            else
            {
                transform.SetParent(parent);
            }

        }
        else
        {
            transform.SetParent(parent);
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
