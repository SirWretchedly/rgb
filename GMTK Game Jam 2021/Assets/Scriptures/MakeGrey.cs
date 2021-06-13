using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGrey : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(154, 154, 154);
    }
}
