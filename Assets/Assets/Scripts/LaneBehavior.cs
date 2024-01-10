// Code by Jaxon Lee
// 
// Handles all the behavior of one lane, including lane combat.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBehavior : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform nearMonsterSpot;
    public Transform farMonsterSpot;
    public HealthSystem heroHealthSystem;
    public HealthSystem enemyHealthSystem;
    // private MonsterActive heroBack;
    // private MonsterActive heroFront;
    // private MonsterActive enemyBack;
    // private MonsterActive enemyFront;

    public MonsterCard heroTest;
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

    private Dictionary<(Player, Location), MonsterActive> monstersMap =
            new Dictionary<(Player, Location), MonsterActive>();

    // Summon a monster at a particular location
    public void summonMonster(MonsterCard monsterCardData, Player player, Location location)
    {
        // Destroy existing monster
        if (monstersMap.TryGetValue((player, location), out MonsterActive existingMonster))
        {
            Destroy(existingMonster.gameObject);
        }

        // Create a new monster
        GameObject monsterObject = Instantiate(monsterPrefab);

        // Set its parent based on the location
        Transform monsterSpot = player == Player.Hero ? nearMonsterSpot : farMonsterSpot;
        monsterObject.transform.SetParent(monsterSpot);

        // Get the MonsterActive component and initialize it
        MonsterActive monster = monsterObject.GetComponent<MonsterActive>();
        monster.Initialize(monsterCardData);

        // Store the monster in the dictionary
        monstersMap[(player, location)] = monster;
    }


    // Summon the monster in the front position.
    public void summonMonster(MonsterCard monsterCardData, Player player)
    {
        summonMonster(monsterCardData, player, Location.Front);
    }

    private void Start()
    {
        // createTestMonsters();
        // doLaneCombat();
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
        summonMonster(heroTest, Player.Hero, Location.Front);

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

    private void processAttack(Player player, Location location)
    {
        if (monstersMap.TryGetValue((player, location), out MonsterActive monster))
        {
            // Skip monsters that are null or dead
            if (monster == null || monster.isDead)
                return;

            // Handle attacks based on the player
            switch (player)
            {
                case Player.Hero:
                    monster.attack(monstersMap.TryGetValue((Player.Enemy, Location.Front), out var enemyFrontMonster) ? enemyFrontMonster : null,
                                    monstersMap.TryGetValue((Player.Enemy, Location.Back), out var enemyBackMonster) ? enemyBackMonster : null,
                                    enemyHealthSystem);
                    break;

                case Player.Enemy:
                    monster.attack(monstersMap.TryGetValue((Player.Hero, Location.Front), out var heroFrontMonster) ? heroFrontMonster : null,
                                    monstersMap.TryGetValue((Player.Hero, Location.Back), out var heroBackMonster) ? heroBackMonster : null,
                                    heroHealthSystem);
                    break;
            }


        }
    }

    private void processDeath(Player player, Location location)
    {
        if (monstersMap.TryGetValue((player, location), out MonsterActive monster))
        {
            // Skip monsters that are null or alive
            if (monster == null || !monster.isDead)
                return;

            Debug.Log($"{player} {location} has died: {monster}");
            Destroy(monster.gameObject);
            monstersMap.Remove((player, location));
        }
    }




}
