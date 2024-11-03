using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBarOfPlayer : MonoBehaviour
{
    [SerializeField] protected HealthSCTO _healthSc;
    [SerializeField] protected Image _image;

    [SerializeField] protected string _name;
    protected Animator _animator;
    protected AudioManager _audioManager;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioManager = GameObject.FindGameObjectWithTag(CONSTANT._audio).GetComponent<AudioManager>();
        UpdateHealth();
    }


    public void TakeDamage(float dame)
    {
        _healthSc.currentHp -= dame;
        _animator.SetTrigger(CONSTANT._hurt);
        if(_healthSc.currentHp <= 0)
        {
            _audioManager.PlaySFX(_audioManager.dieClip);
            Invoke(CONSTANT._loadScene, 1f);
            
        } 
        UpdateHealth();
    }


    public void AddDame(float dame)
    {
        _healthSc.currentHp += dame;
        if (_healthSc.currentHp > _healthSc.maxHp) _healthSc.currentHp = _healthSc.maxHp;
        UpdateHealth();
    }
    protected void LoadScene()
    {
        SceneManager.LoadScene(_name);
        _healthSc.currentHp = _healthSc.maxHp;
    }
    protected void UpdateHealth()
    {
        _image.fillAmount = _healthSc.currentHp / _healthSc.maxHp;
    }
}
