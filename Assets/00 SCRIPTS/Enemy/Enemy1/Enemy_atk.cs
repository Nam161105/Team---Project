using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_atk : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected float _speed;
    [SerializeField] protected float distanceTwoPlayer;
    [SerializeField] protected Animator _ani;
    [SerializeField] protected Transform atkPoint;
    [SerializeField] protected float atkRange;
    [SerializeField] protected LayerMask player;

    private bool isAttacking = false;

    private void Awake()
    {
        if (_player == null)
        {
            _player = GameObject.FindWithTag(CONSTANT._player);
        }
    }
    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindWithTag(CONSTANT._player);
        }
        if (_player != null)
        {
            MoveToPlayer();
        }
    }

    protected void MoveToPlayer()
    {

        float distance = Vector2.Distance(this.transform.position, _player.transform.position);

        if (distance < 10)
        {
            if (distance > distanceTwoPlayer)
            {
                _ani.SetTrigger(CONSTANT._run);
                this.transform.position = Vector3.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);
            }
            else if (!isAttacking) 
            {
                StartCoroutine(AttackRoutine());
            }
        }
    }

    private IEnumerator AttackRoutine()
    {
        isAttacking = true;
        _ani.SetTrigger(CONSTANT._atk);

        yield return new WaitForSeconds(_ani.GetCurrentAnimatorStateInfo(0).length);

        TakeDameWithPlayer();

        isAttacking = false;
    }

    protected void TakeDameWithPlayer()
    {
        Collider2D[] playerColli = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, player);
        foreach (Collider2D col in playerColli)
        {
            if (col.CompareTag(CONSTANT._player))
            {
                HealthBarOfPlayer health = col.GetComponent<HealthBarOfPlayer>();
                if (health != null)
                {
                    health.TakeDamage(5);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (atkPoint == null) return;
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }
}
