using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player_Move;

public class Player_Atk : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Transform atkPoint;
    [SerializeField] protected float atkRange = 0.5f;
    [SerializeField] protected LayerMask _enemy;
    [SerializeField] protected float atkTime;
    [SerializeField] protected float atkTime2;
    [SerializeField] protected float atkTime3;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject _bullet;
    protected AudioManager _audioManager;
    protected float nextTimeAtk1 = 0f;
    protected float nextTimeAtk2 = 0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioManager = GameObject.FindGameObjectWithTag(CONSTANT._audio).GetComponent<AudioManager>();
    }

    void Update()
    {
        Atk();
    }

    protected void Atk()
    {
        this.Atk1();
        this.Atk2();
        this.Atk3();
    }

    protected void Atk1()
    {
        if (Time.time > nextTimeAtk1)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                _animator.SetTrigger(CONSTANT._atk2);
                _audioManager.PlaySFX(_audioManager.knifeClip);
                nextTimeAtk1 = Time.time + atkTime2;
                Invoke("InstanceBullet", 0.3f);
            }
        }
    }

    protected void Atk2()
    {
        if (Time.time > nextTimeAtk1)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                _animator.SetTrigger(CONSTANT._atk);
                nextTimeAtk1 = Time.time + atkTime;
                _audioManager.PlaySFX(_audioManager.slashClip);


                Invoke("AtkAfterTime", 0.5f);
            }
        }
    }


    protected void Atk3()
    {
        if(Time.time > nextTimeAtk2)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _animator.SetTrigger(CONSTANT._atk3);
                _audioManager.PlaySFX(_audioManager.knife2Clip);
                nextTimeAtk2 = Time.time + atkTime3;
                Invoke(CONSTANT._insantaceKnife, 0.4f);
            }
        }
    }
    protected void AtkAfterTime()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, _enemy);

        foreach (Collider2D hit in enemy)
        {
            Enemy2Def enemy2Def = hit.GetComponent<Enemy2Def>();
 
            if (enemy2Def != null)
            {
                enemy2Def.TakeDame(damage);
            }
  
            EnemyDef enemyDef = hit.GetComponent<EnemyDef>();
  
            if (enemyDef != null)
            {
                enemyDef.TakeDame(damage);
            }

            NightBorneDef nightDef = hit.GetComponent<NightBorneDef>();
            if(nightDef != null)
            {
                nightDef.TakeDame(damage);
            }

            

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }


    protected void InstanceBullet()
    {
        Vector3 diricetion = transform.localScale.x > 0 ? Vector3.right : Vector3.left;
        GameObject bullet = BulletPool.instance.GetBullet();
        bullet.transform.position = this.transform.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);

        bullet.transform.right = diricetion;
    }

    protected void InstanceKnife()
    {
        Vector3 direction = transform.localScale.x > 0 ? Vector3.right : Vector3.left;
        GameObject knife = KnifePool.Instance.GetKnife();
        knife.transform.position = this.transform.position;
        knife.transform.rotation = Quaternion.identity;
        knife.SetActive(true);

        knife.transform.right = direction;
    }
}
