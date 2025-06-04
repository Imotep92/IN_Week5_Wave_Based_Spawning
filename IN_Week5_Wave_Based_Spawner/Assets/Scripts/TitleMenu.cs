using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleMenu : MonoBehaviour
{
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        //GetComponent<PlayerController>().enabled = false;
    }

    void Update()
    {
        
    }
}
