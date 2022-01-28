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
    [SerializeField] private TextMeshProUGUI furnitureName;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Image sprite;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI energyPrice;
    [SerializeField] private TextMeshProUGUI waterPrice;
    [SerializeField] private TextMeshProUGUI gasPrice;
    private PurchasableFurniture currentViewedFurniture;


    private void Start()
    {
        GameManager.Instance.SetTablet(this);
        SetMoneyText(GameManager.Instance.Money);
        itemListView.SetActive(true);
        itemPreviewView.SetActive(false);
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
        price.text = purchasableFurniture.Price.ToString();
        sprite.sprite = purchasableFurniture.Sprite;
        description.text = purchasableFurniture.Description;
        energyPrice.text = purchasableFurniture.EnergyPrice.ToString();
        waterPrice.text = purchasableFurniture.WaterPrice.ToString();
        gasPrice.text = purchasableFurniture.GasPrice.ToString();
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

    public void EndGame()
    {
        GameManager.Instance.CalculateResult();
    }
}
