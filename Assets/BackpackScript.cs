using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class BackpackScript : MonoBehaviour
{
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    [SerializeField] GameObject item4;
    [SerializeField] GameObject item5;
    [SerializeField] GameObject item6;
    [SerializeField] GameObject item7;
    [SerializeField] GameObject food;
    [SerializeField] GameObject plort;


    [SerializeField] float shootForce;

    private Hashtable table;
    private VacuumScript vacuumScript;
    private int activeSlot;
    private GameObject vacuum;
    private GameObject player;
    private Canvas canvas;
    private TextMeshProUGUI[] menuSlots;
    private UniversalScript us;

    void Start()
    {
        canvas = GameObject.Find("UI").GetComponentInChildren<Canvas>();
        vacuum = GameObject.Find("Vacuum");
        player = GameObject.Find("Player");
        us = player.GetComponent<UniversalScript>();
        table = new Hashtable();
        vacuumScript = GetComponentInParent<VacuumScript>();
        activeSlot = 1; 
        menuSlots = canvas.GetComponentsInChildren<TextMeshProUGUI>();
        menuUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            activeSlot = 1;
            menuUpdate();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeSlot = 2;
            menuUpdate();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeSlot = 3;
            menuUpdate();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activeSlot = 4;
            menuUpdate();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        int counter = 1;
        object projectileId = null;
        foreach (var item in table.Keys)
        {
            if (counter == activeSlot) { 
                projectileId = item; break;
            }
            counter++;
        }
        //mit lo?
        GameObject projectile = null;
        if (projectileId != null) {
            switch (projectileId) {
                case 1: projectile = item1;break;
                case 2: projectile = item2;break;
                case 3: projectile = item3;break;
                case 4: projectile = item4;break;
                case 5: projectile = item5;break;
                case 6: projectile = item6;break;
                case 7: projectile = item7; break;
                case 10: projectile = food;break;
                case 20: projectile = plort;break;
            }
            //merre
            var spawned = Instantiate(projectile, vacuum.transform.position, Quaternion.identity);
            Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
            rb.AddForce(
                (us.PointerInput() - (Vector2)player.transform.position).normalized * shootForce, 
                ForceMode2D.Impulse);
            //rb.rotation = Random.Range(0,361);
            rb.angularVelocity = Random.Range(-150, 150);

            //inv management
            table[projectileId] = (int)table[projectileId]-1;
            if ((int)table[projectileId] == 0)
            {
                table.Remove(projectileId);
            }
            menuUpdate();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (vacuumScript.Vacuuming)
        {
            try
            {
                VacuumableScript vs = collision.GetComponent<VacuumableScript>();
                
                    if (table.ContainsKey(vs.Id))
                    {
                        table[vs.Id] = (int)table[vs.Id] + 1;
                        Debug.Log(vs.Id+" | "+table[vs.Id]);
                        Destroy(vs.gameObject);
                        menuUpdate();
                       }
                    else if(table.Count < 4)
                    {
                        table.Add(vs.Id, 1);
                        Debug.Log(vs.Id + " | " + table[vs.Id]);
                        Destroy(vs.gameObject);
                        menuUpdate();
                    }
                    
                

            }
            catch (Exception) { }
        }
    }

    void menuUpdate()
    {
        int counter = 0;
        foreach (var id in table.Keys)
        {
            menuSlots[counter].text = id + " | " + table[id]    ;
            counter++;
        }

        for(;counter < 4; counter++)
        {
            menuSlots[counter].text = "Empty";
        }
        foreach (var text in menuSlots)
        {
            text.color = Color.white;
        }
        menuSlots[activeSlot-1].color = new Color32(255, 182, 193, 255);

    }

}
