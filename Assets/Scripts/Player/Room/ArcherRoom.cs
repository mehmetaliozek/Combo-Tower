using UnityEngine;

public class ArcherRoom : MonoBehaviour, IAttack
{
    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private LayerMask enemyLayerMask;

    public void Attack(BasicEnemy enemy, float damage)
    {
        var hit = Physics2D.Linecast(transform.position, enemy.transform.position, enemyLayerMask);
        Debug.Log(enemyLayerMask.value);
        //var hit = Physics2D.Raycast(transform.position, enemy.transform.position - transform.position);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.TryGetComponent<BasicEnemy>(out var targetEnemy))
            {
                targetEnemy.DamageEnemy(damage);

                var trail = Instantiate(arrow, transform.position, Quaternion.identity);

                var trailScript = trail.GetComponent<Arrow>();

                trailScript.setTargetPos(hit.point);
            }
        }
    }
}