using System;
using UnityEngine;

[Serializable]
public struct ProjectileData
{
    public Vector2 direction;
    public float speed;
    public float currentlifeTime;
    public float damage;
}