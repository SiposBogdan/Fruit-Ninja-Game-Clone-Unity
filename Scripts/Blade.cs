using System;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;

    public float minDistance = 0.005f;
    private Vector3 lastMousePos;
    private Collider2D col;
    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        col.enabled = IsMouseMoving(); 
        SetBladeToMouse();
    }
    private void SetBladeToMouse()
    {

        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private Boolean IsMouseMoving()
    {
        Vector3 currentMousePos = rb.position;
        float traveled = Vector3.Distance(lastMousePos, currentMousePos);
        lastMousePos = currentMousePos;
        if (traveled > minDistance) { 
            return true;
        }
        return false;
    }
}
