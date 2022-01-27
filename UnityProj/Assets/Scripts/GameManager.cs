using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private int moneyOnStart = 16000;

    private int money = 0;
    private List<PurchasableFurniture> purchasedFurniture = new List<PurchasableFurniture>();

    public int Money 
	{ get { return money; } private set { money = value; tablet.SetMoneyText(value); } }
    public int Points { get; private set; } = 53;
    public int EnergyCost { get; private set; } = 0;
    public int GasCost { get; private set; } = 0;
    public int WaterCost { get; private set; } = 100;
    public int WeatherLevel { get; private set; } = 3;
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

    public void AddPurchasedFurniture(PurchasableFurniture purchasableFurniture)
    {
        purchasedFurniture.Add(purchasableFurniture);
        Money -= purchasableFurniture.Price;
        EnergyCost += purchasableFurniture.EnergyPrice;
        GasCost += purchasableFurniture.GasPrice;
        WaterCost += purchasableFurniture.WaterPrice;
        Points += purchasableFurniture.ExtraPoints;

        if (Points >= 85)
        {
            SetWeather(4);
        }
        else if (Points >= 64)
        {
            SetWeather(3);
        }
        else if (Points >= 43)
        {
            SetWeather(2);
        }
        else if (Points >= 22)
        {
            SetWeather(1);
        }
        else if (Points >= 0)
        {
            SetWeather(0);
        }
    }

    public void CalculateResult()
    {
        Debug.Log("TODO: CalculateResult");
        //TODO
        Money = Money - EnergyCost - GasCost - WaterCost;
        if (Money > 0) {
            //TODO wyświetlenie biura podróży
            Debug.Log("biuro podróży");
        }
        else {
            //TODO wyświetlenie pracodawcy
            Debug.Log("pracodawca");
        }

    }

    public void SetWeather(int level)
    {
        //TODO pogoda
        switch (level)
        {
            case 0:
                Debug.Log("TODO: najlepsza pogoda");
                break;
            case 1:
                Debug.Log("TODO: dobra pogoda");
                break;
            case 2:
                Debug.Log("TODO: standardowa pogoda");
                break;
            case 3:
                Debug.Log("TODO: zła pogoda");
                break;
            case 4:
                Debug.Log("TODO: najgorsza pogoda");
                break;
        }
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
