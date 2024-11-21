using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] protected float _speed;
    [SerializeField] protected Vector2 _force;
    [SerializeField] public bool _onGround = false;
    [SerializeField] protected Animator _ani;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Moving();
        UpdateAnimation();
    }

    protected void Moving()
    {
        Vector2 move = _rb.velocity;
        move.x = Input.GetAxisRaw(CONSTANT._horizontal) * _speed;
        _rb.velocity = move;

        if (_rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (_rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.jumpClip);
            _rb.AddForce(_force, ForceMode2D.Impulse);
            _onGround = false;
        }
    }

    protected void UpdateAnimation()
    {

        if (!_onGround)
        {
            _ani.SetTrigger(CONSTANT._jump);
        }
        else
        {
            if (_rb.velocity.x != 0)
            {
                _ani.SetTrigger(CONSTANT._run);
            }
            else
            {
                _ani.SetTrigger(CONSTANT._idle);
            }
        }
    }



}
