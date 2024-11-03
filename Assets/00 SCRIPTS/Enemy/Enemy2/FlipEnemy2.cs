using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy2 : MonoBehaviour
{
    [SerializeField] protected Transform _player;

    private void Update()
    {
        this.EnemyFlip();
    }

    protected void EnemyFlip()
    {
        float pos = _player.transform.position.x - transform.position.x;
        if (pos > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
