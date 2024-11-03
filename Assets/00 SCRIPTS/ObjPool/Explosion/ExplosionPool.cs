using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : MonoBehaviour
{
    private static ExplosionPool instance;
    public static ExplosionPool Instance { get => instance; }

    [SerializeField] protected GameObject _explsion;
    [SerializeField] protected List<GameObject> _listExplo = new List<GameObject>();

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    public GameObject GetExplosion()
    {
        foreach(GameObject g in _listExplo)
        {
            if (g.activeSelf)
            {
                continue;
            }
            return g;
        }

        GameObject a = Instantiate(_explsion, transform.position, Quaternion.identity);
        _listExplo.Add(a);
        a.SetActive(false);
        return a;
    }
}
