using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignalVictory : MonoBehaviour
{
    public GameObject[] edges;
    public string scene;
    public bool isVictory;
    public GameObject staticTV;
    public float delay = 0.5f;

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

        if (isGood == true && isVictory == false)
        {
            isVictory = true;
            StartCoroutine(Coroutine());
        } 
    }

    IEnumerator Coroutine()
    {
        foreach (GameObject pixel in GameObject.Find("TheList").GetComponent<PixelList>().pixelList)
        {
            if (pixel.GetComponentsInChildren<SpriteRenderer>().Length > 3)
                continue;

            SelectPixel select = pixel.GetComponent<SelectPixel>();
            if (select.isSelected == true)
            {
                Animate(pixel, "Base Layer.CloseEyes");
            }
        }
        yield return new WaitForSeconds(delay);
        staticTV.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    private void Animate(GameObject parent, string animation)
    {
        Animator animator = parent.transform.GetChild(5).GetComponent<Animator>();

        if (animator != null)
            animator.Play(animation);
    }
}
