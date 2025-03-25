using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float spawnTimer = 0;
    public float spawnCooldown = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnCooldown)
        {
            spawnTimer = 0;
            Vector3 positionToSpawn = new Vector3(Random.Range(0, 1), Random.Range(0, 1), 0);
            Instantiate(enemy, positionToSpawn, transform.rotation);
        }
    }
}
