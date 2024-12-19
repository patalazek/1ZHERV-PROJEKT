using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Pole prefabů itemů (battery, glowstickPack, medkit, ammobag)
    public float minTime = 3.0f; // Minimální interval mezi spawnováním
    public float maxTime = 10.0f; // Maximální interval mezi spawnováním
    public Transform[] spawnPoints; // Pole platných spawnovacích bodů
    public float spawnRadius = 1.0f; // Poloměr kolem spawnovacího bodu, ve kterém se item může spawnovat
    public Transform player; // Reference na hráče

    private void Start()
    {
        StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        while (true)
        {
            // Náhodný interval mezi minTime a maxTime 
            float spawnInterval = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(spawnInterval);

            // Vyber náhodný prefab itemu
            GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

            // Vyber náhodný spawnovací bod
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Náhodná pozice kolem spawnovacího bodu
            Vector3 randomPosition = spawnPoint.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            randomPosition.z = -1; // Nastav z souřadnici na -1

            // Spawnuj item na náhodné pozici kolem spawnovacího bodu
            GameObject spawnedItem = Instantiate(itemPrefab, randomPosition, Quaternion.identity);

            // Pokud je item ammobag, nastav referenci na hráče
            ammoBag ammobag = spawnedItem.GetComponent<ammoBag>();
            if (ammobag != null)
            {
                Gun playerGun = player.GetComponent<Gun>();
                if (playerGun != null)
                {
                    ammobag.gun = playerGun;
                }
            }
        }
    }
}