using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnRetryClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
