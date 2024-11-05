using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._player))
        {
            collision.GetComponent<HealthBarOfPlayer>().TakeDamage(300);
        }
    }
}
