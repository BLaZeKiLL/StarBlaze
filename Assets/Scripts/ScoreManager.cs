using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour 
{
    private static ScoreManager instance;

    public int gameScore = 0;

    void Awake()
    {
        if (instance != null) // if a music player exists
        {
            Destroy(gameObject);
        }
        else // if it does not exist
        {
            instance = this;
            /// gameObject is the reference to the Object in the hierarchy to which this script is attached
            /// in this case it is the Music Player
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
