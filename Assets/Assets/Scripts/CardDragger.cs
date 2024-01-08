// Code created by Jaxon Lee
//
// Handles dragging and dropping a card.

using UnityEngine;

public class CardDragger : MonoBehaviour
{
    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
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
        print(mousePosition);
    }

    private void OnMouseUp()
    {
        transform.SetParent(parent);
    }
}
