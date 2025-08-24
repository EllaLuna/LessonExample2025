using UnityEngine;
using System.Collections;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] GameObject collectablePrefab;
    [SerializeField] int spawnAmount = 10;
    [SerializeField] float spawnDelayMin = 0.1f;
    [SerializeField] float spawnDelayMax = 0.5f;
    [SerializeField] Transform minBound;
    [SerializeField] Transform maxBound;

    void Start()
    {
        StartCoroutine(SpawnCoinsOverTime());
        InvokeRepeating(nameof(ExampleFunc), 0f, 10f);
    }

    IEnumerator SpawnCoinsOverTime()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            yield return new WaitForSeconds(Random.Range(spawnDelayMin, spawnDelayMax));
            Instantiate(collectablePrefab, GetRandomSpawnPoint(), Quaternion.identity);
        }
    }
    private void ExampleFunc()
    {
        Debug.Log("Repeated");
    }
    private Vector2 GetRandomSpawnPoint()
    {
        return new Vector2(Random.Range(minBound.position.x, maxBound.position.x), minBound.position.y);
    }
}
