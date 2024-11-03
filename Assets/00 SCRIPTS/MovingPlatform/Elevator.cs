using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Transform _player;
    [SerializeField] protected Transform _elevator;
    [SerializeField] protected Transform _downPos;
    [SerializeField] protected Transform _upPos;
    [SerializeField] protected bool isElevator = false;
    private void Update()
    {
        MovingPlatform();
    }

    protected void MovingPlatform()
    {
        float pos = Vector2.Distance(_player.position, _elevator.position);
        if (pos < 1.5f && Input.GetKeyDown(KeyCode.I))
        {
            if(transform.position.y <= _downPos.position.y)
            {
                isElevator = true;
            }
            else if(transform.position.y >= _upPos.position.y)
            {
                isElevator = false;
            }
        }

        if (isElevator)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _upPos.position, _speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _downPos.position, _speed * Time.deltaTime);
        }
    }

}
