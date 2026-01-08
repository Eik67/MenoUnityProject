using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponParentScript : MonoBehaviour
{
    public Vector2 PointerPosition { get; set; }

    private void Update()
    {
        
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        // cursor felé pointol
        transform.right = direction;

        // megfordul félúton
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }

        transform.localScale = scale;

    }
}
