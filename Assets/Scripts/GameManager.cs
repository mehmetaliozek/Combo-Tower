using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject bodyDesigner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bodyDesigner.SetActive(!bodyDesigner.activeInHierarchy);
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }
    }

    public Transform GetDesignerTransform() => bodyDesigner.transform;
}
