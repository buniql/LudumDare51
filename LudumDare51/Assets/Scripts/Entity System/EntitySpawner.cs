using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public Transform Player;
    public float PlayerForceField;
    private int CurrentEnemyAmount;
    public int MaxEnemyAmount;

    public int[] probEnemy;

    public GameObject[] Enemys;

    private void Start()
    {
        CurrentEnemyAmount = 0;
    }

    void FixedUpdate()
    {
        if (CurrentEnemyAmount < MaxEnemyAmount)
            SpawnEnemy();

        CurrentEnemyAmount = transform.childCount;
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-100f, 100f), Random.Range(-80f, 80f), 0f);

        while(Vector3.Distance(randomPosition,Player.transform.position) < PlayerForceField)
            randomPosition = new Vector3(Random.Range(-100f, 100f), Random.Range(-80f, 80f), 0f);

        int index = 0;
        int sum = 0;
        for(int i = 0; i < probEnemy.Length; i++)
        {
            sum += probEnemy[i];
        }
        int value = Random.Range(0, sum);
        for (int i = 1; i < probEnemy.Length; i++)
        {
            if(value >= probEnemy[i - 1] && value < probEnemy[i]) index = i;
        }

            GameObject enemy = GameObject.Instantiate(Enemys[Random.Range(0, Enemys.Length - 1)], randomPosition, Quaternion.identity);
        enemy.transform.parent = GameObject.Find("Entity Spawner").transform;
        CurrentEnemyAmount++;
    }
}
