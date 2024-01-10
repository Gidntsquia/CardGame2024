// Code created by Jaxon Lee
//
// Display the data of a card.
using TMPro;
using UnityEngine;

public class CardDisplayer : MonoBehaviour
{
    public TMP_Text healthField;
    public TMP_Text powerField;
    public TMP_Text costField;
    public TMP_Text nameField;
    private Card cardIdentity;

    // Start is called before the first frame update
    void Start()
    {
        // cardIdentity = GetComponent<CardBehavior>().cardIdentity;
        // displayValues();
    }

    public void displayValues()
    {
        switch (cardIdentity)
        {
            case MonsterCard monsterCard:
                healthField.text = monsterCard.health.ToString();
                powerField.text = monsterCard.power.ToString();
                costField.text = monsterCard.manaCost.ToString();

                // Display the image for the MonsterCard if available
                if (monsterCard.image == null && nameField != null)
                {
                    nameField.text = monsterCard.name;
                }
                else
                {

                }
                break;

            case SpellCard spellCard:
                costField.text = spellCard.manaCost.ToString();

                // Display the image for the SpellCard if available
                if (spellCard.image == null && nameField != null)
                {
                    nameField.text = spellCard.name;
                }
                else
                {

                }
                break;

            default:
                Debug.LogError("Unknown card type");
                break;
        }
    }

    public void displayValues(Card card)
    {
        cardIdentity = card;
        switch (card)
        {
            case MonsterCard monsterCard:
                healthField.text = monsterCard.health.ToString();
                powerField.text = monsterCard.power.ToString();
                costField.text = monsterCard.manaCost.ToString();

                // Display the image for the MonsterCard if available
                if (monsterCard.image == null && nameField != null)
                {
                    nameField.text = monsterCard.name;
                }
                else
                {

                }
                break;

            case SpellCard spellCard:
                costField.text = spellCard.manaCost.ToString();

                // Display the image for the SpellCard if available
                if (spellCard.image == null && nameField != null)
                {
                    nameField.text = spellCard.name;
                }
                else
                {

                }
                break;

            default:
                Debug.LogError("Unknown card type");
                break;
        }
    }
}
