using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Highscores : MonoBehaviour
{
    public static Highscores Instance { get; set; }
    public static List<Score> TopScores;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        TopScores = new List<Score>()
        {
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100),
            new Score("AAA", 100)
        };
    }
}
