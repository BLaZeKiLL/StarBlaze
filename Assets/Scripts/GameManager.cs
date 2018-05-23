using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private LevelManager leveManger;
    private int enemies;

	// Use this for initialization
	void Start () 
	{
        leveManger = FindObjectOfType<LevelManager>();
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
            leveManger.LoadNextLevel();
        }
    }

    public void PlayerDead()
    {
        leveManger.LoadLevel("Lose");
    }
}
