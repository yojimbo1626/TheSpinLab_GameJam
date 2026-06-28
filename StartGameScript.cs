using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void Next()
    {
        SceneManager.LoadScene("CreditsScene2");
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
