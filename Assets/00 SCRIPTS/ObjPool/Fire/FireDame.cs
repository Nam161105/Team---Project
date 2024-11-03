using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._player))
        {
            collision.gameObject.GetComponent<HealthBarOfPlayer>().TakeDamage(7);
            gameObject.SetActive(false);
        }
    }
}
