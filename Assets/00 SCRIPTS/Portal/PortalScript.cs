using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] protected GameObject _portalOut;
    [SerializeField] protected GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(CONSTANT._player);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._player))
        {
            if(Vector2.Distance(_player.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(PortalIn());
            }
        }
    }

    protected IEnumerator PortalIn()
    {
        yield return new WaitForSeconds(0.5f);
        _player.transform.position = _portalOut.transform.position;

    }
}
