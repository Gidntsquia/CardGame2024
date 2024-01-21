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

            // // Handle attacks based on the player
            // PlaySpot[] opponentPlaySpots = playSpot.GetOpponentPlaySpots();

            // Monster opponentFrontMonster = GetMonsterOrNull(opponentPlaySpots[0]);
            // Monster opponentBackMonster = GetMonsterOrNull(opponentPlaySpots[1]);
            // PlayerHealth opponentHealth = playSpot.playerSide == Player.Hero ? heroHealthSystem : enemyHealthSystem;

            // Attack the opponent monsters or health
            monster.Attack(laneIdentity);
            // switch (player)
            // {
            //     case Player.Hero:
            //         monster.attack(laneMap.TryGetValue((Player.Enemy, Location.Front),
            //                             out MonsterBehavior enemyFrontMonster) ? enemyFrontMonster : null,
            //                         laneMap.TryGetValue((Player.Enemy, Location.Back),
            //                             out MonsterBehavior enemyBackMonster) ? enemyBackMonster : null,
            //                         enemyHealthSystem);
            //         break;

            //     case Player.Enemy:
            //         monster.attack(laneMap.TryGetValue((Player.Hero, Location.Front),
            //                             out MonsterBehavior heroFrontMonster) ? heroFrontMonster : null,
            //                         laneMap.TryGetValue((Player.Hero, Location.Back),
            //                             out MonsterBehavior heroBackMonster) ? heroBackMonster : null,
            //                         heroHealthSystem);
            //         break;
            // }


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
            monster.Kill();
            // laneIdentity.laneMonsterMap.Remove(playSpot);
        }
    }

    // Returns either the monster in the playSpot or null if none is there.
    // private Monster GetMonsterOrNull(PlaySpot playSpot)
    // {
    //     return laneIdentity.laneMonsterMap.TryGetValue(playSpot,
    //         out Monster attemptedGetValue)
    //         ? attemptedGetValue : null;
    // }

}
