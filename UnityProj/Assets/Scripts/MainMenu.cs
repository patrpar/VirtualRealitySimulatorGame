using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject player;


    private void Start()
    {
        player.SetActive(false);
    }

    public void StartGame()
    {
        player.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowInfo()
    {
        Debug.Log("TODO: ShowInfo");
        //TODO
    }

    public void Exit()
    {
        GameManager.Instance.EndGame();
    }
}
