using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _currentScore;

    private bool _scoreChanged;

    public int CurrentScore { get { return _currentScore; } }
    public bool ScoreChanged { get { return _scoreChanged; } }

    private void Awake()
    {
        _currentScore = 0;
        _scoreChanged = false;
        ResetScore();
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }

    public void InvaderDeath(int invaderPoints)
    {
        StartCoroutine(ScoreEvent());
        _currentScore += invaderPoints;
    }

    public IEnumerator ScoreEvent()
    {
        _scoreChanged = true;
        yield return null;
        _scoreChanged = false;
    }
}
