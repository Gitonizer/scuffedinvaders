using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private List<ScoreDisplay> _scoreDisplays;

    private void Awake()
    {
        _scoreDisplays = GetComponentsInChildren<ScoreDisplay>().ToList();
    }

    private void Start()
    {
        for (int i = 0; i < _scoreDisplays.Count; i++)
        {
            _scoreDisplays[i].Set(Highscores.TopScores[i].Name, Highscores.TopScores[i].Points.ToString());
        }
    }
}
