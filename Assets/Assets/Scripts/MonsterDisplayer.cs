// Code by Jaxon Lee
//
// Display data for a monster on the field.
using UnityEngine;
using TMPro;

public class MonsterDisplayer : MonoBehaviour
{
    public MonsterBehavior monsterIdentity;
    public TMP_Text healthField;
    public TMP_Text powerField;
    public TMP_Text nameField;

    // Start is called before the first frame update
    void Start()
    {
        // displayValues();
    }

    private void Update()
    {
        displayValues();
    }

    public void displayValues()
    {
        healthField.text = monsterIdentity.health.ToString();
        powerField.text = monsterIdentity.power.ToString();
        nameField.text = monsterIdentity.monsterName;


        // if (monsterIdentity.image == null && nameField != null)
        // {

        // }
    }
}
