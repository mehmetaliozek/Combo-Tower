using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float health = 10f;
    public float levelHealthModifier = 3;
    public GameObject experienceObject;
    public float damage = 5;
    public float levelDamageModifier = 2;
    private float attackTimer = 0;
    public float attackCooldown = 1;
    public GameObject damagePopup;

    void Start()
    {
        attackTimer = attackCooldown;
    }
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, moveSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().linearVelocity = ( Player.Instance.transform.position - transform.position).normalized * moveSpeed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                attackTimer = 0;
                player.TakeDamage(damage);
                //oyuncuya hasar verme kodu çağır;
            }
        }
    }

    public void DamageEnemy(float amount)
    {
        health -= amount;
        GameObject popupObject = Instantiate(damagePopup, transform.position, Quaternion.identity);
        popupObject.GetComponent<DamagePopup>().SetMessage(amount.ToString());
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

    public void UpgradeStats(int level) {
        health += level * levelHealthModifier;
        damage += level * levelDamageModifier;
    }
}
