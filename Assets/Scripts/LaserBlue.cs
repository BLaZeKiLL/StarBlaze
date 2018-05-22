using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlue : Projectile
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
