using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private TrailRenderer trailRenderer;

    private ProjectileData data;

    private bool isInitialized = false;

    private void Update()
    {
        if (!isInitialized) return;
        data.currentlifeTime -= Time.deltaTime;
        if (data.currentlifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
        rb.AddForce(data.direction * data.speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BasicEnemy enemy))
        {
            enemy.DamageEnemy(data.damage);
            gameObject.SetActive(false);
        }
    }

    public void Initialized(ProjectileData data)
    {
        this.data = data;
        trailRenderer.Clear();
        isInitialized = true;
    }
}