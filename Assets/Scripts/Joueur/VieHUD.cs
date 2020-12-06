using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VieHUD : MonoBehaviour
{
    public static VieHUD instance;
    public Text m_TextCollectible;
    public Text m_WinText;
    public Slider slider;
    int a_Score;

    public void Start()
    {
        if (instance == null)
            instance = this;

        m_WinText.text = "";
    }

    public void ChangeScore(int a_CollectableValue)
    {
        a_Score += a_CollectableValue;
        m_TextCollectible.text = ": " + a_Score.ToString();

        if (a_Score == 11)
        {
            m_WinText.text = "VICTOIRE";

        }
    }

    public void SetVie(int vie)
    {
        slider.value = vie;
    }

    public void SetMaxVie(int vie)
    {
        slider.maxValue = vie;
        slider.value = vie;
    }

}
