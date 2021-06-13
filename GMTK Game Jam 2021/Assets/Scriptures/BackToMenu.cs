using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public string menu = "Menu";
    public GameObject staticTV;
    public float delay = 0.5f;

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            StartCoroutine(Coroutine());
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        staticTV.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(menu);
    }
}
