using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private bool isPause;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }

        if (isPause)
        {
            PauseActivate();
        }
        else 
        {
            PauseUnActivate();
        }
    }   

    void PauseActivate()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        canvas.SetActive(true);
    }

    void PauseUnActivate()
    {
        Time.timeScale = 1;
        AudioListener.pause = false ;
        canvas.SetActive(false);
    }


    public void ArreterPause()
    {
        isPause = !isPause;
    }
}
