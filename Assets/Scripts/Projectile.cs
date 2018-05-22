using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour 
{
    public float Damage = 100.0f;

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
