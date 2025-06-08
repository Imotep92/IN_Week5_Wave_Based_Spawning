using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleMenu : MonoBehaviour
{

    public GameObject game_Over_Panel;
    public GameObject pause_Panel;
    public bool GameIsOver = false;

    public bool GameIsPaused = false;



    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        //GetComponent<PlayerController>().enabled = false;
    }

    void Update()
    {

    }

    void GameOver()
    {

    }

    void Pause()
    {
        if (!GameIsPaused)
        {
            pause_Panel.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        

    }
    
    void Resume()
    {
        
    }
}
