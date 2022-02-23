﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Personnage : MonoBehaviour
{
    public static Personnage Instance;
    public Transform firePoint;
    public Rigidbody2D body;
    public bool isShield = false;
    public float speedTime = 5f;
    public int speedToAdd = 10;
    [SerializeField] int force = 100;

    private float currentTime = 0f;
    internal bool isSpeed = false;
    int addSpeed = 0;

    public void Heal(int healAmmount)
    {
        transform.GetComponent<ViePersonnage>().m_Health += healAmmount;
        if (transform.GetComponent<ViePersonnage>().m_Health > transform.GetComponent<ViePersonnage>().max_Health) {
            transform.GetComponent<ViePersonnage>().m_Health = transform.GetComponent<ViePersonnage>().max_Health;
        };
        transform.GetComponent<ViePersonnage>().m_Vie.SetVie(transform.GetComponent<ViePersonnage>().m_Health);
    }


    public void Shield()
    {
        isShield = true;
    }
    public void Speed()
    {
        isSpeed = true;
        currentTime = speedTime;
    }

    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public float runSpeed = 10.0f;

    public void Awake()
    {
        if (Instance != null)
            Debug.LogError("Instance already exist");
        Instance = this;
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //if(col.transform.tag == "Portal")
        //{
        //    GameManager.Instance.ChangeRoom(col.transform.gameObject);
        //}

        if (col.transform.tag == "Ennemi")
        {
            transform.GetComponent<ViePersonnage>().TakeDamage(col.transform.GetComponent<Ennemis>().dammage, col.transform.GetComponent<Ennemis>());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        int CoinValue = 1;

        if (col.transform.tag == "coinmaster")
        {
            col.transform.parent.GetComponent<CarteCredit>().ApparitionCoins();
            VieHUD.instance.ChangeScore(CoinValue);
            Destroy(col.gameObject);
        }
        if (col.transform.tag == "Coin")
        {
            VieHUD.instance.ChangeScore(CoinValue);
            Destroy(col.gameObject);
        }

        if (col.transform.tag == "Victoire")
        {
            Pause.Instance.isWin = true;
            Victoire.Instance.AfficherScore();
            Destroy(col.gameObject);
        }
        if (col.transform.tag == "ChangerNiveau")
        {
            SceneManager.LoadScene("Niveau2");
        }
    }
    private void FixedUpdate()
    {
        if (x != 0) body.AddForce(Vector2.right * x * force);
        if (y != 0) body.AddForce(Vector2.up * y * force);
    }
}