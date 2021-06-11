using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Join : MonoBehaviour
{
    public bool isJoining;

    private Move2D move;
    private GetCollider bottom, top, left, right;

    void Start()
    {
        isJoining = false;
        move = transform.GetComponent<Move2D>();
        bottom = transform.GetChild(0).gameObject.GetComponent<GetCollider>();
        top = transform.GetChild(1).gameObject.GetComponent<GetCollider>();
        left = transform.GetChild(2).gameObject.GetComponent<GetCollider>();
        right = transform.GetChild(3).gameObject.GetComponent<GetCollider>();
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            isJoining = true;
            move.enabled = false;

            if(Input.GetKeyDown("down"))
            {
                if(bottom.colliderObject != null)
                {

                }
            }
            else if(Input.GetKeyDown("up"))
            {

            }
            else if (Input.GetKeyDown("left"))
            {

            }
            else if (Input.GetKeyDown("right"))
            {

            }
        }
    }

    private void Merge(GameObject x, GameObject y)
    {
        SpriteRenderer spriteX = x.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteY = y.GetComponent<SpriteRenderer>();

        spriteX.color = spriteY.color = new Color((spriteX.color.r + spriteY.color.r) / 2,
                                                 (spriteX.color.g + spriteY.color.g) / 2,
                                                 (spriteX.color.b + spriteY.color.b) / 2);
    }
}
