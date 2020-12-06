using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViePersonnage : MonoBehaviour
{
    [SerializeField]
    private VieHUD m_Vie;

    [SerializeField]
    private int m_Health = 100;

    public int currentVie;
    public Slider barreVie;

    [SerializeField]
    private float immunity = 2f;

    private float lastDamage;

    public int Health { get => m_Health; }

    private void Start()
    {
        currentVie = m_Health;
        m_Vie.SetMaxVie(m_Health);
    }

    public void TakeDamage(int a_Damage)
    {
        float time = Time.time;

        if (time - lastDamage >= immunity)
        {
            lastDamage = time;

            m_Health -= a_Damage;

            m_Vie.SetVie(m_Health);
        }


        if (m_Health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        GameOver.Instance.isDead = true;
    }
}
