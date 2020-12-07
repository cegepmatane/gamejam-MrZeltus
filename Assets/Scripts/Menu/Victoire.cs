using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Victoire : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreValue;

    public static Victoire Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        
    }
    public void AfficherScore()
    {
        scoreText.text = "Vous avez amasse " + VieHUD.instance.a_Score.ToString() + " cartes";
    }
}
