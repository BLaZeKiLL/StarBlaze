using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
    private static MusicPlayer instance;

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
