using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public InputField InputField;
    public GameObject NewScoreObject;

    private Canvas _canvas;
    [SerializeField] private bool _readyToRestart;
    
    private void OnEnable()
    {
        EventManager.OnGameOver += OnGameOver;
    }

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _readyToRestart = false;
    }

    private void Start()
    {
        _canvas.enabled = false;
    }

    private void Update()
    {
        if (_readyToRestart && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape)))
        {
            StartCoroutine(RestartGameScene());
            _readyToRestart = false;
        }
    }

    private void OnGameOver()
    {
        _canvas.enabled = true;

        if (ScoreManager.CurrentScore > Highscores.TopScores[Highscores.TopScores.Count - 1].Points) // ignore if lower or equal than worst score
        {
            // just open up the thing
            NewScoreObject.SetActive(true);
            InputField.Select();
            Time.timeScale = 0f;
        }
        else
        {
            _readyToRestart = true;
            Time.timeScale = 0f;
            SceneManager.LoadScene(Constants.SCENE_HIGHSCORE, LoadSceneMode.Additive);
        }
    }

    private IEnumerator RestartGameScene()
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(Constants.SCENE_HIGHSCORE);

        yield return new WaitUntil(() => operation.isDone);

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void InsertScore()
    {
        Score score = new Score(InputField.text, ScoreManager.CurrentScore);

        int index;

        for (index = Highscores.TopScores.Count - 1; index > 0 && Highscores.TopScores[index - 1].Points < ScoreManager.CurrentScore; index--)
        {
            Highscores.TopScores[index] = Highscores.TopScores[index - 1];
        }

        Highscores.TopScores[index] = score;

        StartCoroutine(RunAfterSceneLoaded(() =>
        {
            _readyToRestart = true;
            NewScoreObject.SetActive(false);
        }));
    }

    private IEnumerator RunAfterSceneLoaded(Action action)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Constants.SCENE_HIGHSCORE, LoadSceneMode.Additive);

        yield return new WaitUntil(() => operation.isDone);

        action();
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= OnGameOver;
    }
}
