using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Join : MonoBehaviour
{
    public GameObject parent;
    public bool isJoining;

    private Move2D move;
    private GetCollider bottom, top, left, right;
    private SpriteRenderer highlight;
    private Color color;

    void Start()
    {
        isJoining = false;
        move = transform.GetComponent<Move2D>();
        bottom = transform.GetChild(0).gameObject.GetComponent<GetCollider>();
        top = transform.GetChild(1).gameObject.GetComponent<GetCollider>();
        left = transform.GetChild(2).gameObject.GetComponent<GetCollider>();
        right = transform.GetChild(3).gameObject.GetComponent<GetCollider>();
        highlight = transform.GetChild(4).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            isJoining = true;
            move.enabled = false;
            highlight.enabled = true;
        }

        if(isJoining == true)
        {
            if (Input.GetKeyDown("s"))
            {
                if (bottom.getBestCollider() != null)
                {
                    Merge(gameObject, bottom.getBestCollider().gameObject, 1, 0);
                }

                UnJoin();
            }
            if (Input.GetKeyDown("w"))
            {
                if (top.getBestCollider() != null)
                {
                    Merge(gameObject, top.getBestCollider().gameObject, -1, 0);
                }

                UnJoin();
            }
            if (Input.GetKeyDown("a"))
            {
                if (left.getBestCollider() != null)
                {
                    Merge(gameObject, left.getBestCollider().gameObject, 0, 1);
                }

                UnJoin();
            }
            if (Input.GetKeyDown("d"))
            {
                if (right.getBestCollider() != null)
                {
                    Merge(gameObject, right.getBestCollider().gameObject, 0, -1);
                }

                UnJoin();
            }
        }
    }

    public void UnJoin()
    {
        isJoining = false;
        move.enabled = true;
        highlight.enabled = false;
    }

    private void Merge(GameObject x, GameObject y, int moveY, int moveX)
    {
        x.transform.position = new Vector2(y.transform.position.x + moveX, y.transform.position.y + moveY);

        while (y.transform.parent != null)
        {         
            y = y.transform.parent.gameObject;

            if (y.GetComponent<SpriteRenderer>() != null)
            {
                SpriteRenderer spriteX = x.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteY = y.GetComponent<SpriteRenderer>();

                color = new Color((spriteX.color.r + spriteY.color.r) / 2,
                                  (spriteX.color.g + spriteY.color.g) / 2,
                                  (spriteX.color.b + spriteY.color.b) / 2);
            }
        }

        Paint(x, color);
        Paint(y, color);

        Select(x);
        Select(y);

        Animate(x, "Base Layer.OpenEyes");
        Animate(y, "Base Layer.OpenEyes");

        Destroy(x.GetComponent<Move2D>());
        Destroy(y.GetComponent<Move2D>());

        Destroy(x.GetComponent<Join>());
        Destroy(y.GetComponent<Join>());

        Destroy(x.GetComponent<Rigidbody2D>());
        Destroy(y.GetComponent<Rigidbody2D>());

        GameObject clone = Instantiate<GameObject>(parent);
        clone.transform.position = new Vector2((x.transform.position.x + y.transform.position.x) / 2,
                                               (x.transform.position.y + y.transform.position.y) / 2);
        x.transform.parent = y.transform.parent = clone.transform;

        GameObject.Find("TheList").GetComponent<PixelList>().pixelList.Add(clone);

        clone.GetComponent<SelectPixel>().isSelected = true;

        Move2D move = clone.GetComponent<Move2D>();
        foreach (Grounded grounded in clone.GetComponentsInChildren<Grounded>())
            grounded.move = move;
    }

    private void Paint(GameObject canvas, Color color)
    {
        if (canvas.transform.childCount == 0)
            return;

        SpriteRenderer sprite = canvas.GetComponent<SpriteRenderer>();

        if(sprite != null)
            sprite.color = color;

        foreach(Transform child in canvas.transform)
            Paint(child.gameObject, color);
    }

    private void Select(GameObject parent)
    {
        if (parent.transform.childCount == 0)
            return;

        SelectPixel select = parent.GetComponent<SelectPixel>();

        if (select != null)
            select.isSelected = true;

        foreach (Transform child in parent.transform)
            Select(child.gameObject);
    }

    private void Animate(GameObject parent, string animation)
    {
        Animator animator = parent.GetComponent<Animator>();

        if (animator != null)
            animator.Play(animation);

        foreach (Transform child in parent.transform)
            Animate(child.gameObject, animation);
    }
}
