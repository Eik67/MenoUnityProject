using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move
        Vector2 input = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: 0);

        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }
        transform.position = (Vector2) transform.position 
            + input
            * Time.deltaTime
            * speed;
        //jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb.AddForce(new Vector2( 0, 1) * jumpHeight,ForceMode2D.Impulse);
        }

    }

    bool isGrounded()
    {
        return Physics2D.Raycast(
        origin: transform.position, 
        direction: Vector2.down, 
        distance: 1.3f, 
            layerMask: groundLayer);
    }
}
