using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinaleScore : MonoBehaviour 
{
    private ScoreManager scoreManager;
    private Text finaleScore;

	// Use this for initialization
	void Start () 
	{
        scoreManager = FindObjectOfType<ScoreManager>();
        finaleScore = GetComponent<Text>();
        finaleScore.text += scoreManager.gameScore.ToString();
	}
}
