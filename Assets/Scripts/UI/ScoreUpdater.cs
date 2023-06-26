using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private Text _pointsText;

    private void Awake()
    {
        _scoreManager = GameObject.FindGameObjectWithTag(Tags.SCORE).GetComponent<ScoreManager>();
        _pointsText = GetComponent<Text>();
    }

    private void Update()
    {
        if (!_scoreManager.ScoreChanged)
            return;

        _pointsText.text = _scoreManager.CurrentScore.ToString();
    }
}
