using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPixel : MonoBehaviour
{
    public bool isSelected;

    private Move2D move;
    private Join join;
    private Rigidbody2D body;
    private List<GameObject> list;

    void Start()
    {
        move = transform.GetComponent<Move2D>();
        join = transform.GetComponent<Join>();
        body = transform.GetComponent<Rigidbody2D>();
        list = GameObject.Find("TheList").GetComponent<PixelList>().pixelList;
    }

    public void OnMouseDown()
    {
        if (isSelected == true)
        {
            Select();
        }
        else
        {
            foreach (GameObject pixel in list)
            {
                SelectPixel select = pixel.GetComponent<SelectPixel>();
                if (select.isSelected == true)
                {
                    select.Select();
                }
            }

            DeSelect();
        }   
    }

    private void DeSelect()
    {
        foreach (SelectPixel select in transform.GetComponentsInChildren<SelectPixel>())
            select.isSelected = true;
        isSelected = true;

        if (join != null)
            join.enabled = true;

        if (move != null)
            move.enabled = true;

        if (body != null)
            body.constraints = RigidbodyConstraints2D.FreezeRotation;

        Animate(gameObject, "Base Layer.OpenEyes");
    }

    public void Select()
    {
        foreach (SelectPixel select in transform.GetComponentsInChildren<SelectPixel>())
            select.isSelected = false;
        isSelected = false;

        if (join != null)
        {
            join.UnJoin();
            join.enabled = false;
        }

        if (move != null)
            move.enabled = false;

        if (body != null)
            body.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

        Animate(gameObject, "Base Layer.CloseEyes");
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
