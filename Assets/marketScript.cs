using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketScript : MonoBehaviour
{
    private GameObject player;
    private UniversalScript us;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        us = player.GetComponent<UniversalScript>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) //HA PLORT
        {
            Debug.Log(us.Money + collision.gameObject.GetComponent<plortScript>().Value);


            us.Money = us.Money + collision.gameObject.GetComponent<plortScript>().Value;
            Destroy(collision.gameObject);
        }
    }
}
