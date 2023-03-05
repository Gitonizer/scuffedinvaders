using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;

    private GeneratorHelper _helper;

    private float _height;
    private float _enemySize;

    private const float PERCENTAGE = 80f;

    private void Awake()
    {
        _helper = GetComponent<GeneratorHelper>();
    }
    void Start()
    {
        _enemySize = Enemy.GetComponent<SpriteRenderer>().bounds.size.x;
        _height = CameraHelper.GetCameraBoundariesY().y + (_enemySize/2);

        StartCoroutine(GenerateEnemies());
    }

    public IEnumerator GenerateEnemies()
    {
        _helper.GenerateGroup(Enemy, _enemySize, 1.5f, _height, PERCENTAGE);

        while (true)
        {
            yield return new WaitForSeconds(7f);
            _helper.GenerateGroup(Enemy, _enemySize, 1.5f, _height, PERCENTAGE);
        }
    }
}
