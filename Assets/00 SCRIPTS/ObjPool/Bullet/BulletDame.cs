using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletDame : MonoBehaviour
{
    [SerializeField] protected int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT._enemy))
        {
            Enemy2Def enemy2Def = collision.GetComponent<Enemy2Def>();
 
            if (enemy2Def != null)
            {
                enemy2Def.TakeDame(damage);
                GameObject _explosion = ExplosionPool.Instance.GetExplosion();
                _explosion.transform.position = this.transform.position;
                _explosion.transform.rotation = Quaternion.identity;
                _explosion.SetActive(true);
            }
 
            EnemyDef enemyDef = collision.GetComponent<EnemyDef>();
 
            if (enemyDef != null)
            {
                enemyDef.TakeDame(damage);
                GameObject _explosion = ExplosionPool.Instance.GetExplosion();
                _explosion.transform.position = this.transform.position;
                _explosion.transform.rotation = Quaternion.identity;
                _explosion.SetActive(true);

            }

            NightBorneDef nightDef = collision.GetComponent<NightBorneDef>();

            if (nightDef != null)
            {
                nightDef.TakeDame(damage);
                GameObject _explosion = ExplosionPool.Instance.GetExplosion();
                _explosion.transform.position = this.transform.position;
                _explosion.transform.rotation = Quaternion.identity;
                _explosion.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
