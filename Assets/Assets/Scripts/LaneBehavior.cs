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
    }

    private void createTestMonsters()
    {
        GameObject heroMonster = Instantiate(monsterPrefab);
        heroMonster.transform.parent = nearMonsterSpot;

        heroFront = heroMonster.GetComponent<MonsterActive>();
        heroFront.Initialize(heroTest);

        GameObject enemyMonster = Instantiate(monsterPrefab);
        enemyMonster.transform.parent = farMonsterSpot;

        enemyFront = enemyMonster.GetComponent<MonsterActive>();
        enemyFront.Initialize(enemyTest);

    }


}
