using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardNotification : MonoBehaviour
{
    [SerializeField] protected GameObject _boardNoti;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._player))
        {
            _boardNoti.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EnterBoard()
    {
        _boardNoti.SetActive(false);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
