using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public bool isEscapeToExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            } else
            {
                KembaliKeMenu();
            }
        }
    }

    public void MulaiPermainan()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
