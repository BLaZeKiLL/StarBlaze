using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour 
{
    public float Health;

    public GameObject projectile;
    public float projectileSpeed = 20.0f;
    public float firerate = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            if (!projectile.tag.Equals(collision.tag))
            {
                Damage(collision.GetComponent<Projectile>().Damage);
            }
        }
    }

    private void Damage(float damage)
    {
        Health -= damage;
    }
}
