using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignalVictory : MonoBehaviour
{
    public GameObject[] edges;
    public string scene;
    public bool isVictory;

    private bool isGood;

    private void Start()
    {
        isVictory = false;
    }

    void Update()
    {
        isGood = true;
        foreach(GameObject edge in edges)
            if (edge.GetComponent<CheckPixel>().isGood == false)
                isGood = false;

        if (isGood == true)
        {
            isVictory = true;
            SceneManager.LoadScene(scene);
        } 
    }
}
