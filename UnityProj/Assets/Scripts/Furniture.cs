using UnityEngine;

public class Furniture : MonoBehaviour
{
    [SerializeField] private string furnitureName;
    public string FurnitureName { get => furnitureName; }
}
