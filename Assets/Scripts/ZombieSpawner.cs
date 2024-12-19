using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Prefab zombíka
    public float minTime = 3.0f; // Minimální interval mezi spawnováním
    public float maxTime = 10.0f; // Maximální interval mezi spawnováním
    public Transform player; // Reference na hráče

    private Coroutine spawnCoroutine;

    private void OnEnable()
    {
        spawnCoroutine = StartCoroutine(SpawnZombies());
    }

    private void OnDisable()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator SpawnZombies()
    {
        while (true)
        {
            // Náhodný interval mezi minTime a maxTime
            float spawnInterval = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(spawnInterval);

            // Spawnuj zombíka na pozici spawneru
            GameObject zombie = Instantiate(zombiePrefab, transform.position, transform.rotation);

            // Nastav target zombíka na hráče
            EnemyObject enemyObject = zombie.GetComponent<EnemyObject>();
            if (enemyObject != null)
            {
                enemyObject.target = player;
            }
        }
    }
}