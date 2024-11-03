using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] protected string levelName;
    [SerializeField] protected float lifeTime;
    [SerializeField] protected Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._player))
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        animator.SetTrigger(CONSTANT._end);
        yield return new WaitForSeconds(lifeTime);
        SceneManager.LoadScene(levelName);
        animator.SetTrigger(CONSTANT._start);
    }
}
