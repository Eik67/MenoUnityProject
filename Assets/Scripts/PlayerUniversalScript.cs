using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UniversalScript : MonoBehaviour
{
    private weaponParentScript weaponParent;
    private SpriteRenderer sprite;
    private float money;
    private TextMeshProUGUI[] menuSlots;
    private Canvas canvas;

    public float Money { get => money; set => money = value; }

    private void Awake()
    {
        weaponParent = GetComponentInChildren<weaponParentScript>();
        sprite = GetComponent<SpriteRenderer>();
        canvas = GameObject.Find("UI").GetComponentInChildren<Canvas>();
        menuSlots = canvas.GetComponentsInChildren<TextMeshProUGUI>();
        Money = 0;
    }
    void Start()
    {

    }

    void Update()
    {
        menuSlots[4].text = "$" + Money  ;

        Vector2 pointerpos = PointerInput();

        //player sprite flipper
        weaponParent.PointerPosition = pointerpos;
        Vector2 direction = (pointerpos - (Vector2)transform.position).normalized;

    }

    
    public Vector2 PointerInput()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );   
        return (Vector2)mousePos;
    }
}