using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashText : MonoBehaviour
{
    private Text _text;
    private float _flashTime;
    private float _currentTime;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _flashTime = 0.4f;
        _currentTime = 0f;
    }

    private void Update()
    {
        if (_currentTime > _flashTime)
        {
            _currentTime = 0f;
            _text.enabled = !_text.enabled;
        }

        _currentTime += Time.deltaTime;
    }
}
