using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private SpriteRenderer sprite;

    private float speed;

    private float positionX;

    private Camera camera;

    private Vector2 _cameraBoundaries;

    private float _force;

    private const float MAX_FORCE = 1.5f;
    private const float MIN_FORCE = 1f;

    private float _maxForceTime = 0.1f;
    private float _timeElapsed = 0f;

    private BulletShooter _shooter;

    private bool _bulletCooldown;
    private float _bulletCooldownTime;

    private const float MAX_COOLDOWN_TIME = 0.5f;

    private void Awake()
    {
        camera = Camera.main;
        characterController = GetComponent<CharacterController>();
        sprite = GetComponent<SpriteRenderer>();
        _shooter = GetComponent<BulletShooter>();

        _force = MIN_FORCE;
    }
    void Start()
    {
        speed = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        AddForce();
        characterController.Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * Time.deltaTime * speed * _force);
        positionX = GetPositionX();

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        if (_bulletCooldown)
        {
            _bulletCooldownTime -= Time.deltaTime;
            if (_bulletCooldownTime <= 0) _bulletCooldown = false;
        }

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);

        ForceDecay();
    }

    private float GetPositionX()
    {
        return Mathf.Clamp(transform.position.x, CameraHelper.GetCameraBoundariesX().x + (sprite.bounds.size.x / 2), CameraHelper.GetCameraBoundariesX().y - (sprite.bounds.size.x / 2));
    }

    private void AddForce()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            _force = MAX_FORCE;
    }

    private void ForceDecay()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _maxForceTime)
        {
            _force = Mathf.Clamp(_force - 0.5f, MIN_FORCE, MAX_FORCE);
            _timeElapsed = 0f;
        }
    }

    private void Shoot()
    {
        if (_bulletCooldown)
            return;

        _bulletCooldown = true;

        _bulletCooldownTime = MAX_COOLDOWN_TIME;

        _shooter.Shoot();
    }
}
