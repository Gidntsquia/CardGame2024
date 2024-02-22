// Code by Jaxon Lee
// 
// Handles all the behavior of one lane, including lane combat.

using NaughtyAttributes;
using UnityEngine;
using static Lane;

public class LaneBehavior : MonoBehaviour
{
    public Lane laneIdentity;
    public GameObject monsterPrefab;
    public Transform heroMonsterSpot;
    public Transform enemyMonsterSpot;
    public PlayerHealth heroHealthSystem;
    public PlayerHealth enemyHealthSystem;
    public MonsterCard heroTest;
    public MonsterCard enemyTest;

    private void OnEnable()
    {
        laneIdentity.BounceRequested += BounceToHand;
    }

    private void OnDisable()
    {
        laneIdentity.BounceRequested -= BounceToHand;
    }


    // Summon a monster at a particular location
    public void SummonMonster(MonsterCard monsterCardData, PlaySpot playSpot)
    {
        // Destroy existing monster
        if (laneIdentity.laneMonsterMap.TryGetValue(playSpot, out Monster existingMonster))
        {
            print($"Error: monster already in {name}");
            return;
        }
        print($"Creating Monster: {monsterCardData.myMonster}");

        // Create a new monster
        GameObject monsterObject = Instantiate(monsterPrefab);
        monsterObject.name = monsterCardData.name;

        // Set its parent based on the location
        Transform monsterSpot = playSpot.playerSide == Player.Hero ? heroMonsterSpot : enemyMonsterSpot;
        monsterObject.transform.SetParent(monsterSpot);

        // Initialize monster's location data
        monsterCardData.myMonster.currLane = laneIdentity;
        monsterCardData.myMonster.currPlaySpot = playSpot;

        // Get the MonsterBehavior component and initialize it
        MonsterBehavior monsterBehavior = monsterObject.GetComponent<MonsterBehavior>();
        monsterBehavior.Initialize(monsterCardData.myMonster);

        // Get the MonsterDisplayer component and initialize it
        MonsterDisplayer monsterDisplayer = monsterObject.GetComponent<MonsterDisplayer>();
        monsterDisplayer.Initialize(monsterCardData.myMonster);

        // Store the monster in the dictionary
        laneIdentity.laneMonsterMap[playSpot] = monsterCardData.myMonster;

        // TODO: Add targeting system for abilities
        // Apply OnPlay abilities
        monsterCardData.cardAbilities?.ForEach(ability => ability.OnPlay(monsterCardData.myMonster));

    }


    // Summon the monster in the front position on the given player's side.
    public void SummonMonster(MonsterCard monsterCardData, Player player)
    {
        SummonMonster(monsterCardData, new PlaySpot(player, Position.Front));
    }


    // Manually create a hero and enemy monster for testing purposes.
    [Button]
    private void CreateTestMonsters()
    {
        if (heroTest != null)
        {
            // Create hero monster
            MonsterCard newHeroTest = Instantiate(heroTest);
            SummonMonster(newHeroTest, Player.Hero);

            // Reset values
            Monster heroTestMonster = laneIdentity.GetMonsterOrNull(new PlaySpot(Player.Hero, Position.Front));
            heroTestMonster.power = heroTestMonster.basePower;
            heroTestMonster.health = heroTestMonster.baseHealth;
        }
        if (enemyTest != null)
        {
            // Create enemy monster
            MonsterCard newEnemyTest = Instantiate(enemyTest);
            SummonMonster(newEnemyTest, Player.Enemy);

            // Reset values
            Monster enemyTestMonster = laneIdentity.GetMonsterOrNull(new PlaySpot(Player.Enemy, Position.Front));
            enemyTestMonster.power = enemyTestMonster.basePower;
            enemyTestMonster.health = enemyTestMonster.baseHealth;
        }

    }


    // Do combat for this lane.
    // TODO: Turn this into an IEnumerator and make it a Coroutine f/ animations.
    [Button]
    private void DoLaneCombat()
    {
        print("Combat!");
        // Note this order-- this is a key mechanic
        ProcessAttack(Player.Hero, Position.Front);
        ProcessAttack(Player.Hero, Position.Back);
        ProcessAttack(Player.Enemy, Position.Front);
        ProcessAttack(Player.Enemy, Position.Back);

        // Only kill monsters after all of them have had a turn.
        ProcessDeath(Player.Hero, Position.Front);
        ProcessDeath(Player.Hero, Position.Back);
        ProcessDeath(Player.Enemy, Position.Front);
        ProcessDeath(Player.Enemy, Position.Back);
    }

    // Apply attack for a monster a particular location.
    private void ProcessAttack(Player player, Position location)
    {
        PlaySpot playSpot = new PlaySpot(player, location);

        if (laneIdentity.laneMonsterMap.TryGetValue(playSpot, out Monster monster))
        {
            // Skip if there is no monster here
            if (monster == null)
                return;

            monster.Attack(laneIdentity);
        }
    }

    // Kill any monsters that have died.
    // TODO: Play a death animation here if monster dies. 
    private void ProcessDeath(Player player, Position location)
    {
        PlaySpot playSpot = new PlaySpot(player, location);

        if (laneIdentity.laneMonsterMap.TryGetValue(playSpot, out Monster monster))
        {
            // Skip monsters that are null or alive
            if (monster == null || !monster.isDead)
                return;

            Debug.Log($"{player} {location} has died: {monster}");

            // Remove monster from lane monster map.
            laneIdentity.laneMonsterMap.Remove(playSpot);

            // Instruct monster to kill itself 😳
            monster.Kill();
        }
    }

    public void BounceToHand(PlaySpot monsterPlaySpot)
    {
        if (laneIdentity.laneMonsterMap.TryGetValue(monsterPlaySpot, out Monster monster))
        {
            Hand handDestination = null;

            switch (monsterPlaySpot.playerSide)
            {
                case Player.Hero:
                    handDestination = laneIdentity.heroHand;
                    break;
                case Player.Enemy:
                    handDestination = laneIdentity.enemyHand;
                    break;
            }

            // Add card back to hand.
            monster.ResetBuffs();
            monster.Bounce();
            handDestination.AddCard(monster.monsterCardIdentity);

            // Remove monster from lane monster map.
            laneIdentity.laneMonsterMap.Remove(monsterPlaySpot);
        }
    }

    // Finds the playspot of a monster in the lane monster map.
    public PlaySpot FindMonster(Monster monster)
    {
        PlaySpot result = null;
        foreach (PlaySpot playSpot in laneIdentity.laneMonsterMap.Keys)
        {
            if (laneIdentity.laneMonsterMap[playSpot] == monster)
            {
                result = playSpot;
                break;
            }

        }

        if (result == null)
        {
            throw new System.Exception("Couldn't find monster: " + monster);
        }

        return result;
    }

}
