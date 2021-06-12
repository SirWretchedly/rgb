using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            if (!colliderObject.GetComponent<SelectPixel>().isSelected)
            {
                if (colliderObject.gameObject.GetComponent<SpriteRenderer>().color == color)
                    isGood = true;
                else
                    isGood = false;
            }
            else
                isGood = false;
        }
    }
}
