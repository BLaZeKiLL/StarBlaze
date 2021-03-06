﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject EnemyPrfab;

    // For Gizmo
    public float width = 10.0f;
    public float height = 5.0f;

    public float moveSpeed = 5.0f;
    public float padding = 2.0f;
    public float frequency = 5.0f;

    public float spawnDelay = 0.5f;

    private float xmin = -5.0f;
    private float xmax = 5.0f;
    private float timeChange = 0.0f;
    private float randomChange = 10.0f;

    private GameManager gameManager;

    // Use this for initialization
    void Start () 
	{
        xmin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - Camera.main.transform.position.z)).x + padding;
        xmax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z - Camera.main.transform.position.z)).x - padding;

        gameManager = FindObjectOfType<GameManager>();

        if (Random.Range(0,1)==0)
        {
            moveSpeed *= -1;
        }

        SpawnUntilFull();
    }

    // Update is called once per frame
    void Update () 
	{
        Movement();
    }

    public void Respawn()
    {
        SpawnUntilFull();
    }

    private void SpawnUntilFull()
    {
        Transform freePostion = NextFreePosition();

        if (freePostion)
        {
            GameObject enemy = Instantiate(EnemyPrfab, freePostion.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePostion;
            gameManager.EnemySpawned();
        }

        if (NextFreePosition())
            Invoke("SpawnUntilFull", spawnDelay);
    }

    private Transform NextFreePosition()
    {
        foreach (Transform ChildPosition in transform)
        {
            // child of position is enemy and if that is 0 there is no enemy i.e enemy is dead
            if (ChildPosition.childCount == 0)
            {
                return ChildPosition;
            }
        }
        return null;
    }

    private void Movement()
    {
        if (transform.position.x <= xmax && transform.position.x >= xmin)
        {
            transform.position += new UnityEngine.Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x >= xmax)
        {
            ChangeDirection();
        }
        else
        {
            moveSpeed = Mathf.Abs(moveSpeed);
            transform.position += new UnityEngine.Vector3(moveSpeed * Time.deltaTime, 0, 0);
            timeChange = Time.time;
        }

        if ((Time.time - timeChange) >= frequency)
        {
            if (Random.Range(0.0f, 1000.0f) <= randomChange)
            {
                ChangeDirection();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0.0f));
    }

    private void ChangeDirection()
    {
        moveSpeed *= -1;
        transform.position += new UnityEngine.Vector3(moveSpeed * Time.deltaTime, 0, 0);
        timeChange = Time.time;
    }
}
