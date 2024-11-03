using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneAtk : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected float _speed;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Transform atkPoint;
    [SerializeField] protected float atkRange;
    [SerializeField] protected LayerMask player;
    [SerializeField] protected bool _isAtk = false;

    private void Awake()
    {
        if(_player == null)
        {
            _player = GameObject.FindWithTag(CONSTANT._player);
        }
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        this.MoveToPlayer();
    }


    protected void MoveToPlayer()
    {
        float dir = Vector2.Distance(this.transform.position, _player.transform.position);
        if (dir < 10)
        {
            if (dir > 1.5)
            {
                _animator.SetTrigger(CONSTANT._run);
                this.transform.position = Vector3.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);
            }
            else 
            {
                if (!_isAtk)
                {
                    StartCoroutine(CheckAtk());
                }
            }
        }
        else
        {
            _animator.SetTrigger(CONSTANT._idle);
        }
    }
    protected IEnumerator CheckAtk()
    {
        _isAtk = true;
        _animator.SetTrigger(CONSTANT._atk);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length * 0.5f);
        this.TakeDameWithPlayer();
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length * 0.5f);
        _isAtk = false;
    }

    protected void TakeDameWithPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, player);
        foreach(Collider2D hit in hits)
        {
            if (hit.CompareTag(CONSTANT._player))
            {
                HealthBarOfPlayer health = hit.GetComponent<HealthBarOfPlayer>();
                if(health != null)
                {
                    health.TakeDamage(10);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(atkPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }
}
