using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;

    public void SetSpeed(float speed)
    {
        _direction = new Vector3(0, speed, 0);
    }

    private void Update()
    {
        transform.position += _direction * Time.deltaTime;
    }
}
