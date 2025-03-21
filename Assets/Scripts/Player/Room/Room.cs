using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private float range;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float attackRate;

    private float currentAttackRate;

    [SerializeField]
    private LayerMask enemyLayer;

    private Collider2D[] hits;

    private IAttack attack;

    private void Start()
    {
        attack = GetComponent<IAttack>();
        currentAttackRate = attackRate;
    }

    private void Update()
    {
        hits = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
        if (hits.Length > 0 && hits[0].TryGetComponent(out BasicEnemy enemy))
        {
            currentAttackRate -= Time.deltaTime;
            if (currentAttackRate <= 0)
            {
                attack.Attack(enemy, damage);
                currentAttackRate = attackRate;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
