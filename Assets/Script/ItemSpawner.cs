using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnItemsWithDelay());
    }

    IEnumerator SpawnItemsWithDelay()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int rand = Random.Range(0, itemPrefabs.Length);
            GameObject itemToSpawn = itemPrefabs[rand];

            SpawnItemWithDelay(itemToSpawn);
        }
    }

    void SpawnItemWithDelay(GameObject itemPrefab)
    {
        float delay = Random.Range(1f, 5f); // Justera efter behov

        StartCoroutine(SpawnItemAfterDelay(itemPrefab, delay));
    }

    IEnumerator SpawnItemAfterDelay(GameObject itemPrefab, float delay)
    {
        yield return new WaitForSeconds(delay);

        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}
