using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private string _currentMenuItem;

    private List<MenuItem> _menuItems;
    private List<Action> _actions;
    private int _currentItemIndex;
    private bool _onMainMenu;

    [Header("Canvas Groups")]
    public CanvasGroup MainMenuCanvas;

    public Image Background;

    private void Awake()
    {
        _menuItems = GetComponentsInChildren<MenuItem>().ToList();

        _actions = new List<Action>()
        {
            OnStartGame,
            OnCheckScores,
            OnQuit
        };
    }

    private void Start()
    {
        _onMainMenu = true;
        _currentItemIndex = 0;
        _menuItems[_currentItemIndex].Select();

        for (int i = 0; i < _menuItems.Count; i++)
        {
            _menuItems[i].Initialize(_actions[i]);
        }
    }

    private void Update()
    {
        ManageMenuEvents();
    }
    private void OnStartGame()
    {
        StartCoroutine(FadeAndDo(new Vector2(1, 0), () => SceneManager.LoadScene(Constants.SCENE_GAME)));
    }
    private void OnCheckScores()
    {
        ShowMainMenu(false);
    }
    public void OnBackToMenu()
    {
        ShowMainMenu(true);
    }
    private void OnQuit()
    {
        Application.Quit();
    }

    private void ShowMainMenu(bool show)
    {
        _onMainMenu = show;
        if (show)
        {
            Background.color = new Color(0, 0, 0, 0);
            SceneManager.UnloadSceneAsync(Constants.SCENE_HIGHSCORE);
        }
        else
            StartCoroutine(FadeAndDo(new Vector2(1, 0), () => SceneManager.LoadScene(Constants.SCENE_HIGHSCORE, LoadSceneMode.Additive)));
    }
    private void OnArrowPress(bool isUpArrow)
    {
        _menuItems[_currentItemIndex].Deselect();

        if (isUpArrow)
        {
            _currentItemIndex = _currentItemIndex == 0 ?
                _currentItemIndex = _menuItems.Count - 1 : _currentItemIndex - 1;
        }
        else
        {
            _currentItemIndex = _currentItemIndex < _menuItems.Count - 1 ?
                _currentItemIndex + 1 : 0;
        }

        _menuItems[_currentItemIndex].Select();
        _currentMenuItem = _menuItems[_currentItemIndex].name;
    }
    private void ManageMenuEvents()
    {
        if (_onMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                OnArrowPress(true);
                return;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                OnArrowPress(false);
                return;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _menuItems[_currentItemIndex].ButtonAction();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                OnBackToMenu();
            }
        }
    }

    private IEnumerator FadeAndDo(Vector2 fadeValues, Action action)
    {
        float currentTime = 0f;
        float duration = 0.5f;
        Color backgroundColor = Color.black;

        while (currentTime < duration)
        {
            backgroundColor.a = Mathf.Lerp(fadeValues.y, fadeValues.x, currentTime / duration);
            Background.color = backgroundColor;
            currentTime += Time.deltaTime;
            yield return null;
        }

        action();
    }
}