using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public int formationSpawnCount = 3;

    private LevelManager leveManger;
    private EnemySpawner enemySpawner;
    private int enemies;
    private int spawnCount = 1;

	// Use this for initialization
	void Start () 
	{
        leveManger = FindObjectOfType<LevelManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
	}

    public void EnemySpawned()
    {
        enemies++;
    }

    public void EnemyDead()
    {
        enemies--;

        if (enemies <= 0)
        {
            if (spawnCount < formationSpawnCount)
            {
                enemySpawner.Respawn();
                spawnCount++;
            }
            else
                leveManger.LoadNextLevel();
        }

    }

    public void PlayerDead()
    {
        leveManger.LoadLevel("Lose");
    }
}
