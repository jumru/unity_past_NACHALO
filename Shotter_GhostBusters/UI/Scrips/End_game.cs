using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_game : MonoBehaviour
{

    public Count_Done _count_done;
    public GameObject _endMenu;

    void Start()
    {
        _endMenu.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (_count_done._done == 14)
        {
            endGame();
        }
    }
   
    
    public void endGame()
    {
        _endMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
