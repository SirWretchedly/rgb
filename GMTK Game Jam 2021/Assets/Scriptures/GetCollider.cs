using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollider : MonoBehaviour
{
    public Collider2D colliderBoy;
    public List<Collider2D> contacts = new List<Collider2D>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Pixel")
        {
            colliderBoy = collision.collider;
            contacts.Add(collision.collider);
        }   
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Pixel")
        {
            colliderBoy = collision.collider;
            contacts.Add(collision.collider);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        /*Collider2D aux = new Collider2D();
        colliderBoy = null;
        foreach (Collider2D contact in contacts)
        {
            if (contact == collision.collider)
                aux = contact;
        }*/

        contacts.Clear();
    }

    public Collider2D getBestCollider()
    {
        Collider2D colliderMax = null;
        float min = float.MaxValue;
        foreach(Collider2D contact in contacts)
        {
            if(Vector2.Distance(contact.transform.position, transform.position) < min)
            {
                colliderMax = contact;
                min = Vector2.Distance(contact.transform.position, transform.position);
            }
        }

        return colliderMax;

        //return colliderBoy;
    }

    private Vector2 getPos(GameObject x, Vector3 result)
    {
        if (x.transform.parent != null)
        {
            result += x.transform.parent.position;
            getPos(transform.parent.gameObject, result);
        }

        return result;
    }
}
