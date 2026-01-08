using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalScript : MonoBehaviour
{
    private weaponParentScript weaponParent;
    private SpriteRenderer sprite;

    private void Awake()
    {
        weaponParent = GetComponentInChildren<weaponParentScript>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

    }

    void Update()
    {
        Vector2 pointerpos = PointerInput();

        //player sprite flipper
        weaponParent.PointerPosition = pointerpos;
        Vector2 direction = (pointerpos - (Vector2)transform.position).normalized;
        if (direction.x < 0)
        {
            sprite.flipX = false;
        }
        else if (direction.x > 0)
        {
            sprite.flipX = true;

        }


    }

    
    public Vector2 PointerInput()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );   
        return (Vector2)mousePos;
    }
}