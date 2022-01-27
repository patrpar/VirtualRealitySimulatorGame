using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
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
