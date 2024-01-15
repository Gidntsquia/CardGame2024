// Code written by Jaxon Lee
// 
// Data for a card effect, which affects the field in some way.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/CardAbilitys".
// [CreateAssetMenu(fileName = "newCardAbility", menuName = "CardSystem/CardAbility", order = 2)]
public abstract class CardAbility : ScriptableObject
{

    // Brainstorming abilities:
    // Buff self
    // Buff ally
    // Reduce enemy

    public virtual void OnPlay(MonsterBehavior monsterBehavior)
    {
        // Do nothing unless overridden
    }

    public virtual void OnAttack()
    {
        // Do nothing unless overridden
    }

    public virtual void OnDeath()
    {
        // Do nothing unless overridden
    }

}
