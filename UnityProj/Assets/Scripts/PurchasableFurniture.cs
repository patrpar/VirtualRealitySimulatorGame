using UnityEngine;

[System.Serializable]
public class PurchasableFurniture
{
    [SerializeField] private string furnitureName;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int price;
    [SerializeField] private string description;
    [SerializeField] private int extraPoints;
    [SerializeField] private int energyPrice;
    [SerializeField] private int waterPrice;
    [SerializeField] private int gasPrice;

    #region Properties
    public string FurnitureName { get => furnitureName; }
    public Sprite Sprite { get => sprite; }
    public int Price { get => price; }
    public string Description { get => description; }
    public int ExtraPoints { get => extraPoints; }
    public int EnergyPrice { get => energyPrice; }
    public int WaterPrice { get => waterPrice; }
    public int GasPrice { get => gasPrice; }
    #endregion Properties


    public void Buy()
    {
        Debug.Log("TODO: Buy");
        //TODO
    }
}
