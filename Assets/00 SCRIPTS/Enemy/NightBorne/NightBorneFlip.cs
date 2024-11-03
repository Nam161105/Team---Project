using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneFlip : MonoBehaviour
{
    [SerializeField] protected Transform _player;


    private void Update()
    {
        float dir = _player.transform.position.x - transform.position.x;
        if(dir > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        if(dir < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
