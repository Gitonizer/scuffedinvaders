using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject Block;

    private int _buildSizeX;
    private int _buildSizeY;

    private void Awake()
    {
    }

    // Creates building prefab if you really really want to again I guess lmao
    private IEnumerator CO_Build()
    {
        _buildSizeX = ((980 / 30) / 2);
        _buildSizeY = ((712 / 30) / 2);

        SpriteRenderer sprite = Block.GetComponent<SpriteRenderer>();

        int cutOnX = 15;

        for (int y = -_buildSizeY; y <= _buildSizeY; y++)
        {
            for (int x = -_buildSizeX ; x <= _buildSizeX; x++)
            {
                if (y > (_buildSizeY/3) && Mathf.Abs(x) > cutOnX)
                    continue;

                Instantiate(Block, new Vector3(x * sprite.bounds.size.x, y * sprite.bounds.size.y), Quaternion.identity, transform);
                yield return null;
            }

            if (y > (_buildSizeY / 3))
                cutOnX--;
        }
    }
}
