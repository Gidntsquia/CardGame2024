// Code written by Jaxon Lee
// 
// Data for a buff self card effect, which increases the power and health of the
// monster.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called Abilities/newBounceAbility".
[CreateAssetMenu(fileName = "newBounceAbility", menuName = "Abilities/BounceAbility", order = 3)]
public class BounceAbility : CardAbility
{

    public override void OnPlay(Monster monsterToBounce)
    {
        // Tell the monster's lane to bounce the monster.
        monsterToBounce.currLane.RequestBounce(monsterToBounce.currPlaySpot);
    }


}
