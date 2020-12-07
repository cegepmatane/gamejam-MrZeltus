using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jouer()
    {
        Debug.Log("Jouer");
        SceneManager.LoadScene("Niveau1");
    }

    public void Quitter()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }

    public void RetourAuMenu()
    {
        Debug.Log("Retour au Menu");
        SceneManager.LoadScene("Main Menu");
    }

}
