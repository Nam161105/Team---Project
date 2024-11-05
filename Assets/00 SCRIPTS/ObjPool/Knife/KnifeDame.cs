using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDame : MonoBehaviour
{

    [SerializeField] protected float dame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._enemy))
        {
            Enemy2Def enemy2Def = collision.GetComponent<Enemy2Def>();
 
            if (enemy2Def != null)
            {
                enemy2Def.TakeDame(dame);
            }

 
            EnemyDef enemyDef = collision.GetComponent<EnemyDef>();
  
            if (enemyDef != null)
            {
                enemyDef.TakeDame(dame);
            }

            NightBorneDef nightDef = collision.GetComponent<NightBorneDef>();

            if (nightDef != null)
            {
                nightDef.TakeDame(dame);
            }
            gameObject.SetActive(false);
        }
    }
}
