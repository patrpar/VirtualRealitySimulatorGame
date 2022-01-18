using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FurnitureUIItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI furnitureName;
    [SerializeField] private TextMeshProUGUI price;
    private PurchasableFurniture purchasableFurniture;

    public delegate void ShowDetailsDelegate(PurchasableFurniture purchasableFurniture);
    private ShowDetailsDelegate showDetailsDelegate;


    public void Init(PurchasableFurniture purchasableFurniture, ShowDetailsDelegate showDetailsDelegate)
    {
        this.purchasableFurniture = purchasableFurniture;
        this.showDetailsDelegate = showDetailsDelegate;

        furnitureName.text = purchasableFurniture.FurnitureName;
        price.text = purchasableFurniture.Price.ToString();
    }

    public void ShowDetails()
    {
        showDetailsDelegate(purchasableFurniture);
    }
}
