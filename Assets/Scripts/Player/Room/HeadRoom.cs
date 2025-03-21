using UnityEngine;

public class HeadRoom : MonoBehaviour, IAttack
{
    public void Attack(BasicEnemy enemy, float damage)
    {
        enemy.DamageEnemy(damage);
    }
}