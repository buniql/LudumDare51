using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public Transform Player;
    public float PlayerForceField;
    private int CurrentEnemyAmount;
    public int MaxEnemyAmount;

    public GameObject[] Enemys;

    private void Start()
    {
        CurrentEnemyAmount = 0;
    }

    void FixedUpdate()
    {
        if (CurrentEnemyAmount < MaxEnemyAmount)
            SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized * Random.Range(PlayerForceField, 5* PlayerForceField);

        GameObject enemy = GameObject.Instantiate(Enemys[Random.Range(0, Enemys.Length - 1)], Player.transform.position + randomPosition, Quaternion.identity);
        enemy.transform.parent = GameObject.Find("Entity Spawner").transform;
        CurrentEnemyAmount++;
    }
}
