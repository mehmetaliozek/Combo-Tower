using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject bodyDesigner;
    public GameState currentState;
    public float gameTimer = 0;
    public float gameMaxTime = 300;
    public enum GameState {
        GAMEPLAY,
        WIN,
        LOSE
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start() {
        currentState = GameState.GAMEPLAY;
    }

    void Update()
    {
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            bodyDesigner.SetActive(!bodyDesigner.activeInHierarchy);
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }*/
        switch (currentState)
        {
            case GameState.GAMEPLAY:
                gameTimer += Time.deltaTime;
                if(gameTimer >= gameMaxTime) {
                    currentState = GameState.WIN;
                }
            break;
            case GameState.WIN:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("WIN");
                Time.timeScale = 0;
            break;
            case GameState.LOSE:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("LOSE");
                Time.timeScale = 0;
            break;
            default:
            break;
        }
    }
}
