using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private AudioSource audioS;

    // Start is called before the f irst frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioS.Stop();  
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

        //soundfx
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            audioS.Play();
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            audioS.Stop();
        }

    }

    bool isGrounded()
    {
        return Physics2D.Raycast(
        origin: transform.position, 
        direction: Vector2.down, 
        distance: 1.9f, 
            layerMask: groundLayer);
    }
}
