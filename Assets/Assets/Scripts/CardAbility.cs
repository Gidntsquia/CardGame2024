// Code written by Jaxon Lee
// 
// Data for a card effect, which affects the field in some way.

using UnityEngine;

// This creates an menu entry in the Unity editor when you right click in the 
// "Project" tab. It's called "CardSystem/CardAbilitys".
// [CreateAssetMenu(fileName = "newCardAbility", menuName = "CardSystem/CardAbility", order = 2)]
public abstract class CardAbility : ScriptableObject
{

    public virtual void OnPlay(MonsterBehavior monsterBehavior)
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Bonus attacks
        // - Gravestone
        // - Conjure
        // - Stat reduction
        // - Anti-Hero
        // - Direct Damage
        // - Bounce

    }

    public virtual void OnAttack()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Conjure
        // - Double Strike -- maybe have a second attack phase for just double strike guys
    }

    public virtual void OnTakeDamage()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Armored
    }

    public virtual void OnDeath()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Last Breath
    }

    public virtual void OnDraw()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Dino-roar
    }

    public virtual void OnTurnStart()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Ramp
    }

    public virtual void OnOpponentPlay()
    {
        // Do nothing unless overridden
    }

    public virtual void OnOpponentMonsterSummoned()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Hunt
    }

    public virtual void OnAttackPhaseStart()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Gravestone (2)
    }

    public virtual void OnHitOpponent()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Conjure
    }

    public virtual void OnOpponentFront()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Anti-Hero (2)
    }

    public virtual void OnOpponentStopsFront()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Anti-Hero (3)
    }

    public virtual void OnDamageMonster()
    {
        // Do nothing unless overridden
        // 
        // Abilities that use this:
        // - Deadly
    }

    // Passive:
    // - Untrickable
    // - Team-up

}
