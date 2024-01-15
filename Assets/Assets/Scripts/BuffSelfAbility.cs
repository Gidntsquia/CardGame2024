// Code written by Jaxon Lee
// 
// Data for a buff self card effect, which increases the power and health of the
// monster.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/CardAbilitys".
[CreateAssetMenu(fileName = "newBuffSelfAbility", menuName = "Abilities/BuffSelfAbility", order = 2)]
public class BuffSelfAbility : CardAbility
{
    public int powerBuff;
    public int healthBuff;

    public override void OnPlay(MonsterBehavior monsterBehavior)
    {
        monsterBehavior.giveBuff(powerBuff, healthBuff);
    }


}
