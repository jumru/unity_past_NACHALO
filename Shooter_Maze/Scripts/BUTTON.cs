using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BUTTON : MonoBehaviour
{
    public GameObject Botton;
    private void Start()
    {
        Cursor.visible = true;
    }
     void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            Botton.GetComponent<MazeCreate>().NewGame();
        }
    }

    public void ButtonReload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
