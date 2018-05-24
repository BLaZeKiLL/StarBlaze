using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SpaceShip
{
    public float fireChance = 10.0f;
    public int scoreValue = 100;

    private float firetime = 0.0f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        projectileSpeed *= -1;
    }

    void Update()
    {
        if ((Time.time - firetime) > firerate)
        {
	        if (Random.Range(0, 1000) <= fireChance)
	        {
	            Fire();
	        }
        }

        EnemyDead();
    }

    private void Fire()
    {
        GameObject Beam = Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, 180f)) as GameObject;
        Beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, projectileSpeed, 0.0f);
        firetime = Time.time;
    }

    private void EnemyDead()
    {
        if (Health <= 0)
        {
            gameManager.EnemyDead(scoreValue);
            Destroy(gameObject);
        }
    }
}
