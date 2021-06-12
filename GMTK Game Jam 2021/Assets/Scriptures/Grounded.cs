using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public Move2D move;

    private void Start()
    {
        move = transform.parent.GetComponent<Move2D>();

        while(move == null)
        {
            move = move.transform.parent.GetComponent<Move2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        move.grounded = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        move.grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        move.grounded = false;
    }
}
