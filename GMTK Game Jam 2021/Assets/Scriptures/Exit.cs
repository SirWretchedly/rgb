using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject staticTV;

    private void OnMouseDown()
    {
        staticTV.GetComponent<SpriteRenderer>().enabled = true;
        Application.Quit();
    }
}
