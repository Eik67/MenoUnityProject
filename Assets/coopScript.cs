using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coopScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }
    public void disable()
    {
        gameObject.SetActive(false);
    }
}
