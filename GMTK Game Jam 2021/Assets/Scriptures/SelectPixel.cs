using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPixel : MonoBehaviour
{
    public bool isSelected;

    private Move2D move;
    private Join join;
    private Rigidbody2D body;

    void Start()
    {
        move = transform.GetComponent<Move2D>();
        join = transform.GetComponent<Join>();
        body = transform.GetComponent<Rigidbody2D>();
    }

    public void OnMouseDown()
    {
        if (isSelected == true)
        {
            foreach(SelectPixel select in transform.GetComponentsInChildren<SelectPixel>())
                select.isSelected = false;
            isSelected = false;

            if(move != null)
                move.enabled = false;

            if(join != null)
                join.enabled = false;

            if(body != null)
                body.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

            Animate(gameObject, "Base Layer.CloseEyes");
        }
        else
        {
            foreach (SelectPixel select in transform.GetComponentsInChildren<SelectPixel>())
                select.isSelected = true;
            isSelected = true;

            if (move != null)
                move.enabled = true;

            if (join != null)
                join.enabled = true;

            if (body != null)
                body.constraints = RigidbodyConstraints2D.FreezeRotation;

            Animate(gameObject, "Base Layer.OpenEyes");
        }   
    }

    private void Animate(GameObject parent, string animation)
    {
        Animator animator = parent.GetComponent<Animator>();

        if(animator != null)
            animator.Play(animation);

        foreach(Transform child in parent.transform)
            Animate(child.gameObject, animation);
    }
}
