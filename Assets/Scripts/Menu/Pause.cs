using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject canvasWin;
    [SerializeField] public bool isPause;
    [SerializeField] public bool isWin;

    public static Pause Instance;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Une instance a déjà été créée");
        Instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }

        if (isPause || isWin)
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
        if (isWin == true)
        {
            canvasWin.SetActive(true);
        }
        else if (isPause == true)
        {
            canvas.SetActive(true);
        }
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
