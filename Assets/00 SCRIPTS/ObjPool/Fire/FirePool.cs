using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePool : MonoBehaviour
{
    private static FirePool instance;
    public static FirePool Instance { get =>  instance; }

    [SerializeField] protected GameObject _fire;
    [SerializeField] protected List<GameObject> listFire = new List<GameObject>();


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    public GameObject GetFire()
    {
        foreach(GameObject fire in listFire)
        {
            if (fire.activeSelf)
            {
                continue;
            }
            return fire;
        }

        GameObject g = Instantiate(_fire, this.transform.position, Quaternion.identity);
        listFire.Add(g);
        g.SetActive(false);
        return g;
    }
}
