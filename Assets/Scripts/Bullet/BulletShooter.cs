using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed;

    private Transform _bulletParent;

    private void Awake()
    {
        _bulletParent = GameObject.FindGameObjectWithTag(Tags.BULLET_PARENT).transform;
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(Bullet, transform.position, Quaternion.identity, _bulletParent).GetComponent<Bullet>();
        bullet.SetSpeed(BulletSpeed);
    }
}
