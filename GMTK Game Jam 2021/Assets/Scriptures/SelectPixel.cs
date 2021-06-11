using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPixel : MonoBehaviour
{
    public bool isSelected;

    private Move2D move;
    private Join join;

    void Start()
    {
        isSelected = true;
        move = transform.GetComponent<Move2D>();
        join = transform.GetComponent<Join>();
    }

    public void OnMouseDown()
    {
        if (isSelected == true)
        {
            isSelected = false;
            move.enabled = false;
            join.enabled = false;
        }
        else
        {
            isSelected = true;
            move.enabled = true;
            join.enabled = true;
        }   
    }
}
