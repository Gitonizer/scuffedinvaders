using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right,
    Down
}

public class Invader : MonoBehaviour, IDamageable
{
    public int Points;
    private SpriteRenderer _sprite;

    private Vector3 _directionVector;

    public float _maxX;
    public float _maxY;
    public float _traveledDistance;
    private float _speed = 0.7f;

    public Direction _currentDirection;

    public List<Direction> _states;
    public int _currentState;

    private BulletShooter _shooter;

    // gajo vai ter que descer sempre ó mem spide
    // gajo anda pá ligeiramente pá direita e pá esquerda
    // gajo vai disparando cenas
    // gajo pode ser destruido - quando leva tiros e quando cai na terra
    private void Awake()
    {
        _shooter = GetComponent<BulletShooter>();

        _maxX = CalculateDistanceX();
        _maxY = CalculateDistanceY();
        _traveledDistance = 0;

        _states = new List<Direction>()
        {
            Direction.Right,
            Direction.Down,
            Direction.Left,
            Direction.Down
        };

        _currentState = 0;

        _currentDirection = _states[_currentState];
    }

    void Update()
    {
        MoveEnemy(_currentDirection);

        if (Random.Range(0, 2000) >= 1999)
            _shooter.Shoot();
    }

    private void MoveEnemy(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                Move(Vector3.left, -_maxX);
                break;
            case Direction.Right:
                Move(Vector3.right, _maxX);
                break;
            case Direction.Down:
                Move(Vector3.down, -_maxY);
                break;
            default:
                break;
        }
    }

    private float CalculateDistanceX()
    {
        return CameraHelper.CalculateScreenCoverageX(7) - CameraHelper.CalculateScreenCoverageX(0);
    }

    private float CalculateDistanceY()
    {
        return CameraHelper.CalculateScreenCoverageY(7) - CameraHelper.CalculateScreenCoverageY(0);
    }

    private void Move(Vector3 direction, float distance)
    {
        if (Mathf.Abs(_traveledDistance) > Mathf.Abs(distance))
        {
            _currentState++;
            if (_currentState >= _states.Count) _currentState = 0;
            _currentDirection = _states[_currentState];
            _traveledDistance = 0;
        }

        Vector3 frameMove = direction * _speed * Time.deltaTime;
        transform.position += frameMove;
        _traveledDistance += frameMove.x != 0 ? frameMove.x : frameMove.y;
    }

    public void Damage() //only bullets trigger this so we can inform the score here
    {
        GameObject.FindGameObjectWithTag(Tags.SCORE).GetComponent<ScoreManager>().InvaderDeath(Points);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.BULLET))
            return;

        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            Collide(other.gameObject.GetComponent<IDamageable>());
        }
        else if (other.gameObject.transform.parent.GetComponent<IDamageable>() != null) // player uuuh you know check parent I guess
        {
            Collide(other.gameObject.transform.parent.GetComponent<IDamageable>());
        }
    }

    private void Collide(IDamageable damageable)
    {
        damageable.Damage();
        Destroy(gameObject, 0.2f);
    }
}
