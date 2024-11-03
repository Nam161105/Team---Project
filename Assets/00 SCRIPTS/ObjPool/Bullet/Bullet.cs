using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] protected float _speedBullet, _lifeTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {

        StartCoroutine(Deactive());
    }

    void Update()
    {
        rb.velocity = transform.right * _speedBullet;
    }


    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
