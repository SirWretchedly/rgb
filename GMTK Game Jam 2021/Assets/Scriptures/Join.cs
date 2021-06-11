using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Join : MonoBehaviour
{
    public GameObject parent;
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
        if (Input.GetKeyDown("space"))
        {
            isJoining = true;
            move.enabled = false;
        }

        if(isJoining == true)
        {
            if (Input.GetKeyDown("s"))
            {
                if (bottom.colliderObject != null)
                {
                    Merge(gameObject, bottom.colliderObject);
                }

                isJoining = false;
                move.enabled = true;
            }
            if (Input.GetKeyDown("w"))
            {
                if (top.colliderObject != null)
                {
                    Merge(gameObject, top.colliderObject);
                }

                isJoining = false;
                move.enabled = true;
            }
            if (Input.GetKeyDown("a"))
            {
                if (left.colliderObject != null)
                {
                    Merge(gameObject, left.colliderObject);
                }

                isJoining = false;
                move.enabled = true;
            }
            if (Input.GetKeyDown("d"))
            {
                if (right.colliderObject != null)
                {
                    Merge(gameObject, right.colliderObject);
                }

                isJoining = false;
                move.enabled = true;
            }
        }
    }

    private void Merge(GameObject x, GameObject y)
    {   
        while(y.transform.parent != null)
        {
            y = y.transform.parent.gameObject;
        }

        SpriteRenderer spriteX = x.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteY = y.GetComponent<SpriteRenderer>();
        Color color = new Color((spriteX.color.r + spriteY.color.r) / 2,
                                (spriteX.color.g + spriteY.color.g) / 2,
                                (spriteX.color.b + spriteY.color.b) / 2);

        Paint(x, color);
        Paint(y, color);

        Destroy(x.GetComponent<Move2D>());
        Destroy(y.GetComponent<Move2D>());

        Destroy(x.GetComponent<SelectPixel>());
        Destroy(y.GetComponent<SelectPixel>());

        Destroy(x.GetComponent<Join>());
        Destroy(y.GetComponent<Join>());

        Destroy(x.GetComponent<Rigidbody2D>());
        Destroy(y.GetComponent<Rigidbody2D>());

        GameObject clone = Instantiate<GameObject>(parent);
        clone.GetComponent<SpriteRenderer>().color = color;
        clone.transform.position = new Vector2((x.transform.position.x + y.transform.position.x) / 2,
                                               (x.transform.position.y + y.transform.position.y) / 2);
        x.transform.parent = y.transform.parent = clone.transform;

        Move2D move = clone.GetComponent<Move2D>();
        x.GetComponentInChildren<Grounded>().move = move;
        y.GetComponentInChildren<Grounded>().move = move;
    }

    private void Paint(GameObject canvas, Color color)
    {
        SpriteRenderer sprite = canvas.GetComponent<SpriteRenderer>();

        if (sprite == null)
            return;

        sprite.color = color;

        foreach(Transform child in canvas.transform)
            Paint(child.gameObject, color);
    }
}
