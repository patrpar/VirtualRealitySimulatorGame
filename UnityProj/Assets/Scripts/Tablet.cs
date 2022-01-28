using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tablet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    //Item list view
    [SerializeField] private GameObject itemListView;

    //Item preview view
    [SerializeField] private GameObject itemPreviewView;
    
    //Game ending view
    [SerializeField] private GameObject gameEndingView;
    [SerializeField] private TextMeshProUGUI furnitureName;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Image sprite;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI energyPrice;
    [SerializeField] private TextMeshProUGUI waterPrice;
    [SerializeField] private TextMeshProUGUI gasPrice;
    private PurchasableFurniture currentViewedFurniture;
    [SerializeField] private TextMeshProUGUI energyCost;
    [SerializeField] private TextMeshProUGUI waterCost;
    [SerializeField] private TextMeshProUGUI gasCost;
    [SerializeField] private TextMeshProUGUI wynikGry;


    private void Start()
    {
        GameManager.Instance.SetTablet(this);
        SetMoneyText(GameManager.Instance.Money);
        itemListView.SetActive(true);
        itemPreviewView.SetActive(false);
        gameEndingView.SetActive(false);
    }

    public void SetMoneyText(int money)
    {
        this.money.text = money + " zł";
    }

    public void OpenItemPreview(PurchasableFurniture purchasableFurniture)
    {
        currentViewedFurniture = purchasableFurniture;
        itemListView.SetActive(false);
        itemPreviewView.SetActive(true);

        furnitureName.text = purchasableFurniture.FurnitureName;
        price.text = purchasableFurniture.Price.ToString() + " zł";
        sprite.sprite = purchasableFurniture.Sprite;
        description.text = purchasableFurniture.Description;
        energyPrice.text = purchasableFurniture.EnergyPrice.ToString();
        waterPrice.text = purchasableFurniture.WaterPrice.ToString();
        gasPrice.text = purchasableFurniture.GasPrice.ToString();
    }

    public void EndGame()
    {   
        if (gameEndingView.active){
            GameManager.Instance.EndGame();
        }
        else {
            itemListView.SetActive(false);
            itemPreviewView.SetActive(false);
            gameEndingView.SetActive(true);
            energyCost.text = GameManager.Instance.EnergyCost.ToString() + " zł";
            gasCost.text = GameManager.Instance.GasCost.ToString() + " zł";
            waterCost.text = GameManager.Instance.WaterCost.ToString() + " zł";
            if (GameManager.Instance.Money - GameManager.Instance.EnergyCost - GameManager.Instance.GasCost - GameManager.Instance.WaterCost < 0)
            {
                wynikGry.text = "Nie stać cie na rachunki.\nNiestety, ale chyba musisz\nwziąć nadgodziny.";
            }
            else
            {
                wynikGry.text = "Super, udało ci sie spłacić rachunki.\nMożesz teraz wybrać się\nna wymarzone wakacje.";
            }
        }
    }

    public void BuyFurniture()
    {
        if (currentViewedFurniture != null)
        {
            if (GameManager.Instance.Money >= currentViewedFurniture.Price)
            {
                //Temporary
                GameManager.Instance.AddPurchasedFurniture(currentViewedFurniture);
                Instantiate(currentViewedFurniture.Prefab, transform.root.transform.position + transform.root.forward + Vector3.up * 0.12f, Quaternion.identity);
                BackToStore();

                Debug.Log("TODO: Buy");
                //TODO
            }
        }
    }

    public void BackToStore()
    {
        currentViewedFurniture = null;
        itemListView.SetActive(true);
        itemPreviewView.SetActive(false);
    }
}
