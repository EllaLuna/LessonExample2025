using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] GameObject collectablePrefab;
    [SerializeField] CollectableData[] collectableDatas;
    [SerializeField] int spawnAmount = 10;
    [SerializeField] float spawnDelayMin = 0.1f;
    [SerializeField] float spawnDelayMax = 0.5f;
    [SerializeField] Transform minBound;
    [SerializeField] Transform maxBound;

    void Start()
    {
        StartCoroutine(SpawnCoinsOverTime());
    }

    IEnumerator SpawnCoinsOverTime()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            yield return new WaitForSeconds(Random.Range(spawnDelayMin, spawnDelayMax));
            var collectable = Instantiate(collectablePrefab, GetRandomSpawnPoint(), Quaternion.identity)
                .GetComponent<Collectable>();
            collectable.SetCollectableData(collectableDatas[Random.Range(0, collectableDatas.Length)]);
        }
    }

    private Vector2 GetRandomSpawnPoint()
    {
        return new Vector2(Random.Range(minBound.position.x, maxBound.position.x), minBound.position.y);
    }
}
