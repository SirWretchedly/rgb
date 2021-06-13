using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPixel : MonoBehaviour
{
    public GameObject colliderObject;
    public bool isGood;

    private Color color;

    void Start()
    {
        isGood = false;
        color = transform.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, new Vector2(0.2f, 0.2f), 0);
        if (collider == null)
            isGood = false;

        else if(collider.tag == "Pixel")
        {
            colliderObject = collider.gameObject;

            while (colliderObject.transform.parent != null)
            {
                if (colliderObject.GetComponent<SpriteRenderer>() != null)
                    break;
                colliderObject = colliderObject.transform.parent.gameObject;
            }

            if (compare(colliderObject.gameObject.GetComponent<SpriteRenderer>().color,color))
                isGood = true;
            else
                isGood = false;
        }
    }

    bool compare(Color x, Color y)
    {
        if (Math.Abs(x.r - y.r) > 0.15)
            return false;
        if (Math.Abs(x.g - y.g) > 0.15)
            return false;
        if (Math.Abs(x.b - y.b) > 0.15)
            return false;

        return true;
    }
}
