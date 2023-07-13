using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NewGame : MonoBehaviour
{
    public GameObject _Menu;
    void Start()
    {
        //Cursor.visible = true;
        Time.timeScale = 0f;
        _Menu.SetActive(true);
    }

    public void StartGame()
    {
        _Menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
