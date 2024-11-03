using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    [SerializeField] protected Transform _player;

    void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindWithTag(CONSTANT._player).transform;
        }
        if (_player != null)
        {
            FlipEnemy();
        }
    }

    protected void FlipEnemy()
    {
        float distance = _player.transform.position.x - transform.position.x;

        if (distance > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
