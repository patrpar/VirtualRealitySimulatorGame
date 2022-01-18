using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    [SerializeField] private int moneyOnStart = 200;

    private int money = 0;
    public int Money { get { return money; } private set { money = value; tablet.SetMoneyText(value); } }
    public int Points { get; private set; } = 0;
    private Tablet tablet;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        money = moneyOnStart;
    }

    public void SetTablet(Tablet tablet)
    {
        this.tablet = tablet;
    }

    private void CalculateResult()
    {
        Debug.Log("TODO: CalculateResult");
        //TODO
    }

    public void GoToMainMenu()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
