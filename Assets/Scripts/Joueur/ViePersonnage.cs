using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViePersonnage : MonoBehaviour
{
    [SerializeField]
    private VieHUD m_Vie;

    [SerializeField]
    private int m_Health = 3;

    [SerializeField]
    private float immunity = 2f;

    private float lastDamage;

    public int Health { get => m_Health; }

    private void Start()
    {
        m_Vie.AfficherVie(m_Health);
    }

    public void TakeDamage(int a_Damage)
    {
        float time = Time.time;

        if (time - lastDamage >= immunity)
        {
            lastDamage = time;

            m_Health -= a_Damage;

            m_Vie.AfficherVie(m_Health);
        }


        if (m_Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //SceneManager.LoadScene("GameOver");
    }
}
