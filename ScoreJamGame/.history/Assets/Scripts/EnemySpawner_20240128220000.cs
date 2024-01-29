using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private GameObject[] enemyPrefabs;


    private void Start() {
        StartCoruotine(Spawner());
    }

    private IEnumerator Spawner () {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(int ) {
            yield return wait;
        }
    }
}
