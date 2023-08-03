using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    public static Highscores Instance { get; set; }
    public static List<Score> TopScores;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
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
