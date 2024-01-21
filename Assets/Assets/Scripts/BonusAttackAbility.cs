// Code written by Jaxon Lee
// 
// Data for a buff self card effect, which increases the power and health of the
// monster.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called Abilities/BonusAttackAbility".
[CreateAssetMenu(fileName = "newBonusAttackAbility", menuName = "Abilities/BonusAttackAbility", order = 2)]
public class BonusAttackAbility : CardAbility
{
    public int numBonusAttacks = 1;

    public override void OnPlay(Monster monsterToDoBonusAttack)
    {
        Debug.Log("Bonus ability triggered");

        // Have the mosnter do an attack in its lane
        monsterToDoBonusAttack.Attack(monsterToDoBonusAttack.currLane);
    }


}
