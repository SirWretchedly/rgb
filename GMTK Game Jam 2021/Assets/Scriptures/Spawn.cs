using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject toSpawn;
    public string hotkey;

    void Update()
    {
        if(Input.GetKeyDown(hotkey))
        {
            Instantiate<GameObject>(toSpawn, transform.position, Quaternion.identity);
        }
    }
}
