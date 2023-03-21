/*
 * This class spawns fruit randomly on the field.
 */
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // Prefab references
    public GameObject CherryPrefab;
    public GameObject BananaPrefab;
    public GameObject WatermelonPrefab;

    // Times until initial spawn
    private float cherryInitSpawnTime = 2.0f;
    private float bananaInitSpawnTime = 10.0f;
    private float watermelonInitSpawnTime = 15.0f;
    
    // Spawn Rates
    private float cherrySpawnRate = 3.0f;
    private float bananaSpawnRate = 5.0f;
    private float watermelonSpawnRate = 8.0f;
    
    // Spawn Range
    private float minSpawnRange = 10.0f;
    private float maxSpawnRange = 40.0f;
    private float spawnHeight = 0.5f;

    void Start()
    {
        // Calling methods to spawn fruit
        InvokeRepeating(nameof(CreateCherry), cherryInitSpawnTime, cherrySpawnRate);
        InvokeRepeating(nameof(CreateBanana), bananaInitSpawnTime, bananaSpawnRate);
        InvokeRepeating(nameof(CreateWatermelon), watermelonInitSpawnTime, watermelonSpawnRate);
    }

    void CreateCherry()
    {
        Instantiate(CherryPrefab, GetRandomPosition(), transform.rotation);

    }
    void CreateBanana()
    {
        Instantiate(BananaPrefab, GetRandomPosition(), transform.rotation);
    }
    void CreateWatermelon()
    {
        Instantiate(WatermelonPrefab, GetRandomPosition(), transform.rotation);
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minSpawnRange, maxSpawnRange), spawnHeight, Random.Range(minSpawnRange, maxSpawnRange));
    }
}
