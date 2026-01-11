using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameManager instance;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        gameOver.GetComponent<GameObject>();
        player.GetComponent<Player>();
        gameOver.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player.health <= 0)
        {
            player.gameObject.SetActive(false);
            EndGame();
        }
    }
    private void EndGame()
    {
        gameOver.SetActive(true);
    }
    public void OnRetryClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
