using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public string menu = "Menu";

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(menu);
        }
    }
}
