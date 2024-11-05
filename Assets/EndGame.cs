using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(CONSTANT._mainMenu);
    }
}
