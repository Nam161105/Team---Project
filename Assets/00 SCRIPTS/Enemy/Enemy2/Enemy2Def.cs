using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2Def : MonoBehaviour
{
    [SerializeField] protected float maxHp = 100;
    protected float currentHp;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Image _image;
    protected HealthBarOfPlayer _health;

    private void Awake()
    {
        _health = GameObject.FindGameObjectWithTag(CONSTANT._player).GetComponent<HealthBarOfPlayer>();
    }
    private void Start()
    {
        currentHp = maxHp;
        animator = GetComponent<Animator>();
    }

    public void TakeDame(float dame)
    {
        currentHp -= dame;


        animator.SetTrigger(CONSTANT._hurt);
        if(currentHp <= 0)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.monsterDieClip);
            animator.SetTrigger(CONSTANT._die);
            Invoke(CONSTANT._dieScrip, 0.5f);
        } 
        this.UpdateHealthBar();
    }

    protected void Die()
    {
        _health.AddDame(20);
        this.gameObject.SetActive(false);
    }
    protected void UpdateHealthBar()
    {
        _image.fillAmount = currentHp / maxHp;
    }
}
