using System.Collections;

using UnityEngine;

 public class EnemySpawner : MonoBehaviour {
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private GameObject player; // Reference to the player GameObject

    private void Start()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned to spawner.");
            return;
        }





        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * 3f;
            GameObject enemyInstance = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            // Pass the player reference to the spawned enemy
            enemyInstance.GetComponent<EnemyScript>().player = player;
        }
    }
}