using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); 
    }

    public void LoadStartScene()
    {
        PlayerPrefs.DeleteAll(); 
        SceneManager.LoadScene(0); 
    }

    public void LoadGameOverScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game Over"); 
    }

    public void QuitApplication()
    {
        Application.Quit(); 
    }
}
