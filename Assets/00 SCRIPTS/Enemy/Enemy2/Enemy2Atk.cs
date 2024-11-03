using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Atk : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected GameObject _fire;
    [SerializeField] protected Transform _firePos;
    protected float attackDelay = 1f; 

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (_player == null)
        {
            _player = GameObject.FindWithTag(CONSTANT._player);
        }
        StartCoroutine(CheckAttackRange()); 
    }


    private IEnumerator CheckAttackRange()
    {
        while (true)
        {
            float distance = Vector2.Distance(this.transform.position, _player.transform.position);
            if (distance < 10)
            {
                StartCoroutine(AttackRoutine()); 
                yield return new WaitForSeconds(attackDelay); 
            }
            else
            {
                _animator.SetTrigger(CONSTANT._fyling);
                yield return null; 
            }
        }
    }


    private IEnumerator AttackRoutine()
    {
        _animator.SetTrigger(CONSTANT._atk);
        Shoot(); 
        yield return new WaitForSeconds(attackDelay); 
    }

    protected void Shoot()
    {
        Vector3 dir = transform.localScale.x > 0 ? Vector3.right : Vector3.left;
        GameObject firePrefab = FirePool.Instance.GetFire();
        firePrefab.transform.position = _firePos.transform.position;
        firePrefab.transform.rotation = this.transform.rotation;
        firePrefab.SetActive(true);
        firePrefab.transform.right = dir;
    }
}