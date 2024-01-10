// Code created by Jaxon Lee
//
// Handles dragging and dropping a card.

using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public Card cardIdentity;
    private Transform parent;
    private const string LANE_TAG = "Lane";
    private LaneBehavior currLane = null;

    private void Start()
    {
        parent = transform.parent;
        // TODO: Figure out what to do if it's a spell card.
        // TODO: Make CardDragger and MonsterBehavior the authorities on their values
    }

    private void OnMouseDown()
    {
        transform.SetParent(null);
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    private void OnMouseUp()
    {
        if (currLane != null)
        {
            print("Play?");
            if (cardIdentity is MonsterCard)
            {
                print("Yes!");
                // Play the card
                currLane.summonMonster((MonsterCard)cardIdentity, LaneBehavior.Player.Hero);
                Destroy(gameObject);
            }

        }
        else
        {
            transform.SetParent(parent);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        // print("Collide!");
        if (other.transform.tag == LANE_TAG)
        {
            currLane = other.transform.GetComponent<LaneBehavior>();
            print($"I'm on {other.transform.name}");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // Remove curr lane if we just left it.
        if (currLane == other.transform.GetComponent<LaneBehavior>())
        {
            currLane = null;
        }
    }
}
