using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Transform _player;
    private Transform _entitySpawner;
    public SpriteRenderer renderer;

    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _entitySpawner = GameObject.Find("Entity Spawner").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.position;

        Vector3 position = new Vector3(1000,1000,1000);
        foreach(Transform child in _entitySpawner.GetComponentInChildren<Transform>())
        {
            if (Vector3.Distance(_player.transform.position, child.position) < Vector3.Distance(_player.transform.position, position)) position = child.position;
        }

        Vector3 vectorToNearestEnemy = position - transform.position;
        float angle = Mathf.Atan2(vectorToNearestEnemy.y, vectorToNearestEnemy.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (vectorToNearestEnemy.sqrMagnitude < 7f) renderer.enabled = false;
        else renderer.enabled = true;
    }
}
