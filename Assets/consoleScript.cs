using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class consoleScript : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sr;
    private UniversalScript us;
    private GameObject plot;
    private farmScript plotFarm;
    private coopScript plotCoop;
    private bool occupied;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        us = player.GetComponent<UniversalScript>();
        sr = GetComponent<SpriteRenderer>();
        plot = gameObject.transform.parent.gameObject;
        plotCoop = plot.GetComponentInChildren<coopScript>();
        plotFarm = plot.GetComponentInChildren<farmScript>();
        plotCoop.disable();
        plotFarm.disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 3f )
        {
            sr.color = Color.green;
            if(!occupied && Input.GetKeyDown(KeyCode.T) && us.Money >=200)
            {
                buyCoop();
                occupied = true;
            }
            if (!occupied && Input.GetKeyDown(KeyCode.G) && us.Money >= 200)
            {
                buyFarm();
                occupied = true;
            }
        }
        else
        {
            sr.color = Color.yellow;
        }
    }

    void buyCoop()
    { 
        us.Money = us.Money -200;  
        plotCoop.activate();
    }

    void buyFarm()
    {
        us.Money = us.Money - 200;
        plotFarm.activate();
    }
}
