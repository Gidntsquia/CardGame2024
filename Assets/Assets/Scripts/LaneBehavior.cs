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
    private MonsterActive heroBack;
    private MonsterActive heroFront;
    private MonsterActive enemyBack;
    private MonsterActive enemyFront;

    public MonsterCard heroTest;
    public MonsterCard enemyTest;

    // Start is called before the first frame update
    void Start()
    {
        createTestMonsters();
        doLaneCombat();
    }

    private void createTestMonsters()
    {
        GameObject heroMonster = Instantiate(monsterPrefab);
        heroMonster.transform.SetParent(nearMonsterSpot);

        heroFront = heroMonster.GetComponent<MonsterActive>();
        heroFront.Initialize(heroTest);

        GameObject enemyMonster = Instantiate(monsterPrefab);
        enemyMonster.transform.SetParent(farMonsterSpot);

        enemyFront = enemyMonster.GetComponent<MonsterActive>();
        enemyFront.Initialize(enemyTest);

    }

    // Do combat for this lane.
    // TODO: Turn this into an IEnumerator and make it a Coroutine f/ animations.
    private void doLaneCombat()
    {
        // Note this order-- this is a key mechanic

        // Handle attacks
        heroFront?.attack(enemyFront, enemyBack, enemyHealthSystem);
        heroBack?.attack(enemyFront, enemyBack, enemyHealthSystem);

        enemyFront?.attack(heroFront, heroBack, heroHealthSystem);
        enemyBack?.attack(heroFront, heroBack, heroHealthSystem);

        // Handle monster deaths
        if (heroFront.isDead)
        {
            Debug.Log($"Hero Front has died: {heroFront}");
            Destroy(heroFront.gameObject);
            heroFront = null;
        }

        // if (heroBack.isDead)
        // {
        //     Debug.Log($"Hero Back has died: {heroBack}");
        //     Destroy(heroBack.gameObject);
        //     heroBack = null;
        // }

        if (enemyFront.isDead)
        {
            Debug.Log($"Enemy Front has died: {enemyFront}");
            Destroy(enemyFront.gameObject);
            enemyFront = null;
        }

        // if (enemyBack.isDead)
        // {
        //     Debug.Log($"Enemy Back has died: {enemyBack}");
        //     Destroy(enemyBack.gameObject);
        //     enemyBack = null;
        // }


    }


}
