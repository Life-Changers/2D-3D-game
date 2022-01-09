using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask platformslayerMask;
    private Rigidbody2D body;
    [SerializeField] private float moveSpeed;
    private BoxCollider2D box;
    //[SerializeField]  private Animator animation;
 
    private void Awake()
    {
        body = transform.GetComponent<Rigidbody2D>();
        box = transform.GetComponent<BoxCollider2D>();
       // animation = transform.GetComponent<Animator>();
    }


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
       // animation.SetBool("run", horizontalInput != 0);

    }

    
}
