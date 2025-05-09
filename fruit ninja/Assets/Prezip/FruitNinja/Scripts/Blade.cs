using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider sc;
    private TrailRenderer tr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            sc.enabled = true;
            tr.enabled = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            sc.enabled = false;
            tr.enabled = false;
        }
        BladeFollowMouse();
    }

    private void BladeFollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 8;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);

    }
}
