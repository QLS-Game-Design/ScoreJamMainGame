using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    public speed 


    private void Start() {
        StartCoruotine(Spawner());
    }

    private IEnumerator Spawner () {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(int object.GetHashCode()) {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.Identity);
        }
    }
}
