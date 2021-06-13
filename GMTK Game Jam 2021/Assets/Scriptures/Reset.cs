using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public string load;
    public float delay = 0.5f;
    public GameObject staticTV;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(Coroutine());
        }
    }

    private void OnMouseDown()
    {
        transform.GetComponent<Animator>().Play("Base Layer.Roll");
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(delay);
        staticTV.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(load);
    }
}