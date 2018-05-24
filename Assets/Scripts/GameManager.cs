using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public int formationSpawnCount = 3;

    private LevelManager leveManger;
    private EnemySpawner enemySpawner;
    private ScoreManager scoreManager;
    private Score score;
    private int enemies;

    // Use this for initialization
    void Start () 
	{
        leveManger = FindObjectOfType<LevelManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        scoreManager = FindObjectOfType<ScoreManager>();
        score = GameObject.Find("Score").GetComponent<Score>();
	}

    public void EnemySpawned()
    {
        enemies++;
    }

    public void EnemyDead(int scoreValue)
    {
        enemies--;

        scoreManager.gameScore = score.ScoreAdd(scoreValue);

        if (enemies <= 0)
        {
            enemySpawner.Respawn();
        }
    }

    public void PlayerDead()
    {
        leveManger.LoadNextLevel();
    }
}
