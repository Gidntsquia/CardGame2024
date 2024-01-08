// Code created by Jaxon Lee
//
// Display the data of a card.
using TMPro;
using UnityEngine;

public class CardDisplayer : MonoBehaviour
{
    public Card cardIdentity;
    public TMP_Text healthField;
    public TMP_Text powerField;
    public TMP_Text costField;
    public TMP_Text nameField;
    // public 

    // Start is called before the first frame update
    void Start()
    {
        healthField.text = cardIdentity.health.ToString();
        powerField.text = cardIdentity.power.ToString();
        costField.text = cardIdentity.manaCost.ToString();
        if (cardIdentity.image == null && nameField != null)
        {
            nameField.text = cardIdentity.name;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
