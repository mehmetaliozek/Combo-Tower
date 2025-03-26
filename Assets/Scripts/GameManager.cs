using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject bodyDesigner;
    public GameState currentState;
    public float gameTimer = 0;
    public float gameMaxTime = 30;
    public GameObject gameoverUI;
    public TextMeshProUGUI gameoverText;
    public Image gameplayTimerUI;
    
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
                gameplayTimerUI.fillAmount = gameTimer/gameMaxTime;
                if(gameTimer >= gameMaxTime) {
                    currentState = GameState.WIN;
                }
            break;
            case GameState.WIN:
                gameoverUI.SetActive(true);
                gameoverText.text = "victory";
                Time.timeScale = 0;
            break;
            case GameState.LOSE:
                gameoverUI.SetActive(true);
                gameoverText.text = "defeat";
                Time.timeScale = 0;
            break;
            default:
            break;
        }
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
