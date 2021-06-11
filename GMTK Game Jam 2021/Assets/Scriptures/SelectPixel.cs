using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPixel : MonoBehaviour
{
    public bool isSelected;

    private Move2D move;
    private Rigidbody2D body;

    void Start()
    {
        isSelected = true;
        move = transform.GetComponent<Move2D>();
        body = transform.GetComponent<Rigidbody2D>();
    }

    public void OnMouseDown()
    {
        if (isSelected == true)
        {
            isSelected = false;
            move.enabled = false;
            body.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            isSelected = true;
            move.enabled = true;
            body.constraints = RigidbodyConstraints2D.None;
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }   
    }
}
