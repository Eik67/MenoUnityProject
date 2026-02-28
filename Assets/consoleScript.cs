using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleScript : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 3f )
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.yellow;
        }
    }
}
