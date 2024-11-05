using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NightBorneDef : MonoBehaviour
{
    [SerializeField] protected float maxHp;
    protected float currentHp;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Image _image;
    protected HealthBarOfPlayer _health;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        _health = GameObject.FindGameObjectWithTag(CONSTANT._player).GetComponent<HealthBarOfPlayer>();
    }
    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDame(float dame)
    {
        currentHp -= dame;
        

        if (currentHp <= 0)
        {
            _health.AddDame(20);
            animator.SetTrigger(CONSTANT._die);
            this.gameObject.SetActive(false);

        }
        this.UpdateHealthBar();
    }

    protected void UpdateHealthBar()
    {
        _image.fillAmount = currentHp / maxHp;
    }
}
