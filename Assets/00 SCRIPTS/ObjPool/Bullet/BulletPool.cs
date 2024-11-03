using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    protected static BulletPool Instance;
    public static BulletPool instance { get => Instance; }
    

    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected List<GameObject> _bullets = new List<GameObject>();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    public GameObject GetBullet()
    {
        foreach(GameObject g in _bullets)
        {
            if (g.activeSelf)
            {
                continue;
            }
            return g;
        }

        GameObject b = Instantiate(_bullet, this.transform.position, Quaternion.identity);
        _bullets.Add(b);
        b.SetActive(false);
        return b;
    }

}
