using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfterTime : MonoBehaviour
{
    public string scene = "Menu";
    public GameObject staticTV;
    public float delay = 0.5f;

    void Start()
    {
        GameObject.Find("MainSource").GetComponent<AudioSource>().mute = true;
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(15);
        GameObject.Find("MainSource").GetComponent<AudioSource>().mute = false;
        staticTV.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
