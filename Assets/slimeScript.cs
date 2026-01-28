using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    [SerializeField] private float hungerDrain;
    [SerializeField] private float maxHunger;
    [SerializeField] private LayerMask foodLayer;

    private float jumpInbetween;
    private float jumpInbetweenCountdown;
    private float hunger;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        newTimer();
        maxHunger = 100;
        hunger = maxHunger/2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jumpInbetweenCountdown > 0)
        {
            jumpInbetweenCountdown -= Time.deltaTime;
        }
        else
        {
            jump();
            newTimer();
        }
        if (hunger > 0)
        {
            hunger -= Time.deltaTime*hungerDrain;
            sprite.color = Color.white;
        }
        else
        {
            sprite.color = Color.red;
        }

    }

    void newTimer()
    {
        jumpInbetween = Random.Range(2.5f, 4.5f);
        jumpInbetweenCountdown = jumpInbetween;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //HA KAJA
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            hunger += maxHunger*0.8f;
        }
    }

    void jump()
    {
        float jumpStr = Random.Range(1, 3);

        float x = Random.Range(-6, 6);
        float y = Random.Range(2, 5);
        Vector2 jumpDir =   new Vector2(
            transform.position.x + x,
            transform.position.y + y
            ) - (Vector2)   transform.position;
        rb.AddForce(jumpDir * jumpStr, ForceMode2D.Impulse);
        rb.angularVelocity = 0;

        if(x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

    }

}
