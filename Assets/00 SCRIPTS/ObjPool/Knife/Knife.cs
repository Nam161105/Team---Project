using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float _speed, _lifeTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        StartCoroutine(GetKnifeToPool());
    }
    private void Update()
    {
        rb.velocity = transform.right * _speed;
    }

    IEnumerator GetKnifeToPool()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}
