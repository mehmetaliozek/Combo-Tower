using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float spawnTimer = 0;
    public float spawnCooldown = 5;
    public int spawnerLevel = 0;
    private float levelUpTimer = 0;
    public float levelUpCooldown = 20;
    public float numberOfEnemiesToSpawn = 5;
    public float radius = 15;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        levelUpTimer += Time.deltaTime;
        if(levelUpTimer >= levelUpCooldown) {
            numberOfEnemiesToSpawn += 3;
            levelUpTimer = 0;
        }
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnCooldown)
        {
            spawnTimer = 0;
            for(int i = 0; i < numberOfEnemiesToSpawn; i++) {
                var angle = i * Mathf.PI / numberOfEnemiesToSpawn * 2;
                var x = Mathf.Cos(angle) * radius;
                var y = Mathf.Sin(angle) * radius;

                var pos = new Vector3(transform.position.x + x, transform.position.y + y,0);

                Instantiate(enemy, pos, transform.rotation);
            }
        }
    }
}
