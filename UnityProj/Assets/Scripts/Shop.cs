using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<PurchasableFurniture> furnitures = new List<PurchasableFurniture>();
    [SerializeField] private Transform content;
    [SerializeField] private GameObject itemPrefab;
    private Tablet tablet;


    private void Start()
    {
        tablet = GetComponent<Tablet>();
        foreach (var furniture in furnitures)
        {
            var gameObject = Instantiate(itemPrefab, content);
            gameObject.GetComponent<FurnitureUIItem>().Init(furniture, tablet.OpenItemPreview);
        }
    }
}
