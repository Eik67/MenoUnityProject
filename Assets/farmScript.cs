using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class farmScript : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject food;
    [SerializeField] private int numberOfProduce;
    private float countdown;
    

    void Start()
    {
        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown > cooldown)
        {
            spawnFood();
            countdown = 0;
        }
        else
        {
            countdown += Time.deltaTime;
        }
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }
    public void disable()
    {
        gameObject.SetActive(false);
    }

    public void spawnFood()
    {
        for (int i = 0; i < numberOfProduce; i++) {
            Instantiate(food,transform.position, Quaternion.identity);
        }
    }
}
