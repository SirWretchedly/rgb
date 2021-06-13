using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private static AudioPlay instance = null;
    private AudioSource source;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this)
            return;
        Destroy(gameObject);
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }
}
