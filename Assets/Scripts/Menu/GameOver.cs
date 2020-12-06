using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] public bool isDead;

    public static GameOver Instance;

    private void Awake()
    {
        if(Instance != null)
            Debug.LogError("Une instance a déjà été créée");
        Instance = this;
    }

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
