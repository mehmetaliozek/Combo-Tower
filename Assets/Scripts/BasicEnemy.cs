using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float health = 10f;
    public GameObject experienceObject;
    private float attackTimer = 0;
    public float attackCooldown = 1;

    void Start()
    {
        attackTimer = attackCooldown;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, moveSpeed * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                attackTimer = 0;
                player.TakeDamage(1);
                //oyuncuya hasar verme kodu çağır;
            }
        }
    }

    public void DamageEnemy(float amount)
    {
        health -= amount;
        Debug.Log(health);
        if (health <= 0)
        {
            KillSelf();
        }
    }

    public void KillSelf()
    {
        Instantiate(experienceObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
