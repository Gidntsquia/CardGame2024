// Code by Jaxon Lee
//
// Display a monster's stats. Must be attached to an object
// with a MonsterBehavior component.

using UnityEngine;
using TMPro;

public class MonsterDisplayer : MonoBehaviour
{
    public TMP_Text healthField;
    public TMP_Text powerField;
    public TMP_Text nameField;
    private MonsterBehavior monsterIdentity;

    // Start is called before the first frame update
    void Start()
    {
        monsterIdentity = GetComponent<MonsterBehavior>();

        // TODO: Change this to an event
        displayValues();
    }

    // Display the monster's stats.
    public void displayValues()
    {
        healthField.text = monsterIdentity.health.ToString();
        powerField.text = monsterIdentity.power.ToString();
        nameField.text = monsterIdentity.monsterName;
    }
}
