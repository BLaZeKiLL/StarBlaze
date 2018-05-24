using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;

    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public int ScoreAdd(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        return score;
    }

    public void Reset()
    {
        score = 0;
    }
}
