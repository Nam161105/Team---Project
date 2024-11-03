using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionActive : MonoBehaviour
{
    [SerializeField] protected float _lieTime;

    private void Start()
    {
        StartCoroutine(Deactive());
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(_lieTime);
        gameObject.SetActive(false);
    }
}
