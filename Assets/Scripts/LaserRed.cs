using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRed : Projectile
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
