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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_direction.y < 0f && other.CompareTag(Tags.INVADER))
            return;

        if (_direction.y > 0f && other.CompareTag(Tags.PLAYER_COLLIDER))
            return;

        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().Damage();
            Destroy(gameObject, 0.1f);
        }
        else if (other.CompareTag(Tags.PLAYER_COLLIDER)) //can't collide with charactercontroller
        {
            other.transform.parent.GetComponent<IDamageable>().Damage();
            Destroy(gameObject);
        }
    }
}
