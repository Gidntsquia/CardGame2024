// Code by Jaxon Lee
// 
// Handles all the behavior of one lane, including lane combat.

using System.Collections.Generic;
using UnityEngine;

public class LaneBehavior : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform heroMonsterSpot;
    public Transform enemyMonsterSpot;
    public PlayerHealth heroHealthSystem;
    public PlayerHealth enemyHealthSystem;
    // public MonsterCard heroTest;
    public MonsterCard enemyTest;

    public enum Player
    {
        Hero,
        Enemy
    }

    public enum Location
    {
        Front,
        Back
    }

    // Each of the 4 locations can be saved to this map.
    private Dictionary<(Player, Location), MonsterBehavior> laneMap =
            new Dictionary<(Player, Location), MonsterBehavior>();


    // Summon a monster at a particular location
    public void summonMonster(MonsterCard monsterCardData, Player player, Location location)
    {
        // Destroy existing monster
        if (laneMap.TryGetValue((player, location), out MonsterBehavior existingMonster))
        {
            Destroy(existingMonster.gameObject);
        }

        // Create a new monster
        GameObject monsterObject = Instantiate(monsterPrefab);

        // Set its parent based on the location
        Transform monsterSpot = player == Player.Hero ? heroMonsterSpot : enemyMonsterSpot;
        monsterObject.transform.SetParent(monsterSpot);

        // Get the MonsterBehavior component and initialize it
        MonsterBehavior monster = monsterObject.GetComponent<MonsterBehavior>();
        monster.Initialize(monsterCardData);

        // Store the monster in the dictionary
        laneMap[(player, location)] = monster;
    }


    // Summon the monster in the front position.
    public void summonMonster(MonsterCard monsterCardData, Player player)
    {
        summonMonster(monsterCardData, player, Location.Front);
    }

    private void Start()
    {
        createTestMonsters();
    }


    private void Update()
    {
        // TODO: Remove this 
        // Debugging command
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("Combat!");
            doLaneCombat();
        }
    }

    // Manually create a hero and enemy monster for testing purposes.
    private void createTestMonsters()
    {
        // Create hero monster
        // summonMonster(heroTest, Player.Hero, Location.Front);

        // Create enemy monster
        summonMonster(enemyTest, Player.Enemy, Location.Front);
    }



    // Do combat for this lane.
    // TODO: Turn this into an IEnumerator and make it a Coroutine f/ animations.
    private void doLaneCombat()
    {
        // Note this order-- this is a key mechanic
        processAttack(Player.Hero, Location.Front);
        processAttack(Player.Hero, Location.Back);
        processAttack(Player.Enemy, Location.Front);
        processAttack(Player.Enemy, Location.Back);


        processDeath(Player.Hero, Location.Front);
        processDeath(Player.Hero, Location.Back);
        processDeath(Player.Enemy, Location.Front);
        processDeath(Player.Enemy, Location.Back);
    }

    // Apply attack for a monster a particular location.
    private void processAttack(Player player, Location location)
    {
        if (laneMap.TryGetValue((player, location), out MonsterBehavior monster))
        {
            // Skip if there is no monster here
            if (monster == null)
                return;

            // Handle attacks based on the player
            switch (player)
            {
                case Player.Hero:
                    monster.attack(laneMap.TryGetValue((Player.Enemy, Location.Front),
                                        out MonsterBehavior enemyFrontMonster) ? enemyFrontMonster : null,
                                    laneMap.TryGetValue((Player.Enemy, Location.Back),
                                        out MonsterBehavior enemyBackMonster) ? enemyBackMonster : null,
                                    enemyHealthSystem);
                    break;

                case Player.Enemy:
                    monster.attack(laneMap.TryGetValue((Player.Hero, Location.Front),
                                        out MonsterBehavior heroFrontMonster) ? heroFrontMonster : null,
                                    laneMap.TryGetValue((Player.Hero, Location.Back),
                                        out MonsterBehavior heroBackMonster) ? heroBackMonster : null,
                                    heroHealthSystem);
                    break;
            }


        }
    }

    // Kill any monsters that have died.
    // TODO: Play a death animation here if monster dies. 
    private void processDeath(Player player, Location location)
    {
        if (laneMap.TryGetValue((player, location), out MonsterBehavior monster))
        {
            // Skip monsters that are null or alive
            if (monster == null || !monster.isDead)
                return;

            Debug.Log($"{player} {location} has died: {monster}");
            Destroy(monster.gameObject);
            laneMap.Remove((player, location));
        }
    }

}
