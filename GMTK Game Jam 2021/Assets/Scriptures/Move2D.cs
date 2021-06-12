using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

public class Move2D : MonoBehaviour
{
    public float speed = 4;
    public float jumpHeight = 6;
    public bool grounded = false;

    private Rigidbody2D rigidBody;
    private float horizontal;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(speed * horizontal, rigidBody.velocity.y);
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("up")) && grounded)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);    
    }
}
