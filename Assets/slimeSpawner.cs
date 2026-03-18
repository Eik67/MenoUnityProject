using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject slime;
    private float countdown;


    void Start()
    {
        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > cooldown)
        {
            spawnFood();
            countdown = 0;
        }
        else
        {
            countdown += Time.deltaTime;
        }
    }

    public void spawnFood()
    {
        
            Instantiate(slime, transform.position, Quaternion.identity);

    }
}
