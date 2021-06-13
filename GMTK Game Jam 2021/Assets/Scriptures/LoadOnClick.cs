using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public string scene;
    public GameObject staticTV;
    public float delay = 1f;

    private void OnMouseDown()
    {
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        staticTV.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
