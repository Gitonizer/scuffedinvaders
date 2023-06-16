using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlock : MonoBehaviour, IDamageable
{
    public void Damage()
    {
        Destroy(gameObject);
    }
}
