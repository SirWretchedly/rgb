using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollider : MonoBehaviour
{
    public GameObject colliderObject;

    private void Start()
    {
        colliderObject = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Pixel")
            colliderObject = collision.collider.gameObject;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Pixel")
            colliderObject = collision.collider.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliderObject = null;
    }
}
