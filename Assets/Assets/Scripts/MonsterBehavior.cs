// Code by Jaxon Lee
//
// Hold data for a monster that was summoned to the field. Tracks it's stats,
// including current health.

using NaughtyAttributes;
using UnityEngine;
using static Lane;

public class MonsterBehavior : MonoBehaviour
{
    [Expandable]
    public Monster monsterIdentity;

    public void Initialize(Monster monsterIdentity)
    {
        this.monsterIdentity = monsterIdentity;

        // Subscribe to attack event
        monsterIdentity.AttackRequested += Attack;
    }

    // Deal damage to the frontmost enemy, otherwise deal damage to the 
    // opponent's face.
    public void Attack(Lane lane)
    {
        (Monster opponentFront, Monster opponentBack) =
                    lane.GetOpponentMonsters(monsterIdentity.currPlaySpot.playerSide);
        PlayerHealth opponentHealth = monsterIdentity.currPlaySpot.playerSide == Player.Hero
                                        ? lane.enemyHealth : lane.heroHealth;

        if (opponentFront != null)
        {
            opponentFront.ReduceHealth(monsterIdentity.power);
        }
        else if (opponentBack != null)
        {
            opponentBack.ReduceHealth(monsterIdentity.power);
        }
        else
        {
            opponentHealth.TakeDamage(monsterIdentity.power);
        }

    }


    // Use this to print out the values of this card.
    public override string ToString()
    {
        return monsterIdentity.ToString();
    }

    // Callback called when this component is destroyed.
    private void OnDestroy()
    {
        // Clean up event subscriptions on destruction
        monsterIdentity.AttackRequested -= Attack;
    }
}
