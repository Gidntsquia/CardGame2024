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
    private Monster monsterIdentity;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add this
        // PlaySummonAnimation();

        DisplayValues();
        monsterIdentity.PowerChanged += UpdatePower;
        monsterIdentity.HealthChanged += UpdateHealth;
        monsterIdentity.OnDeath += PlayDeathAnimation;
    }

    // Play monster's sunmmoning animaiton.
    public void PlaySummonAnimation()
    {

    }

    // Display the monster's stats.
    public void DisplayValues()
    {
        healthField.text = monsterIdentity.health.ToString();
        powerField.text = monsterIdentity.power.ToString();
        nameField.text = monsterIdentity.monsterName;
        gameObject.name = monsterIdentity.monsterName;
    }


    public void UpdatePower()
    {
        powerField.text = monsterIdentity.power.ToString();
    }


    public void UpdateHealth()
    {
        healthField.text = monsterIdentity.health.ToString();
    }


    // Play monster's death animaiton.
    public void PlayDeathAnimation()
    {

    }


    // Callback called when this component is destroyed.
    private void OnDestroy()
    {
        // Clean up event subscriptions on des
        monsterIdentity.PowerChanged -= UpdatePower;
        monsterIdentity.HealthChanged -= UpdateHealth;
        monsterIdentity.OnDeath -= PlayDeathAnimation;
    }
}
