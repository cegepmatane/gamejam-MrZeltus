using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] public bool isDead;
    public void Update()
    {
        if (isDead == true)
        {
            GameOverActivate();
        }
    }   

    void GameOverActivate()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        canvas.SetActive(true);
    }
}
