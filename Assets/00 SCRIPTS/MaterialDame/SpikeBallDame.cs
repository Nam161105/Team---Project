using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallDame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._player))
        {
            collision.gameObject.GetComponent<HealthBarOfPlayer>().TakeDamage(25);
        }
    }
}
