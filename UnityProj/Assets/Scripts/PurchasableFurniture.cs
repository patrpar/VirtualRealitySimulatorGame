using UnityEngine;

[CreateAssetMenu(fileName = "Furniture", menuName = "ScriptableObjects/PurchasableFurniture", order = 1)]
public class PurchasableFurniture : ScriptableObject
{
    [SerializeField] private string furnitureName;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int price;
    [SerializeField] private string description;
    [SerializeField] private int extraPoints;
    [SerializeField] private int energyPrice;
    [SerializeField] private int waterPrice;
    [SerializeField] private int gasPrice;
    [SerializeField] private GameObject prefab;

    #region Properties
    public string FurnitureName { get => furnitureName; }
    public Sprite Sprite { get => sprite; }
    public int Price { get => price; }
    public string Description { get => description; }
    public int ExtraPoints { get => extraPoints; }
    public int EnergyPrice { get => energyPrice; }
    public int WaterPrice { get => waterPrice; }
    public int GasPrice { get => gasPrice; }
    public GameObject Prefab { get => prefab; }
    #endregion Properties
}
