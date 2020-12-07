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
    public Slider slider;
    public int a_Score;

    public void Start()
    {
        if (instance == null)
            instance = this;

        m_TextCollectible.text = "";
    }

    public void ChangeScore(int a_CollectableValue)
    {
        a_Score += a_CollectableValue;
        m_TextCollectible.text = ": " + a_Score.ToString();
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
