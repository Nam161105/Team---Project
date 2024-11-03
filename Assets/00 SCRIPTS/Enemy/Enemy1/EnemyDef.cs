using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyDef : MonoBehaviour
{
    [SerializeField] protected float maxHp = 100;
    protected float currentHp;
    [SerializeField] protected Animator _ani;
    [SerializeField] protected Image _image;
    [SerializeField] private Transform _healthTransform;
    private Camera _camera;
    [SerializeField] protected GameObject _prefabExplosion;
    protected AudioManager _audioManager;
    protected HealthBarOfPlayer _healthBarOfPlayer;

    private void Awake()
    {
        if(_healthBarOfPlayer == null)
        {
            _healthBarOfPlayer = GameObject.FindGameObjectWithTag(CONSTANT._player).GetComponent<HealthBarOfPlayer>();
        }
    }
    private void Start()
    {
        currentHp = maxHp;
        _camera = Camera.main;
        _audioManager = GameObject.FindGameObjectWithTag(CONSTANT._audio).GetComponent<AudioManager>();
    }

    private void Update()
    {
        this.healthBarEnemy();
    }

    protected void healthBarEnemy()
    {
        _healthTransform.LookAt(_camera.transform.position);
    }
    public void TakeDame(float dame)
    {
        currentHp -= dame;

        _ani.SetTrigger(CONSTANT._hurt);

        if(currentHp <= 0)
        {
            _audioManager.PlaySFX(_audioManager.enemyDieClip);
            Die();
            
        }
        UpdateHealthBar();
    }

    protected void Die()
    {
        _healthBarOfPlayer.AddDame(10);
        Instantiate(_prefabExplosion, this.transform.position, Quaternion.identity);
        gameObject.SetActive(false);


    }


    protected void UpdateHealthBar()
    {
        _image.fillAmount = currentHp / maxHp;
    }
}
