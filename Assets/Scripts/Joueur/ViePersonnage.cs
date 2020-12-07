using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViePersonnage : MonoBehaviour
{
    [SerializeField]
    public VieHUD m_Vie;

    public bool isDead = false;
    [SerializeField]
    public int m_Health = 100;
    public int max_Health = 100;
    float subtractPerSecond = 0.5f;
    float fade = 1;
    public int currentVie;
    public Slider barreVie;
    public bool isDone = false;
    Material material;
    [SerializeField]
    private float immunity = 2f;

    private float lastDamage;

    public int Health { get => m_Health; set { Health = value; } }

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        currentVie = m_Health;
        m_Vie.SetMaxVie(m_Health);
    }
    public void Update()
    {
        if (isDead == true)
        {
            fade -= subtractPerSecond * Time.deltaTime;
            material.SetFloat("_Fade", fade);
        }
    }
    public void TakeDamage(int a_Damage)
    {
        float time = Time.time;

        if (time - lastDamage >= immunity)
        {

            if(Personnage.Instance.isShield == false)
            {
                lastDamage = time;
                m_Health -= a_Damage;
                m_Vie.SetVie(m_Health);
            }
            else
            {
                Personnage.Instance.isShield = false;
            }
            
        }
        if (m_Health <= 0)
        {
            if(isDone == false)
                StartCoroutine("Die");
            isDone = true;
        }
       
    }
    public void TakeDamage(int a_Damage,Ennemis ennemie)
    {
        float time = Time.time;

        if (time - lastDamage >= immunity)
        {
            ennemie.StartCoroutine("Attaque");
            if (Personnage.Instance.isShield == false)
            {
                lastDamage = time;
                m_Health -= a_Damage;
                m_Vie.SetVie(m_Health);
            }
            else
            {
                Personnage.Instance.isShield = false;
            }

        }
        if (m_Health <= 0)
        {
            if (isDone == false)
                StartCoroutine("Die");
            isDone = true;
        }

    }
    IEnumerator Die()
    {
        isDead = true;
        yield return new WaitForSeconds(2f);
        GameOver.Instance.isDead = true;
    }
}
