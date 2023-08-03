using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTitleText : MonoBehaviour
{
    private float _duration;
    private float _currentTime;
    private Vector3 _maxScale;

    private void Start()
    {
        _duration = 1f;
        _currentTime = 0f;
        _maxScale = new Vector3(1.3f, 1.3f, 1);
    }
    void Update()
    {
        if (_currentTime < 0.5f)
            transform.localScale = Vector3.Lerp(Vector3.one, _maxScale, _currentTime / _duration);
        else
            transform.localScale = Vector3.Lerp(_maxScale, Vector3.one, _currentTime / _duration);

        _currentTime += Time.deltaTime;

        if (_currentTime > _duration)
            _currentTime = 0f;
    }
}
