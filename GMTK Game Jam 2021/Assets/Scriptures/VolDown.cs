using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolDown : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GameObject.Find("MainSource").GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        source.volume -= 0.1f;
    }
}
