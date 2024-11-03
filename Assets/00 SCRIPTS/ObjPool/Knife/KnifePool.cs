using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePool : MonoBehaviour
{

    private static KnifePool instance;
    public static KnifePool Instance { get => instance; }


    [SerializeField] protected GameObject _knife;
    [SerializeField] protected List<GameObject> _listKnife = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    public GameObject GetKnife()
    {
        foreach(GameObject a in _listKnife)
        {
            if (a.activeSelf)
            {
                continue;
            }
            return a;
        }

        GameObject g = Instantiate(_knife, this.transform.position, Quaternion.identity);
        _listKnife.Add(g);
        g.SetActive(false);
        return g;
    }
}
