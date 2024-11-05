using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    protected static PortalManager instance;
    public static PortalManager Instance { get { return instance; } }

    [SerializeField] protected GameObject[] _listPortal;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Destroy(gameObject);
    }

    public GameObject GetPortal()
    {
        return _listPortal[Random.Range(0, _listPortal.Length)];
    }
}
