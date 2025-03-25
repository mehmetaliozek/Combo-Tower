using System.Collections.Generic;
using UnityEngine;

public class CasterRoom : MonoBehaviour, IAttack
{
    private bool isLinearAttack = true;

    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private int projectileCount = 8;

    [SerializeField]
    private ProjectileData projectileData;

    private List<Projectile> projectiles;

    private List<Vector2> linearDirections = new List<Vector2>()
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };

    private List<Vector2> diagonalDirections = new List<Vector2>()
    {
        new Vector2(1, 1).normalized,
        new Vector2(1, -1).normalized,
        new Vector2(-1, 1).normalized,
        new Vector2(-1, -1).normalized
    };

    private void Start()
    {
        projectiles = new List<Projectile>();
        for (int i = 0; i < projectileCount; i++)
        {
            InstantiateProjectile();
        }
    }

    public void Attack(BasicEnemy enemy, float damage)
    {
        if (isLinearAttack)
        {
            AttackLinear(damage);
            isLinearAttack = false;
        }
        else
        {
            AttackDiagonal(damage);
            isLinearAttack = true;
        }
    }

    private void AttackLinear(float damage)
    {
        foreach (Vector2 direction in linearDirections)
        {
            Projectile p = GetInactiveProjectile();
            if (p != null)
            {
                projectileData.direction = direction;
                projectileData.damage = damage;
                p.Initialized(projectileData);
                p.transform.position = transform.position;
                p.gameObject.SetActive(true);
            }
        }
    }

    private void AttackDiagonal(float damage)
    {
        foreach (Vector2 direction in diagonalDirections)
        {
            Projectile p = GetInactiveProjectile();
            if (p != null)
            {
                projectileData.direction = direction;
                projectileData.damage = damage;
                p.Initialized(projectileData);
                p.transform.position = transform.position;
                p.gameObject.SetActive(true);
            }
        }
    }

    private Projectile InstantiateProjectile()
    {
        Projectile p = Instantiate(projectile, transform.position, Quaternion.identity);
        p.gameObject.SetActive(false);
        projectiles.Add(p);
        return p;
    }

    private Projectile GetInactiveProjectile()
    {
        foreach (Projectile p in projectiles)
        {
            if (!p.gameObject.activeInHierarchy)
            {
                return p;
            }
        }

        return InstantiateProjectile();
    }
}
