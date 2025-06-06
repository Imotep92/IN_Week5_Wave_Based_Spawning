using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleMenu : MonoBehaviour
{

    public GameObject game_Over_Panel;
    public bool GameIsOver = false;



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
}
