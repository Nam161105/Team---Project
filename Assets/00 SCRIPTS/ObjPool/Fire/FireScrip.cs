using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScrip : MonoBehaviour
{
    protected Rigidbody2D _rigi;
    [SerializeField] protected float speed, _lifeTime;
    private void Awake()
    {
        _rigi = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactiveFire());
    }
    private void Update()
    {
        _rigi.velocity = -transform.right * speed;
    }

    IEnumerator DeactiveFire()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}
